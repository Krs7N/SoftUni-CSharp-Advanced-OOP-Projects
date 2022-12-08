namespace _03.Telephony.Models
{
    using System.Linq;

    using Contracts;
    using Exceptions;

    public class StationaryPhone : IStationaryPhone
    {
        public string Call(string phoneNumber)
        {
            if (!IsPhoneNumberValid(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool IsPhoneNumberValid(string phoneNumber) => phoneNumber.All(char.IsDigit);
    }
}
