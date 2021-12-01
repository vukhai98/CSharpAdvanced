using System;

namespace TypeTuple
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Khởi tạo 1 tuple 
            //var myTuple = Tuple.Create<int, string>(1, "HowKteam"); // Cách 1 khởi tạo một tuple 
            //var myTuple2 = new Tuple<int, string>(2, "Kteam");// cách 2 khởi tạo 1 tuple
            //Console.WriteLine("ID:{0} Name:{1} ", myTuple2.Item1, myTuple2.Item2);
            //Console.ReadKey();
            #endregion
            #region Example1
            /*
             * Mình dùng  var để C# tự nhận kiểu dữ liệu.
             * Bạn có thể khai báo tường minh kiểu dữ liệu là Tuple<int,int,int>
             */
            var now = GetCurrentDayMonthYear();
            Console.WriteLine("Day: {0},Month: {1},Year: {2}", now.Item1, now.Item2, now.Item3);
            Console.WriteLine(now.ToString());
            Console.ReadKey();
            #endregion
        }// phương thức trả về 1 Tuple có 3 thuộc tính(Cả 3 đều có kiểu dữ liệu là int)
        static Tuple<int, int, int> GetCurrentDayMonthYear()
        {
            // hàm lấy ngày giờ hiện tại của hệ thốnh

            DateTime now = DateTime.Now;
            // Sử dụng Constructor của Tuple<> để trả về hoặc có thể sử dụng phương thứ Creat đã trình bày ở trên
            return new Tuple<int, int, int>(now.Day, now.Month, now.Year);
        }



    }
}
