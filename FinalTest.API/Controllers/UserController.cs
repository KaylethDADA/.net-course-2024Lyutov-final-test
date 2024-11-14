using FinalTest.App.Dtos.Users;
using FinalTest.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly UserService _userService;
        
        public ClientController(UserService clientService)
        {
            _userService = clientService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateClient(
            [FromBody] CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _userService.AddUserAsync(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateClient(
            [FromBody] UpdateUserRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _userService.UpdateUserAsync(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetById/{clientId}")]
        public async Task<IActionResult> GetClientById(
            [FromRoute] Guid clientId,
            CancellationToken cancellationToken)
        {
            var client = await _userService.GetUserByIdAsync(clientId, cancellationToken);
            return Ok(client);
        }

        [HttpPost("Get")]
        public async Task<IActionResult> GetClients(
            [FromBody] PagedUsersRequest filterRequest,
            CancellationToken cancellationToken)
        {
            var clients = await _userService.GetUsersAsync(filterRequest, cancellationToken);
            return Ok(clients);
        }

        [HttpDelete("Delete/{clientId}")]
        public async Task<IActionResult> DeleteClient(
            [FromRoute] Guid clientId,
            CancellationToken cancellationToken)
        {
            await _userService.DeleteUserAsync(clientId, cancellationToken);
            return NoContent();
        }
    }
}
