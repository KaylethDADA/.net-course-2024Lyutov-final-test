namespace FinalTest.Domain.Entities
{
    public class Sensor : BaseEntity
    {
        public string Name { get; init; }
        public string Description { get; init; }

        // TODO: На потом.
        //public string PhotoUrl { get; init; }

        public float X { get; init; }
        public float Y { get; init; }

        public Guid BuildingId { get; init; }
        public Building Building { get; init; }

        // Тип показателя, который измеряет датчик (например, Температура, Влажность, Заряд батареи)
        public string DataType { get; init; }

        // Минимальное и максимальное значения для уведомлений
        public float MinThreshold { get; init; }
        public float MaxThreshold { get; init; }

        public ICollection<SensorData> SensorData { get; init; } = new List<SensorData>();


        public Sensor(string name, string description, float x, float y, Guid buildingId, string dataType, float minThreshold, float maxThreshold)
        {
            Name = name;
            Description = description;
            X = x;  
            Y = y;
            BuildingId = buildingId;
            DataType = dataType;
            MinThreshold = minThreshold;
            MaxThreshold = maxThreshold;

        }

        public Sensor()
        {
            
        }
    }
}
