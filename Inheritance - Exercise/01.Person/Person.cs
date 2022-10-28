using System.Text;

namespace Person
{
    public class Person
    {
		private int age;
		private string name;

        public Person(string name, int age)
        {
            Name = name;
			Age = age;
        }

		public int Age
		{
			get { return age; }
			set { age = value; }
		}

        public string Name
		{
			get { return name; }
			set { name = value; }
		}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Age: {Age}");

            return sb.ToString().Trim();
        }
    }
}
