using System;
using System.Collections.Generic;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private int age;

		public int Age
		{
			get { return age; }
			set { age = value; }
		}

		private string town;

		public string Town
		{
			get { return town; }
			set { town = value; }
		}

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);

            if (result != 0)
            {
                return result;
            }

            result = Age.CompareTo(other.Age);

            if (result != 0)
            {
                return result;
            }

            return Town.CompareTo(other.Town);
        }
    }
}