using EmployeeProjBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProjBackend.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetEmployees();
        Task<EmployeeModel> GetEmployeeByName(string name);
        Task<IEnumerable<EmployeeModel>> GetEmployeesByAddress(string address);
    }
}
