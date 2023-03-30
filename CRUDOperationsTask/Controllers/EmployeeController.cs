using ApplicationCore.Models;
using ApplicationInfrastructure.DTOS;
using Microsoft.AspNetCore.Mvc;
using Services.BusinessInterface;
using Services.ViewModels.RequestViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDOperationsTask.Controllers
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
        [HttpGet]
        public IActionResult GetEmployeeById(int? id)
        {
            try {
                if(id != null)
                    return Ok(_employeeService.GetEmployeeById(id.Value));
                else 
                    return Ok(_employeeService.GetAllEmployees());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult InsertNewEmployee([FromBody]EmployeeRequestViewModel employee)
        {
            try {
                return Ok(_employeeService.InsertNewEmployee(employee));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateEmployee(int EmployeeId,[FromBody] EmployeeRequestViewModel employee)
        {
            try {
                return Ok(_employeeService.UpdateEmployeeData(EmployeeId, employee));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteEmployeeById(int id)
        {
            try
            {
                return Ok(_employeeService.DeleteEmployeeById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
