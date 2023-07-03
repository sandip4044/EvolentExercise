using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Repository.Exceptions
{
    public class EmployeeIdAlreadyExistException : ApplicationException
    {
        public EmployeeIdAlreadyExistException() { }
        public EmployeeIdAlreadyExistException(string message) : base(message) { }
    }
}
