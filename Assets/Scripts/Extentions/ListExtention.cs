using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnityExtentions
{
    public static class ListExtensions
    {
        public static void BinaryInsert<T>(this List<T> list, T item, IComparer<T> comp)
        {
            int index = list.BinarySearch(item, comp);
            if (index < 0)
                index = ~index;

            list.Insert(index, item);
        }
        
        public static T GetItemByKey<T, T1>(this List<T> list, T1 item) where T : IComparable<T1>
        {
            int min = 0;
            int max = list.Count -1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                int compare = list[mid].CompareTo(item);
                if (compare == 0)
                {
                    return list[mid];
                }
                else if (compare < 0)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return default(T);
        }
    }
}