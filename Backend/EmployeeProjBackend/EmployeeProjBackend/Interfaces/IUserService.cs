using EmployeeProjBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProjBackend.Interfaces
{
    public interface IUserService
    {
       Task<object> Login(LoginModel model);
    }
}
