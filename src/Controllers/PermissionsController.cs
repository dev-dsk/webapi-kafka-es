using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Permissions.API.Entities;
using Permissions.API.Interfaces;
using Permissions.API.Models;
using Permissions.API.Resources.Commands;
using Permissions.API.Resources.Queries;
using System.Text.Json;

namespace Permissions.API.Controllers
{
    [Route("api/permissions")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<PermissionsController> _logger;
        private readonly IElasticClient _elasticClient;
        private IProducerKafka _producerKafka;

        public PermissionsController(IMediator mediator, 
            IMapper mapper, 
            ILogger<PermissionsController> logger, 
            IElasticClient elasticClient,
            IProducerKafka producerKafka)
        {
            _mediator = mediator 
                ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger 
                ?? throw new ArgumentNullException(nameof(logger));
            _elasticClient = elasticClient 
                ?? throw new ArgumentNullException(nameof(elasticClient));
            _producerKafka = producerKafka 
                ?? throw new ArgumentNullException(nameof(producerKafka));
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Permissions()
        {
            _logger.LogInformation("Processed Endpoint: Permissions in PermissionsController, Method: GET");

            try
            {                
                IEnumerable<PermissionForListDTO> permissionForListDTO = new List<PermissionForListDTO>();

                var resultEntities = await _mediator.Send(new GetAllPermissionsQuery());

                _mapper.Map(resultEntities, permissionForListDTO);
                var messageToKafka = JsonSerializer.Serialize(new KafkaMessage() { Id = Guid.NewGuid(), Operation = "get" });
                var resultKafka = _producerKafka.SendMessage(messageToKafka);
                
                _logger.LogInformation("Processed Kafka: {0} - Message: {1} ", resultKafka.Status, messageToKafka);
                
                return Ok(permissionForListDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    
        [HttpGet("{permissionId}/validate/{permissionType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Validate(int permissionId, int permissionType)
        {
            _logger.LogInformation("Processed Endpoint: Validate (Request Permission) in PermissionsController, Method: GET");
            try
            {
                var messageToKafka = JsonSerializer.Serialize(new KafkaMessage() { Id = Guid.NewGuid(), Operation = "request" });
                var resultKafka = _producerKafka.SendMessage(messageToKafka);
                _logger.LogInformation("Processed Kafka: {0} - Message: {1} ", resultKafka.Status, messageToKafka);

                var result = await _mediator.Send(new GetPermissionRequestByIdsQuery(permissionId, permissionType));
                if (result)
                    return Ok();

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idPermission}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]        
        public async Task<IActionResult> Permissions(PermissionForUpdateDTO resource, int idPermission)
        {
            try
            {
                _logger.LogInformation("Processed Endpoint: Permission in PermissionsController, Method: PUT");

                var messageToKafka = JsonSerializer.Serialize(new KafkaMessage() { Id = Guid.NewGuid(), Operation = "modify" });
                var resultKafka = _producerKafka.SendMessage(messageToKafka);
                _logger.LogInformation("Processed Kafka: {0} - Message: {1} ", resultKafka.Status, messageToKafka);
                

                if (idPermission == 0)
                    return BadRequest();

                var commandUpdate = new UpdatePermissionCommand(idPermission);
                _mapper.Map(resource, commandUpdate);

                if (!TryValidateModel(commandUpdate))
                {
                    return UnprocessableEntity(ModelState);
                }

                var result = await _mediator.Send(commandUpdate);
                if (result == null)
                {
                    return NotFound();
                }

                var elasticObject = _mapper.Map(resource, new Permission());
                elasticObject.Id = idPermission;

                //await _elasticClient.IndexDocumentAsync(elasticObject);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
