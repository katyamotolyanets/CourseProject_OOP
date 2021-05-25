using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Exceptions
{
    public class WrongAgeException : Exception
    {
        public int Age { get; set; }
        public WrongAgeException(int age)
        {
            Age = age;
        }

        public WrongAgeException(string message, int age) : base(message)
        {
            Age = age;
        }

        public WrongAgeException(string message, Exception innerException, int age) : base(message, innerException)
        {
            Age = age;
        }
    }
}
