using Evolent.Repository.Models;

namespace Evolent.Repository.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployee();
        Employee RegisterEmployee(Employee employee);
        bool UpdateEmployee(int employeeId, Employee employee);
        bool DeleteEmployee(int employeeId);
        List<EmployeeAddress> GetEmployeeAddress();
        List<Employee> GetSearchEmployee(Employee employee);
    }
}
