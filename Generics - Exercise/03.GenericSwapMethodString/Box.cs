using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    public class Box<T>
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