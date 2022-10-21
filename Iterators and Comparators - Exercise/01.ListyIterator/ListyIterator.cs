using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    internal class ListyIterator<T>
    {
        private int index;
        private List<T> items;

        public ListyIterator(List<T> items)
        {
            this.items = items;
        }

        public bool Move()
        {
            if (index + 1 < items.Count)
            {
                index++;

                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return index < items.Count - 1;
        }

        public void Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(items[index]);
        }
    }
}