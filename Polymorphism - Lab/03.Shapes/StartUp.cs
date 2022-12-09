namespace Shapes
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(2);
            Shape rectangle = new Rectangle(3, 5);

            Console.WriteLine(circle.Draw()); 
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
        }
    }
}
