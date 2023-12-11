using API.Dtos;
using API.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Persistance.Data;
using Persistence.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BackEndContext _context;

        public AuthController(IConfiguration configuration, IUserService userService, IUnitOfWork unitOfWork, BackEndContext context)
        {
            _configuration = configuration;
            _userService = userService;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet, Authorize(Roles = "Person")]
        public ActionResult<string> GetMyName()
        {
            return Ok(_userService.GetMyName());

            //var userName = User?.Identity?.Name;
            //var roleClaims = User?.FindAll(ClaimTypes.Role);
            //var roles = roleClaims?.Select(c => c.Value).ToList();
            //var roles2 = User?.Claims
            //    .Where(c => c.Type == ClaimTypes.Role)
            //    .Select(c => c.Value)
            //    .ToList();
            //return Ok(new { userName, roles, roles2 });
        }

        [HttpGet("usuarios")]
        public IActionResult GetUsuarios()
        {
            var query = from usuario in _context.Users
                        select new
                        {
                            Id = usuario.Id,
                            NombreUsuario = usuario.Username,
                            Email = usuario.Email
                        };

            var usuarios = query.ToList();

            return Ok(usuarios);
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(UserRegisterDto request)
        {
            var result = await _userService.RegisterAsync(request);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var result = await _userService.LoginAsync(request);
            return Ok(result);
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult<string>> RefreshToken(string username)
        {
            var result = await _userService.RefreshToken(username);
            return Ok(result);
        }

        [HttpPost("rols")]
        public async Task<ActionResult<IEnumerable<User>>> GetRolAsync(UserDto request)
        {
            var results = await _userService.GetTokenAsync(request);

            return Ok(results);
        }
        [HttpPost("addRol")]
        public async Task<ActionResult<string>> AddRolAsync(UserRolDto request)
        {
            var results = await _userService.AddRolAsync(request);

            return Ok(results);
        }
    }
}