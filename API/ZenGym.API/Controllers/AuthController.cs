using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ZenGym.Application.Authentication;
using ZenGym.Application.Common;
using ZenGym.Domain.Entities;

namespace ZenGym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public AuthController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //validate Request

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _authService.UserExists(userForRegisterDto.Username))
                return BadRequest("Username Already Exists");

            var userToCreate = new User
            {
                UserName = userForRegisterDto.Username
            };

            var createdUser = await _authService.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            try
            {
                var user = await _authService.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

                if (user == null)
                    return Unauthorized();

                var tokenSettings = _config.GetSection("AppSettings:Token").Value;
                var token = CommonSecurity.GenerateJwtToken(user, tokenSettings);

                return Ok(new { token });
            }
            catch (Exception Ex)
            {
                return StatusCode(500, "System Says No !");
            }

        }


    }
}