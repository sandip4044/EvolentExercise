using Evolent.Repository.Exceptions;
using Evolent.Repository.Models;
using Evolent.Repository.Repository;

namespace Evolent.Services
{
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// variable to represent repository
        /// </summary>
        readonly IEmployeeRepository employeeRepository;

        /// <summary>
        /// Inject user dependencies
        /// </summary>
        /// <param name="_employeeRepository"></param>
        public EmployeeService(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        /// <summary>
        /// get employees
        /// </summary>
        /// <returns>return result</returns>
        /// <exception cref="EmployeeNotFoundException"></exception>
        public List<Employee> GetEmployee()
        {
            List<Employee> employees = employeeRepository.GetEmployee();
            if (employees == null)
            {
                throw new EmployeeNotFoundException("employees not found");
            }
            return employees;
        }

        /// <summary>
        /// Register employee
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns>return result</returns>
        /// <exception cref="EmployeeIdAlreadyExistException"></exception>
        public Employee RegisterEmployee(Employee employee)
        {
            Employee employeeData = employeeRepository.RegisterEmployee(employee);
            if (employeeData == null)
            {
                throw new EmployeeIdAlreadyExistException("This employee id already exists");
            }
            return employeeData;
        }

        /// <summary>
        /// update employee
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="employee">employee</param>
        /// <returns>return result</returns>
        /// <exception cref="EmployeeNotFoundException"></exception>
        public bool UpdateEmployee(int employeeId, Employee employee)
        {
            bool result = employeeRepository.UpdateEmployee(employeeId, employee);
            if (result == false)
            {
                throw new EmployeeNotFoundException("This employee id does not exist");
            }
            return result;
        }

        /// <summary>
        /// delete employee
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>return result</returns>
        /// <exception cref="EmployeeNotFoundException"></exception>
        public bool DeleteEmployee(int employeeId)
        {
            bool result = employeeRepository.DeleteEmployee(employeeId);
            if (result == false)
            {
                throw new EmployeeNotFoundException("This employee id does not exist");
            }
            return true;
        }

        /// <summary>
        /// get employees address
        /// </summary>
        /// <returns>return result</returns>
        /// <exception cref="EmployeeNotFoundException"></exception>
        public List<EmployeeAddress> GetEmployeeAddress()
        {
            List<EmployeeAddress> employees = employeeRepository.GetEmployeeAddress();
            if (employees == null)
            {
                throw new EmployeeNotFoundException("employees not found");
            }
            return employees;
        }

        /// <summary>
        /// get search employee
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns></returns>
        /// <exception cref="EmployeeNotFoundException"></exception>
        public List<Employee> GetSearchEmployee(Employee employee)
        {
            List<Employee> employees = employeeRepository.GetSearchEmployee(employee);
            if (employees.Count == 0)
            {
                throw new EmployeeNotFoundException("employees not found");
            }
            return employees;
        }
    }
}
