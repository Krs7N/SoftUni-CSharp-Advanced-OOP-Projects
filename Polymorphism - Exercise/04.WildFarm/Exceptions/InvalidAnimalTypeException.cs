using System;

namespace _04.WildFarm.Exceptions
{
    public class InvalidAnimalTypeException : Exception
    {
        private const string DefaultMessage = "Invalid animal type!";

        public InvalidAnimalTypeException() : base(DefaultMessage)
        {
            
        }

        public InvalidAnimalTypeException(string message) : base(message)
        {
            
        }
    }
}