using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Repository.Exceptions
{
    public class EmployeeNotCreatedException : ApplicationException
    {
        public EmployeeNotCreatedException() { }
        public EmployeeNotCreatedException(string message) : base(message) { }
    }
}
