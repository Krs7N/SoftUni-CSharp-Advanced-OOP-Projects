using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
		private string model;
		private int capacity;
		private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
			this.model = model;
			this.capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

		public string Model
        {
			get { return model; }
			set { model = value; }
		}

        public int Capacity
		{
			get { return capacity; }
			set { capacity = value; }
		}

        public List<CPU> Multiprocessor
		{
			get { return multiprocessor; }
			set { multiprocessor = value; }
		}

        public int Count => multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (Capacity > Count)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU cpu = Multiprocessor.Find(c => c.Brand == brand);
            
            if (Multiprocessor.Contains(cpu))
            {
                Multiprocessor.Remove(cpu);
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            double mostPowerful = Multiprocessor.Max(c => c.Frequency);

            CPU powerfulCpu = Multiprocessor.Find(c => c.Frequency == mostPowerful);

            return powerfulCpu;
        }

        public CPU GetCPU(string brand) => Multiprocessor.Find(c => c.Brand == brand);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}