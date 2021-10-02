using EmployeeProjBackend.Interfaces;
using EmployeeProjBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProjBackend.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEnumerable<EmployeeModel> EmployeesList { get; set; }
        public EmployeeService()
        {
            GenerateEmployeeList();
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            return EmployeesList;
        }

        public async Task<EmployeeModel> GetEmployeeByName(string name)
        {
            try
            {
                if (!String.IsNullOrEmpty(name) || EmployeesList.Count() == 0)
                    return null;

                return EmployeesList.Where(emp => emp.FullName.Contains(name)).FirstOrDefault();
            }

            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesByAddress(string address)
        {
            try
            {
                if (!String.IsNullOrEmpty(address) || EmployeesList.Count() == 0)
                    return null;

                return EmployeesList.Where(emp => emp.Address.Contains(address)).ToList();
            }

            catch (Exception)
            {
                return null;
            }
        }

        private void GenerateEmployeeList()
        {
            EmployeesList = new List<EmployeeModel>
            {
                new EmployeeModel
                {
                    GuidID = Guid.NewGuid(),
                    FullName = "Osher Dror",
                    Address = "Beer Sheva, Israel",
                    Department = "Development"
                },
                new EmployeeModel
                {
                    GuidID = Guid.NewGuid(),
                    FullName = "John Doe",
                    Address = "New York NY",
                    Department = "Design"
                },
                new EmployeeModel
                {
                    GuidID = Guid.NewGuid(),
                    FullName = "Andrew Watson",
                    Address = "Chicago IL",
                    Department = "Development"
                },
                new EmployeeModel
                {
                    GuidID = Guid.NewGuid(),
                    FullName = "Ronnie Dunn",
                    Address = "Miami, Florida",
                    Department = "Design"
                }
            };
        }
    }
}
