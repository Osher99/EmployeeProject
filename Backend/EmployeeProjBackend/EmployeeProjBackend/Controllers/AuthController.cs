using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeProjBackend.Interfaces;
using EmployeeProjBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeProjBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ApplicationSettings _appSettings;

        public AuthController(IUserService userService, IOptions<ApplicationSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginModel user)
        {
            if (user == null)
                return BadRequest("Invalid request");

            if (user.UserName.ToLower() == _appSettings.UserName && user.Password.ToLower() == _appSettings.UserPassword)
            {
                var token = await _userService.Login(user);

                if (token != null)
                    return Ok(new { token });
            }
            return BadRequest("No user found");
        }
    }
}