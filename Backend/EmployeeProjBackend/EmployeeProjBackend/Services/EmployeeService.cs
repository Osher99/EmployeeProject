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
                    GuidID = Guid.Parse("147bccbb-314e-4a1d-9902-741fa34efd5d"),
                    FullName = "Osher Dror",
                    Address = "Beer Sheva, Israel",
                    Department = "Development"
                },
                new EmployeeModel
                {
                    GuidID = Guid.Parse("11476502-c196-447e-9565-b3a416c612f4"),
                    FullName = "John Doe",
                    Address = "New York NY",
                    Department = "Design"
                },
                new EmployeeModel
                {
                    GuidID = Guid.Parse("be6cacdc-3e30-4a54-98d9-1a6884443496"),
                    FullName = "Andrew Watson",
                    Address = "Chicago IL",
                    Department = "Development"
                },
                new EmployeeModel
                {
                    GuidID = Guid.Parse("30435bd3-15ff-4647-b1b4-3a333ce7a8bd"),
                    FullName = "Ronnie Dunn",
                    Address = "Miami, Florida",
                    Department = "Design"
                }
            };
        }
    }
}
