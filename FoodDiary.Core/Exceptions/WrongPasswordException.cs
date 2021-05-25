using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public string Password { get; set; }
        public WrongPasswordException(string pass)
        {
            Password = pass;
        }

        public WrongPasswordException(string message, string pass) : base(message)
        {
            Password = pass;
        }

        public WrongPasswordException(string message, Exception innerException, string pass) : base(message, innerException)
        {
            Password = pass;
        }
    }
}
