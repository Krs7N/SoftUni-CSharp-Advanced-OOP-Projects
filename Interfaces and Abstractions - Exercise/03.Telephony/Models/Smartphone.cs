namespace _03.Telephony.Models
{
    using System.Linq;

    using Contracts;
    using Exceptions;

    public class Smartphone : ISmartphone
    {
        public string Call(string phoneNumber)
        {
            if (!IsPhoneNumberValid(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }

        public string Browse(string websiteURL)
        {
            if (!IsURLValid(websiteURL))
            {
                throw new InvalidWebsiteURL();
            }

            return $"Browsing: {websiteURL}!";
        }

        private bool IsPhoneNumberValid(string phoneNumber) => phoneNumber.All(char.IsDigit);

        private bool IsURLValid(string websiteURL) => !websiteURL.Any(char.IsDigit);
    }
}