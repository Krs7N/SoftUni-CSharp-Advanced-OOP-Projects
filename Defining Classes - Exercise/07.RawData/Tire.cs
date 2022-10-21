using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Tire
    {
		private double pressure;

		private int age;

        public Tire(double tirePressure, int tireAge)
        {
            Pressure = tirePressure;
			Age = tireAge;
        }

		public double Pressure
		{
			get { return pressure; }
			set { pressure = value; }
		}

        public int Age
		{
			get { return age; }
			set { age = value; }
		}
    }
}
