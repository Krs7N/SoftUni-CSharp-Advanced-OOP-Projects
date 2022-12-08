namespace _03.Telephony.Exceptions
{
    using System;

    public class InvalidPhoneNumberException : Exception
    {
        public const string InvalidPhoneNumber = "Invalid number!";

        public InvalidPhoneNumberException() : base(InvalidPhoneNumber)
        {
            
        }

        public InvalidPhoneNumberException(string message) : base(message)
        {
            
        }
    }
}