using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella2015.Helpers
{
    public class CellaValidationMessage
    {
        private bool isValid;
        private string message;

        public CellaValidationMessage()
        {
            isValid = true;
            message = string.Empty;
        }

        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
