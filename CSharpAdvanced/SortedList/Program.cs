using System;
using System.Collections;
namespace SortedListCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 
            SortedList mySL = new SortedList(); // khởi tạo 1 Sorted List rỗng.
            SortedList mySL2 = new SortedList(5); // khởi tại 1 Sorted List và chỉ định Capacity ban đầu là 5.
            /*
             * Create one new SortedList có kích thước bằng thằng mysl2.
             * sao chép toàn bộ phần tử  trong mysl2 vào mySL3
             */
            SortedList mySL3 = new SortedList(mySL2);
            /*
             * Mình định nghĩa 1 lớp PersonComparer có thực thi 1 inter face IComparer
             * Sau đó ovverride lại phương thức Compare.
             * Sử dụng  lớp trên để truyền vào  constructor của SortedList.
             */
            SortedList mySL4 = new SortedList(new PersonComparer());
            /*
             * tạo 1 sortedList mới và sao chép các phần tử từ mySL3 đồng thời sắp xếp các phần tử lại
             * theo cacsch sắp xếp được định nghĩa trong PersonComparer.
             */
            SortedList mySL5 = new SortedList(mySL3, new PersonComparer());

            SortedList mySL6 = new SortedList(new PersonComparer());
            mySL6.Add(new Person("Vu Minh Khai", 23), 7);
            mySL6.Add(new Person("Vu Van Huy", 25), 18);

            foreach (DictionaryEntry item in mySL6)
            {
                Console.WriteLine("Key: " + item.Key + "\tValue: " + item.Value);
            }
            Console.ReadLine();
            #endregion
        }
    }
}
