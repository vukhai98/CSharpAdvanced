using System;
using System.Collections.Generic;

namespace DictionaryInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // khởi tạo 1 Dictionary rỗng với Key và Value đều có kiểu dữ liệu là chuỗi.
            Dictionary<string, string> MyHash = new Dictionary<string, string>();
            /* 
             * khởi tạo 1 Dictionary với Key và Value có kiểu chuỗi 
             * đồng thời chỉ định Capacity ban đầu là 5
             */
            Dictionary<string, string> MyDic2 = new Dictionary<string, string>(5);
            /*
             * Khởi tạo 1 Dictionary có kích thước bằng với MyDic2.
             * Sao chép toàn độ phần tử trong MyDic2 vào MyDic3.
             */
            Dictionary<string, string> MyDic3 = new Dictionary<string, string>(MyDic2);
            // Tạo 1 Dictionary đơn giản và thêm vào 3 phần tử.
            Dictionary<string, string> MyDic4 = new Dictionary<string, string>();
            MyDic4.Add("FE", "Free Education");
            MyDic4.Add("K", "Kteam");
            MyDic4.Add("HK", "HowKteam");

            /* 
             * Duyệt qua các phần tử trong Dictionary.
             * Vì mỗi phần tử là 1 KeyValuePair nên ta chỉ định kiểu dữ liệu cho item là KeyValuePair luôn.
             * Thử in ra màn hình cặp Key - Value của mỗi phần tử được duyệt.
             */
            foreach (KeyValuePair<string, string> item in MyDic4)
            {
                Console.WriteLine(item.Key + "\t" + item.Value);
            }


        }
    }
}
