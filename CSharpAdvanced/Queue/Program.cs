using System;
using System.Collections;

namespace QueueCs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue myQueue = new Queue(); // tạo 1 quêu rỗng
            Queue myQueue2 = new Queue(5); //Create 1 queue có Capacity is five.
            // khởi tạo  mảng bất kì 
            ArrayList myArray = new ArrayList();
            myArray.Add(5);
            myArray.Add(9);
            myArray.Add(10);

            // khởi tạo 1 queue  vào sao chép phần tử từ myArray vào Queue 
            Queue myQueue3 = new Queue(myArray);
            myQueue.Enqueue("Vu Minh Khai");
            myQueue.Enqueue("23 years old");
            myQueue.Enqueue("Nam Dinh");
            // đếm số phần tử của Queue 
            Console.WriteLine("So phan tu hien tai cua Queue la: {0}", myQueue.Count);
            // lấy ra phần tử đầu tiên của Queue mà không xóa khỏi Queue
            Console.WriteLine("Phan tu dau tien cua Queue la: {0} ", myQueue.Peek());
            // lấy các phần tử ra khỏi Queue và đồng thời xóa khỏi Queue .
            Console.WriteLine("Dequeuing.........");
            int length=myQueue.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(myQueue.Dequeue());
            }
         
            Console.WriteLine("So phan tu hien tai cua Queue la:{0}", myQueue.Count);
            Console.ReadLine();
        }
    }
}
