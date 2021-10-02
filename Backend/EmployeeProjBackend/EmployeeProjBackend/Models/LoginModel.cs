using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProjBackend.Models
{
    public class LoginModel
    {
        public Guid GuidID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
