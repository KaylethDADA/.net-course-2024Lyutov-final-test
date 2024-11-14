namespace FinalTest.App.Dtos.Sensors
{
    public sealed record UpdateSensorRequest(
       Guid SensorId,
       string Name,
       string Description,
       float X,
       float Y,
       Guid BuildingId,
       string DataType,
       float MinThreshold,
       float MaxThreshold);
}
