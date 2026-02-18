using BsdFinalProject.Data;
using BsdFinalProject.DTOs;
using BsdFinalProject.Models;
using BsdFinalProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BsdFinalProject.IServices;

namespace BsdFinalProject.Controllers
{
    [ApiController]
    [AllowAnonymous]
    //[EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly SaleContext _context;
        private readonly IUserService _service;
        private readonly ILogger<UsersController>  _logger;

        public UsersController(SaleContext context, IUserService service, ILogger<UsersController> logger)
        {
            _context = context;
            _service = service;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> UserRegister([FromBody] CreateUserDto dto)
        {
            var (success, token, error) = await _service.UserRegister(dto);
            if (!success) { 
                _logger.LogWarning("User registration failed: {Error}", error);
                return BadRequest(new { error }); 
            }

            return Created(string.Empty, new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var (success, token, error) = await _service.LoginAsync(dto);
            if (!success)
            {
                _logger.LogWarning("User login failed: {Error}", error);
                return BadRequest(new { error });
            }

            return Ok(new { token });
        }
        // GET api/users/{id} - return user details by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _service.GetUserById(id);
                if (user == null)
                {
                    _logger.LogInformation("User with id {Id} not found.", id);
                    return NotFound(new { message = "User not found." });
                }

                var dto = new UserDto
                {
                    Id = user.Id,
                    EMail = user.EMail,
                    FullName = user.FullName,
                    Phone = user.Phone,
                    Address = user.Address
                };

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user by id {Id}", id);
                return BadRequest(new { message = ex.Message });
            }
        }

        
    }
}