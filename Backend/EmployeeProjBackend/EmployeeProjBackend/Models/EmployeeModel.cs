using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProjBackend.Models
{
    public class EmployeeModel
    {
        public Guid GuidID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }

    }
}
