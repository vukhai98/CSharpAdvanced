using System;
using System.Collections;

namespace SortedListCsharp
{
     class PersonComparer : IComparer
    {
        /// <summary>
        /// định nghĩa 1 lớp thực thi interface Icomparer
        /// ovveride phương thức Comparer và định nghĩa sắp xếp trong đó 
        ///  chi tiết xem lại ArrayList
        /// </summary>
        public int Compare(object x, object y)
        {
            Person a = x as Person;
            Person b = y as Person;
            if (a == null || b == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                if(a.Age >b.Age)
                {
                    return 1;
                }
                else if(a.Age == b.Age)
                {
                    return 0;
                } 
                else
                {
                    return -1;
                }    
            }    
        }
    }
}