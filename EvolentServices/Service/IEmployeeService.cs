using Evolent.Repository.Models;

namespace Evolent.Services
{
    public interface IEmployeeService
    {
        Employee RegisterEmployee(Employee employee);
        bool UpdateEmployee(int employeeId, Employee employee);
        bool DeleteEmployee(int employeeId);
        List<Employee> GetEmployee();
        List<EmployeeAddress> GetEmployeeAddress();
        List<Employee> GetSearchEmployee(Employee employee);
    }
}
