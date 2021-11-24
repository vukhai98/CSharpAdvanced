using System;
using System.Collections;

namespace CollectionsStack
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Khai báo  và khởi tạo Stack
            Stack myStack = new Stack(); // khởi tạo 1 stack rỗng.
            Stack myStack2 = new Stack(5); // Khởi tạo 1 stack có sức chứa ban đầu là  5.
            // khởi tạo 1 mảng bất kì
            ArrayList myArray = new ArrayList();
            myArray.Add(5);
            myArray.Add(9);
            myArray.Add(10);
            // khởi tạo 1 Stack và sao chép giá trị của các phần tử từ myArr vào stack
            Stack myStack3 = new Stack(myArray);

            #endregion
            #region Sử dụng Stack
            // Create 1 Stack name: myStack4 và rỗng
            Stack myStack4 = new Stack();
            // thêm phần thử vào stack qua  Push
            myStack4.Push("Free Education");
            myStack4.Push("Kteam");
            myStack4.Push("How");
            // thử in các phương thức của Stack
            Console.WriteLine("So phan tu hien tai cua Stack la: {0}", myStack4.Count);
            // thử xem giá trị của phần tử cuối cùng trong stack mà không xóa nó khởi stack
            Console.WriteLine("Phan tu dau  cua Stack la : {0}", myStack4.Peek());
            // lấy các phần tử trong stack và xóa chúng khỏi stack ;
            Console.WriteLine("Popping.....");
            int length = myStack4.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(myStack4.Pop());
            }
            // kiểm tra số phần tử hiện tại trong Stack
            Console.ReadLine();

            #endregion
        }
    }
}
