using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProjBackend.Models
{
    public class ApplicationSettings
    {
        public string Jwt_Secret { get; set; }
        public string Client_URL { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string GuidID { get; set; }
    }
}
