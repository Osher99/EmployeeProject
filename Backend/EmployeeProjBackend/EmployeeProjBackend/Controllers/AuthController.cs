using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeProjBackend.Interfaces;
using EmployeeProjBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeProjBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginModel user)
        {
            if (user == null)
                return BadRequest("Invalid request");

            if (user.UserName.ToLower() == "admin" && user.Password.ToLower() == "adminsecret")
            {
                var token = await _userService.Login(user);

                if (token != null)
                    return Ok(new { token });
            }
            return BadRequest("No user found");
        }
    }
}