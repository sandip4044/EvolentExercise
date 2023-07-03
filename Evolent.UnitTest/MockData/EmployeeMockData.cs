using Evolent.Repository.Models;

namespace Evolent.UnitTest.MockData
{
    public class EmployeeMockData
    {
        public static List<Employee> EmployeeMock()
        {
            return new List<Employee>
            {
                new Employee
                {
                    firstName = "TestOneFName",
                    lastName = "TestOneLName",
                    address = "TestOneAddress",
                    age = 20,
                    email = "TestOneEmail"
                },
                new Employee
                {
                    firstName = "TestSecondFName",
                    lastName = "TestSecondLName",
                    address = "TestSecondAddress",
                    age = 30,
                    email = "TestSecondEmail"
                }
            };
        }
    }
}

