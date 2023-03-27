using Confluent.Kafka;
using static Confluent.Kafka.ConfigPropertyNames;

namespace Permissions.API.Interfaces
{
    public interface IProducerKafka 
    {
        Task<DeliveryResult<Null, string>> SendMessage(string message);
    }
}
