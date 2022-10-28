namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(300, 100);
            sportCar.Drive(10);
        }
    }
}