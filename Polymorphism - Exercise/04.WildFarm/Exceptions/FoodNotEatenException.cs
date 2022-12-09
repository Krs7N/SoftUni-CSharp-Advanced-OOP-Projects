using System;

namespace _04.WildFarm.Exceptions
{
    public class FoodNotEatenException : Exception
    {
        public FoodNotEatenException(string message) : base(message)
        {
            
        }
    }
}