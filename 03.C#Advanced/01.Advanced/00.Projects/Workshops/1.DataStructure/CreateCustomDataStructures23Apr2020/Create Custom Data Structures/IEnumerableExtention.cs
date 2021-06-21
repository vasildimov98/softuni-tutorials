using System;
using System.Collections.Generic;
using System.Text;

namespace Create_Custom_Data_Structures
{
    public static class IEnumerableExtention
    {
        public static MyList<T> ToMyList<T>(this IEnumerable<T> enumarable)
        {
            var list = new MyList<T>();

            foreach (var item in enumarable)
            {
                list.Add(item);
            }

            return list;
        }
    }
}
