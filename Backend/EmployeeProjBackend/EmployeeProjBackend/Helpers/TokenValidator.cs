using EmployeeProjBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProjBackend.Authorization
{
    public class TokenValidator 
    {
        private static IConfiguration Configuration;

        public TokenValidator(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static bool ValidateToken(string authToken, string userGuidId)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);

                var handler = new JwtSecurityTokenHandler();
               
                // Validate GuidID
                var jsonToken = handler.ReadToken(authToken);
                var tokenS = jsonToken as JwtSecurityToken;

                var GuidID = tokenS.Claims.First(i => i.Type == "GuidID").Value;
                
                if (GuidID.ToLower() == userGuidId.ToLower())
                return true;

                return false;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        private static TokenValidationParameters GetValidationParameters()
        {
            // Set JWT Authentication (Token)

            return new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt_Secrey_Key1038489543")),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidIssuer = "http://localhost:4200",
                ValidAudience = "http://localhost:4200"
            };
        }

    }
}
