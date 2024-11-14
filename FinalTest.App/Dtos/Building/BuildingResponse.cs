using FinalTest.App.Dtos.Sensors;

namespace FinalTest.App.Dtos.Building
{
    public sealed record BuildingResponse(
        Guid Id,
        string Name,
        string Addres,
        Guid UserId, 
        ICollection<SensorResponse> Sensors);
}
