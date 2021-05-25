using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Exceptions
{
    public class WrongValueException : Exception
    {
        public double Value { get; set; }
        public WrongValueException(double value)
        {
            Value = value;
        }

        public WrongValueException(string message, double value) : base(message)
        {
            Value = value;
        }

        public WrongValueException(string message, Exception innerException, double value) : base(message, innerException)
        {
            Value = value;
        }
    }
}
