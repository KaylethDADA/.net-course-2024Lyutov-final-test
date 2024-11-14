using FinalTest.App.Dtos.Building;
using FinalTest.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly BuildingService _buildingService;

        public BuildingController(BuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateBuilding(
            [FromBody] CreateBuildingRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _buildingService.AddBuildingAsync(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBuilding(
            [FromBody] UpdateBuildingRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _buildingService.UpdateBuildingAsync(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetById/{buildingId}")]
        public async Task<IActionResult> GetBuildingById(
            [FromRoute] Guid buildingId,
            CancellationToken cancellationToken)
        {
            var building = await _buildingService.GetBuildingByIdAsync(buildingId, cancellationToken);
            return Ok(building);
        }

        [HttpPost("Get")]
        public async Task<IActionResult> GetBuildings(
            [FromBody] PagedBuildingRequest request,
            CancellationToken cancellationToken)
        {
            var buildings = await _buildingService.GetBuildingsAsync(request, cancellationToken);
            return Ok(buildings);
        }

        [HttpDelete("Delete/{buildingId}")]
        public async Task<IActionResult> DeleteBuilding(
            [FromRoute] Guid buildingId,
            CancellationToken cancellationToken)
        {
            await _buildingService.DeleteBuildingAsync(buildingId, cancellationToken);
            return Ok();
        }
    }
}
