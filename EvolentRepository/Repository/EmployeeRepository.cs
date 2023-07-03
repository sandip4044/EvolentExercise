using Evolent.Repository.Models;
using Evolent.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Evolent.Repository.Exceptions;
using System.Data.SqlClient;

namespace Evolent.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>
        /// variable to represent EmployeeContext
        /// </summary>
        readonly EmployeeContext employeeContext;

        //public EmployeeRepository()
        //{
        //var employees = new List<Employee>
        //    {
        //        new Employee
        //        {
        //            Id = 101,
        //            firstName ="Allen",
        //            lastName ="Cook",
        //            email ="abc@demo.com",
        //            address = "Pune, Maharashtra",
        //            age = 32
        //        },
        //        new Employee
        //        {
        //            Id = 102,
        //            firstName ="John",
        //            lastName ="Smith",
        //            email ="pqr@demo.com",
        //            address = "Banglore, Karnataka",
        //            age = 30
        //        }
        //    };
        //employeeContext.Employees.AddRange(employees);
        //    employeeContext.SaveChanges();
        //}

        /// <summary>
        /// Injected employee context
        /// </summary>
        /// <param name="_context">context param</param>
        public EmployeeRepository(EmployeeContext _employeeContext)
        {
            employeeContext = _employeeContext;
        }

        /// <summary>
        /// get employee
        /// </summary>
        /// <returns>return result</returns>
        public List<Employee> GetEmployee()
        {
            using (var context = new EmployeeContext())
            {
                var list = employeeContext.Employees.ToList();
                return list;
            }
        }

        /// <summary>
        /// register a new employee
        /// </summary>
        /// <param name="employee">employee param</param>
        /// <returns>return result</returns>
        public Employee RegisterEmployee(Employee employee)
        {
            try
            {

                using (var context = new EmployeeContext())
                {
                    var emp = context.Employees.SingleOrDefault(b => b.Id == employee.Id);
                    if (emp != null)
                    {
                        throw new EmployeeIdAlreadyExistException("Employee Id already exist");
                    }
                    else
                    {
                        //Adding Employee
                        employeeContext.Employees.Add(employee);
                        employeeContext.SaveChanges();

                        //Adding Employee Address
                        var employeeAddress = new EmployeeAddress();
                        employeeAddress.employeeId = employee.Id;
                        employeeAddress.address = employee.address;
                        employeeContext.EmployeeAddress.Add(employeeAddress);
                        employeeContext.SaveChanges();
                    }
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// update an existing employee
        /// </summary>
        /// <param name="employeeId">employeeId param</param>
        /// <param name="employee">employee param</param>
        /// <returns>return result</returns>
        public bool UpdateEmployee(int employeeId, Employee employee)
        {
            try
            {
                var result = false;
                using (var context = new EmployeeContext())
                {
                    //Updating Employee
                    var emp = context.Employees.Single(b => b.Id == employeeId);
                    emp.Id = employeeId;
                    emp.firstName = employee.firstName;
                    emp.lastName = employee.lastName;
                    emp.email = employee.email;
                    emp.address = employee.address;
                    emp.age = employee.age;
                    context.SaveChanges();

                    //Updating Employee Address
                    var empAdd = context.EmployeeAddress.Single(b => b.employeeId == employeeId);
                    empAdd.address = employee.address;
                    context.SaveChanges();

                    result = true;
                }
                return result;
            }
            catch (Exception)
            {
                throw new EmployeeNotFoundException();
            }
        }

        /// <summary>
        /// delete an existing employee
        /// </summary>
        /// <param name="employeeId">employeeId param</param>
        /// <returns>return result</returns>
        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                bool result = false;
                using (var context = new EmployeeContext())
                {
                    //Deleting employee
                    var emp = context.Employees.Single(b => b.Id == employeeId);
                    context.Employees.Remove(emp);
                    context.SaveChanges();

                    //Deleting employee address
                    var empAdd = context.EmployeeAddress.Single(b => b.employeeId == employeeId);
                    context.EmployeeAddress.Remove(empAdd);
                    context.SaveChanges();

                    result = true;
                }
                return result;
            }
            catch (Exception)
            {
                throw new EmployeeNotFoundException();
            }
        }

        /// <summary>
        /// get employee address
        /// </summary>
        /// <returns>return result</returns>
        public List<EmployeeAddress> GetEmployeeAddress()
        {
            using (var context = new EmployeeContext())
            {
                var list = context.EmployeeAddress.ToList();
                return list;
            }
        }

        public List<Employee> GetSearchEmployee(Employee employee)
        {
            using (var context = new EmployeeContext())
            {
                var list = employeeContext.Employees.
                            Where(emp => emp.firstName.Contains(employee.firstName) || emp.lastName.Contains(employee.lastName)).ToList();
                return list;
            }
        }

        /// <summary>
        /// Exception error logger
        /// </summary>
        /// <param name="ex">exception</param>
        public static void ErrorLogging(Exception ex)
        {
            string strPath = @"C:\Sandip Korat\Devlopment\EvolentProject\EvolentAPI\EvolentServices\ExceptionLogger.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }
    }
}
