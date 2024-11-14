using FinalTest.App.Dtos.Sensors;
using FinalTest.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly SensorService _sensorService;

        public SensorController(SensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateSensor(
            [FromBody] CreateSensorRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _sensorService.CreateSensorAsync(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSensor(
            [FromBody] UpdateSensorRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _sensorService.UpdateSensorAsync(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetById/{sensorId}")]
        public async Task<IActionResult> GetSensorById(
            [FromRoute] Guid sensorId,
            CancellationToken cancellationToken)
        {
            var sensor = await _sensorService.GetSensorByIdAsync(sensorId, cancellationToken);
            return Ok(sensor);
        }

        [HttpPost("NotifyThresholdExceeded")]
        public async Task<IActionResult> NotifySensorThresholdExceeded(
            [FromQuery] Guid sensorId,
            [FromQuery] float sensorValue,
            CancellationToken cancellationToken)
        {
            await _sensorService.NotifySensorThresholdExceededAsync(sensorId, sensorValue, cancellationToken);
            return NoContent();
        }

        [HttpPost("NotifyLowBattery")]
        public async Task<IActionResult> NotifyLowBattery(
            [FromQuery] Guid sensorId,
            [FromQuery] float batteryLevel,
            CancellationToken cancellationToken)
        {
            await _sensorService.NotifyLowBatteryAsync(sensorId, batteryLevel, cancellationToken);
            return NoContent();
        }
    }
}
