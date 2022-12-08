namespace _03.Telephony.Core
{
    using System;

    using Contracts;
    using Exceptions;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ISmartphone smartphone;
        private readonly IStationaryPhone stationaryPhone;

        public Engine(IReader reader, IWriter writer, ISmartphone smartphone, IStationaryPhone stationaryPhone)
        {
            this.reader = reader;
            this.writer = writer;
            this.smartphone = smartphone;
            this.stationaryPhone = stationaryPhone;
        }

        public void Run()
        {
            try
            {
                string[] phoneNumbers = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] browsedWebsites = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var phoneNumber in phoneNumbers)
                {
                    if (phoneNumber.Length == 10)
                    {
                        this.writer.WriteLine(this.smartphone.Call(phoneNumber));
                    }
                    else if (phoneNumber.Length == 7)
                    {
                        this.writer.WriteLine(this.stationaryPhone.Call(phoneNumber));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberException();
                    }
                }

                foreach (var browsedWebsite in browsedWebsites)
                {
                    this.writer.WriteLine(this.smartphone.Browse(browsedWebsite));
                }
            }
            catch (InvalidPhoneNumberException ipne)
            {
                this.writer.WriteLine(ipne.Message);
            }
            catch (InvalidWebsiteURL iwe)
            {
                this.writer.WriteLine(iwe.Message);
            }
        }
    }
}