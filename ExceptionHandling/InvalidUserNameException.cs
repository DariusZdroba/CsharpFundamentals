using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class InvalidUserNameException : Exception
    {
        public InvalidUserNameException() { }
        public InvalidUserNameException(string name) : base(String.Format("Invalid Student Name: {0}",name)) { 
        }
    }
}
