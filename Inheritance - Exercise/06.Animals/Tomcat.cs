namespace Animals
{
    public class Tomcat : Cat
    {
        private const string GENDER = "male";

        public Tomcat(string name, int age) : base(name, age, GENDER)
        {
        }

        public override string ProduceSound() => "MEOW";
    }
}