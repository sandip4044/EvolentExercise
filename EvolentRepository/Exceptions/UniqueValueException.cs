using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Repository.Exceptions
{
    public class UniqueValueException : ApplicationException
    {
        public UniqueValueException() { }
        public UniqueValueException(string message) : base(message) { }
    }
}
