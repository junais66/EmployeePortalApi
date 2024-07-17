using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmloyeePortal.Model.Dto;
using EmloyeePortal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmloyeePortal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetDashboardData")]
        public async Task<ActionResult<DashboardDataDto>> GetDashboardData()
        {
            var dashboardData = await _employeeService.GetDashboardData();
            return Ok(dashboardData);
        }

        [HttpPost("SaveEmployee")]
        public IActionResult SaveEmployee([FromBody] EmployeeDto input)
        {
            try
            {
                var res = _employeeService.SaveEmployee(input);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAllEmployee")]
        public async Task<ActionResult<EmployeeDto>> GetAllEmployee()
        {
            var dashboardData = await _employeeService.GetAllEmployees();
            return Ok(dashboardData);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(string id, [FromBody] EmployeeDto input)
        {
            try
            {
                if (id != input.Id)
                {
                    return BadRequest();
                }
                var res = _employeeService.UpdateEmployee(input, id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(string id)
        {
            try
            {
                var res = _employeeService.DeleteEmployee(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

