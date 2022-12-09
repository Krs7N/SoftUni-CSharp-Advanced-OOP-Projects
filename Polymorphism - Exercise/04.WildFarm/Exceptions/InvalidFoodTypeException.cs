using System;

namespace _04.WildFarm.Exceptions
{
    public class InvalidFoodTypeException : Exception
    {
        public const string Defaultmessage = "Invalid food type!";

        public InvalidFoodTypeException() : base(Defaultmessage)
        {
            
        }

        public InvalidFoodTypeException(string message) : base(message)
        {
            
        }
    }
}