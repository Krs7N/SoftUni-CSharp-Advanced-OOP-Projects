using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        public Box()
        {
            Sentences = new List<T>();
        }

        public List<T> Sentences { get; set; }

        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = Sentences[firstIndex];
            Sentences[firstIndex] = Sentences[secondIndex];
            Sentences[secondIndex] = temp;
        }

        public int Count(T itemToCompare)
        {
            int count = 0;

            foreach (var item in Sentences)
            {
                if (item.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var sentence in Sentences)
            {
                sb.AppendLine($"{typeof(T)}: {sentence}");
            }

            return sb.ToString().Trim();
        }
    }
}