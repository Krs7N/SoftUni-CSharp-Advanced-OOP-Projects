namespace _03.Telephony.Exceptions
{
    using System;

    public class InvalidWebsiteURL : Exception
    {
        public const string InvalidWebsite = "Invalid URL!";

        public InvalidWebsiteURL() : base(InvalidWebsite)
        {
            
        }

        public InvalidWebsiteURL(string message) : base(message)
        {
            
        }
    }
}