using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace Permissions.API.Interfaces
{
    public class KafkaProducer : IProducerKafka
    {
        private readonly ProducerConfig _config;
        private readonly string _topic;
        private readonly IConfiguration _configuration;

        public KafkaProducer(IConfiguration configuration)
        {
            _configuration = configuration;
            _config = new() { BootstrapServers = _configuration["Kafka:BootstrapServers"] };
            _topic = _configuration["Kafka:Topic"];
        }

        public async Task<DeliveryResult<Null, string>> SendMessage(string message)
        {
            using var producer = new ProducerBuilder<Null, string>(_config).Build();
            try
            {
                return await producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
                
                    //.GetAwaiter()
                //.GetResult();
            }
            catch (ProduceException<Null, string> e)
            {
                return e.DeliveryResult;
            }            
        }
    }
}
