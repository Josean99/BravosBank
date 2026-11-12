namespace BravosBank.Shared.EventSourcing.Settings
{
    public class KafkaSettings
    {
        public string Hostname { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
    }

    public class KafkaTopicSettings
    {
        public string EmployeeCreatedEvent { get; set; } = string.Empty;
        public string EmployeeUpdatedEvent { get; set; } = string.Empty;
        public string EmployeeDeletedEvent { get; set; } = string.Empty;
        public string ExternalCreatedEvent { get; set; } = string.Empty;
        public string ExternalUpdatedEvent { get; set; } = string.Empty;
        public string ExternalDeletedEvent { get; set; } = string.Empty;
    }
}
