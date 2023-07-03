using Evolent.Repository.Models;
using Evolent.Services;
using Evolent.UnitTest.MockData;
using EvolentAPI.Controllers;
using Moq;

namespace Evolent.UnitTest
{
    public class EmployeeTest
    {
        [Fact]
        public async Task TestGetAllEmployee_ShouldReturn200Status()
        {
            /// Arrange
            var todoService = new Mock<IEmployeeService>();
            todoService.Setup(_ => _.GetEmployee());
            var sut = new EmployeeController(todoService.Object);

            /// Act
            var result = sut.GetEmployee();

            // /// Assert
            result.Result.Equals(200);
        }

        [Fact]
        public async Task Insert_ShouldReturn200Status()
        {
            /// Arrange
            var todoService = new Mock<IEmployeeService>();
            Employee employee = new Employee();
            employee.firstName = "TestFirstName";
            employee.lastName = "TestLastName";
            employee.address = "TestAddress";
            employee.email = "Test@demo.com";
            employee.age = 20;
            todoService.Setup(_ => _.RegisterEmployee(employee));
            var sut = new EmployeeController(todoService.Object);

            /// Act
            var result = sut.AddEmployee(employee);
            // /// Assert
            todoService.Verify(_ => _.RegisterEmployee(employee), Times.Exactly(1));
        }
    }

}