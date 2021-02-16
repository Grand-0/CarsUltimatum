using System;

namespace BusinessLogicLayer.Exceptions
{
    public class ValidationException : Exception
    {
        public string Property { get; private set; }
        public ValidationException(string message,string prop) : base(message) 
        {
            Property = prop;
        }
    }
}
