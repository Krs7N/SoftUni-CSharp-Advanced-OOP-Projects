using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        public Box()
        {
            Sentences = new List<T>();
        }

        public List<T> Sentences { get; set; }

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
