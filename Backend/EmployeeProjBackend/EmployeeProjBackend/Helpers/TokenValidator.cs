using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
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
        public static bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
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
