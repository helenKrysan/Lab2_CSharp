using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Krysan.Tools.Exception
{
    class FutureInputDateException : System.Exception
    {
        public FutureInputDateException()
        {
        }

        public FutureInputDateException(string message)
            : base(message)
        {
        }

        public FutureInputDateException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
