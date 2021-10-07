using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW1
{
    public class Starter
    {
        public void Run()
        {
            const int size = 10;
            var list = new CustomList<int>(size);
            for (var i = 0; i < size; i++)
            {
                list.Add(new Random().Next(1, 51));
            }

            bool remove = list.Remove(3);
            list.RemoveAt(8);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            int index = list.IndexOf(5);
            bool contains = list.Contains(2);

            list.AddRange(list);
            list.Sort();

            Console.WriteLine("=");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Clear();
        }
    }
}
