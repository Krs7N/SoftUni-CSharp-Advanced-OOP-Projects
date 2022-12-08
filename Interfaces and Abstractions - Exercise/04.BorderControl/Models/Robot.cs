namespace _04.BorderControl.Models
{
    using Contracts;
    public class Robot : IRobot
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; }

        public string Id { get; }
    }
}