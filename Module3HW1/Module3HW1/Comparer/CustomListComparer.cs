using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW1.Comparer
{
    public class CustomListComparer<T> : IComparer<T>
    {
        public int Compare(T first, T second)
        {
            if (first.GetHashCode() > second.GetHashCode())
            {
                return 1;
            }
            else if (first.GetHashCode() == second.GetHashCode())
            {
                return 0;
            }

            return -1;
        }
    }
}
