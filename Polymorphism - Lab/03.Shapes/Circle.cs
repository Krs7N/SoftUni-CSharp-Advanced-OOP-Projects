namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculatePerimeter() => Math.PI * (radius * 2);

        public override double CalculateArea() => Math.PI * (radius * radius);

        public override string Draw() => $"Drawing {nameof(Circle)}";
    }
}