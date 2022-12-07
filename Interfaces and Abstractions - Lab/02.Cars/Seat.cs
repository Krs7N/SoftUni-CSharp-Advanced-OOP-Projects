namespace Cars
{
    using System;

    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; }

        public string Color { get; }

        public string Start() => "Engine start";


        public string Stop() => "Breaaak!";

        public override string ToString()
        {
            return $"{this.Color} {nameof(Seat)} {this.Model}"
                   + Environment.NewLine + $"{this.Start()}" + Environment.NewLine + $"{this.Stop()}";
        }
    }
}