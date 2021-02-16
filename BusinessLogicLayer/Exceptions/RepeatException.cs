using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Exceptions
{
    public class RepeatException : Exception
    {
        public string Property { get; private set; }
        public bool Confirm { get; set; }
        public RepeatException(string message, string prop, bool confirm) : base(message)
        {
            Property = prop;
            Confirm = confirm;
        }
    }
}
