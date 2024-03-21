using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ActionNotPerfomedException : ApplicationException
    {

        public ActionNotPerfomedException(string message) : base(message)
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
    }
}
