using Evolent.Repository.Exceptions;
using Evolent.Repository.Models;
using Evolent.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvolentAPI.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService employeeService;

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="_employeeService">_employeeService</param>
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        /// <summary>
        /// get employee
        /// </summary>
        /// <returns>return result</returns>
        [Route("api/employee")]
        [HttpGet]
        public ActionResult<List<Employee>> GetEmployee()
        {
            return Ok(employeeService.GetEmployee());
        }

        /// <summary>
        /// create employee
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns>return result</returns>
        [Route("api/employee/create")]
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            try
            {
                Employee addedEmp = this.employeeService.RegisterEmployee(employee);
                if (addedEmp != null)
                {
                    return Created("api/employee", addedEmp);
                }
                return Ok();
            }
            catch (EmployeeNotCreatedException ex)
            {
                return Conflict(ex.Message);
            }
        }

        /// <summary>
        /// update employee
        /// </summary>
        /// <param name="employeeid">employeeid</param>
        /// <param name="employee">employee</param>
        /// <returns>return result</returns>
        [Route("api/employee/{employeeid}")]
        [HttpPut]
        public IActionResult UpdateEmployee(int employeeid, [FromBody] Employee employee)
        {
            try
            {
                bool result = this.employeeService.UpdateEmployee(employeeid, employee);
                if (result)
                {
                    return Ok(employee);
                }
                return Ok();
            }
            catch (EmployeeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// delete employee
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>return result</returns>
        [Route("api/employee/{id}")]
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                bool result = this.employeeService.DeleteEmployee(id);
                return Ok(result);
            }
            catch (EmployeeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// get employee address
        /// </summary>
        /// <returns>return result</returns>
        [Route("employeeaddress")]
        [HttpGet]
        public ActionResult<List<EmployeeAddress>> GetEmployeeAddress()
        {
            return Ok(employeeService.GetEmployeeAddress());
        }

        /// <summary>
        /// get employee address
        /// </summary>
        /// <returns>return result</returns>
        [Route("api/employee/search")]
        [HttpPost]
        public ActionResult<List<Employee>> GetSearchEmployee(EmployeeSearch search)
        {
            Employee employee = new Employee();
            employee.firstName = search.firstName;
            employee.lastName = search.lastName;
            return Ok(employeeService.GetSearchEmployee(employee));
        }
    }
}
