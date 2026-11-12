using Confluent.Kafka;
using EventSourcing.Common.Communications.Events;
using EventSourcing.Common.Communications.Events.Base;
using EventSourcing.Common.Communications.Producers.Interfaces;
using EventSourcing.Common.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HR.Command.Infrastructure.Persistance
{
    public class KafkaEventProducer : IEventProducer
    {
        private readonly KafkaSettings _kafkaSettings;

        public KafkaEventProducer(IOptions<KafkaSettings> kafkaSettings)
        {
            _kafkaSettings = kafkaSettings.Value;
        }

        public async Task ProduceDomainEventAsync(string topic, DomainEvent @event)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = $"{_kafkaSettings.Hostname}:{_kafkaSettings.Port}"
            };

            using var producer = new ProducerBuilder<string, string>(config)
                                        .SetKeySerializer(Serializers.Utf8)
                                        .SetValueSerializer(Serializers.Utf8)
                                        .Build();
            var eventMessage = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonConvert.SerializeObject(@event)
            };

            var deliveryStatus = await producer.ProduceAsync(topic, eventMessage);

            if (deliveryStatus.Status == PersistenceStatus.NotPersisted)
            {
                throw new Exception($"Failed to produce domain event {@event.GetType().Name} to topic {topic}. Status: {deliveryStatus.Status}");
            }
        }

        public async Task ProduceIntegrationEventAsync(string topic, IntegrationEvent @event)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = $"{_kafkaSettings.Hostname}:{_kafkaSettings.Port}"
            };

            using var producer = new ProducerBuilder<string, string>(config)
                                        .SetKeySerializer(Serializers.Utf8)
                                        .SetValueSerializer(Serializers.Utf8)
                                        .Build();
            var eventMessage = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonConvert.SerializeObject(@event)
            };

            var deliveryStatus = await producer.ProduceAsync(topic, eventMessage);

            if (deliveryStatus.Status == PersistenceStatus.NotPersisted)
            {
                throw new Exception($"Failed to produce an integration event {@event.GetType().Name} to topic {topic}. Status: {deliveryStatus.Status}");
            }
        }
    }
}
