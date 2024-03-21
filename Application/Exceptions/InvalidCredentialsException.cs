using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Exceptions
{
    public class InvalidCredentialsException : ApplicationException
    {
        public InvalidCredentialsException(string message) : base(message)
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
    }
}
