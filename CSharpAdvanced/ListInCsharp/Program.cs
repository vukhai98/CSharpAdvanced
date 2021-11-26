using System;
using System.Collections.Generic;

namespace ListInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Khai báo vào khởi tạo List
            // Khởi tạo 1 list rỗng .
            List<int> myList = new List<int>();
            // Khởi tạo 1 list có sức chứa ban đầu là 5 phần tử
            List<int> myList2 = new List<int>(5);
            // khỏi tạo 1 list  sao chép phần tử của myList2
            List<int> myList3 = new List<int>(myList2);
            #endregion 
            // tạo ra 1 list kiểu stirng và thêm 2 phần tử vào list
            List<string> myList4 = new List<string>();
            myList4.Add("Ktem");
            myList4.Add("Free Education");
            Console.WriteLine("List sau khi insert");
            Console.WriteLine("So luong phan tu cua List la: {0}", myList4.Count);
            foreach (string item in myList4)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
            // thêm 1 phần How vào  đầu list 
            myList4.Insert(0, "How");
            Console.WriteLine("So luong phan tu cua List la: {0}", myList4.Count);
            foreach (string item in myList4)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
            //kiểm tra 1 phần tử có thuộc list không

            bool isExists = myList4.Contains("Vu Minh Khai");
            if (isExists )
            {
                Console.WriteLine("Phan tu ton  tai trong List");
            }
            else
            {
                Console.WriteLine("Phan tu ton khong tai trong list");

            }
        }
    }
}
