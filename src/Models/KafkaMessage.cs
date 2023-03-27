namespace Permissions.API.Models
{
    public class KafkaMessage
    {
        public Guid Id { get; set; }
        public string Operation { get; set; } = string.Empty;
    }
}
