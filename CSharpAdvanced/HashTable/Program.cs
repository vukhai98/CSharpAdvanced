using System;
using System.Collections;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // tạo một Hashtable đơn giản với 3 phần tử
            Hashtable hash = new Hashtable();
            hash.Add("K", "Kteam");
            hash.Add("H", "HowKteam");
            hash.Add("FE", "Free Education");
            /*
             * Duyệt qua các phần tử trong Hashtable.
             * Vì mỗi phần tử là 1 DictionaryEntry nên ta chỉ định kiểu dữ liệu cho item là DictionaryEntry luôn.
             * Thử in ra màn hình cặp Key _ value của mỗi phần tử được duyệt.
             */
            //foreach(DictionaryEntry item in hash)
            //{
            //    Console.WriteLine(item.Key + "\t" + item.Value);
            //}
            // In ra màn hình giá trị Value trong 1 Key không tồn tại.
            Console.WriteLine(hash["VT"]);
            // Để chắc chắn là null ta thử kiểm ta bằng điều kiện If
            if (hash["VT"] == null)
            {
                Console.WriteLine("Key 'VT' is not exists");
            }
            // Thử in ra số phần tử ban đầu của Hashtable
            Console.WriteLine("\nCount: " + hash.Count);
            foreach (DictionaryEntry item in hash)
            {
                Console.WriteLine(item.Key + "\t" + item.Value);
            }
            // thực hiện gán giá trị cho 1 Key không tồn tại
            hash["Kt"] = "Kter";
            // thự thiên in lại số phần tử của Hashtable để thấy sự khác biệt.
            Console.WriteLine("\nCount: " + hash.Count);
            foreach (DictionaryEntry item in hash)
            {
                Console.WriteLine(item.Key + "\t" + item.Value);
            }
            Console.ReadKey();
        }
    }
}
