namespace Person
{
    public class Child : Person
    {
        private int age;

        public Child(string name, int age) : base(name, age) { }

        public override int Age
        {
            get => age;
            set
            {
                if (value > 0 && value <= 15)
                {
                    age = value;
                }
            }
        }
    }
}
