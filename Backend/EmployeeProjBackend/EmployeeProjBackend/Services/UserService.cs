using EmployeeProjBackend.Interfaces;
using EmployeeProjBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProjBackend.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationSettings _appSettings;
        public UserService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public async Task<object> Login(LoginModel model)
        {
            try
            {
                if (model == null)
                    return null;

                IdentityOptions _options = new IdentityOptions();

                var tokenDecsriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("GuidID", _appSettings.GuidID.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                    (
                        Encoding.UTF8.GetBytes(_appSettings.Jwt_Secret)),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDecsriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
            }

            catch (Exception)
            {
                return null;
            }
        }
    }
}
