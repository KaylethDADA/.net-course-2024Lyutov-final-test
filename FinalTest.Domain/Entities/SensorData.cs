namespace FinalTest.Domain.Entities
{
    public class SensorData : BaseEntity
    {
        public float Value { get; init; }
        public DateTime Timestamp { get; init; }

        public Guid SensorId { get; set; }
        public Sensor Sensor { get; set; }

        public SensorData(float value, Guid sensorId, DateTime timestamp)
        {
            Value = value;
            Timestamp = timestamp;
            SensorId = sensorId;
        }

        public SensorData()
        {
            
        }
    }
}
