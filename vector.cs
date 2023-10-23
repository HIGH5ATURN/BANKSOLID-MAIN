using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class vector<T>
    {
        private T[] items;
        private int count;
        private int capacity;

        public vector()
        {
            capacity = 4;
            items = new T[capacity];
            count = 0;
        }

        public int Count { get { return count; } }

        public void Add(T item)
        {
            if (count == capacity)
            {

                capacity *= 2;
                T[] newItems = new T[capacity];

                //Array.Copy(items, newItems, count);

                for (int i = 0; i < count; i++)
                {
                    newItems[i] = items[i];
                }

                items = newItems;
            }
            items[count] = item;
            count++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException();
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException();
                items[index] = value;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            count--;
        }

        public void Clear()
        {

            count = 0;
            capacity = 4;

        }
    }
}
