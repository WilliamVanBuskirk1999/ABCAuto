using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ValidationError
    {
        public ValidationError(string message)
        {
            Message = message;
        }
        public string Message { get; set; }

    }
}
