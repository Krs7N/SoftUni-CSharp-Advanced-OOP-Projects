namespace _03.Telephony
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;
    using Models;
    using Models.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ISmartphone smartphone = new Smartphone();
            IStationaryPhone stationaryPhone = new StationaryPhone();
            IEngine engine = new Engine(reader, writer, smartphone, stationaryPhone);
            engine.Run();
        }
    }
}
