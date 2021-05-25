using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Exceptions
{
    public class WrongNameException : Exception
    {
        public string Name { get; set; }
        public WrongNameException(string name)
        {
            Name = name;
        }

        public WrongNameException(string message, string name) : base(message)
        {
            Name = name;
        }

        public WrongNameException(string message, Exception innerException, string name) : base(message, innerException)
        {
            Name = name;
        }
    }
}
