using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeProjBackend.Authorization;
using EmployeeProjBackend.Interfaces;
using EmployeeProjBackend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace EmployeeProjBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Fields
        //private const string EMAIL_VERIFIED_URI = "http://localhost:4200/user/login";
        private readonly IEmployeeService _employeeService;
        #endregion


        #region Ctor
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            try
            {
                var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", string.Empty);
                var validToken = TokenValidator.ValidateToken(accessToken);

                if (validToken) return await _employeeService.GetEmployees();

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetEmployeeByName")]
        public async Task<EmployeeModel> GetEmployeeByName(string name)
        {
            try
            {
                return await _employeeService.GetEmployeeByName(name);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetEmployeesByAddress")]
        public async Task<IEnumerable<EmployeeModel>> GetEmployeesByAddress(string address)
        {
            try
            {
                return await _employeeService.GetEmployeesByAddress(address);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}