using System;
using System.Text;

namespace Delegate
{
    class Program
    {
        delegate int myDelegate(string s);

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            myDelegate showString = new myDelegate(ShowString);
            NhapVaShowTen(showString);

            //myDelegate convertToInt = new myDelegate(ConvertStringToInt);
            //myDelegate showString = new myDelegate(ShowString);
            //myDelegate multiCast = convertToInt + showString;
            //string numberSTR = "35";
            //int valueConverted = convertToInt(numberSTR);
            //Console.WriteLine("Giá trị đã convert thành int:" + valueConverted);
            //Console.WriteLine("Kết quả khi gọi multicast delegate");
            //multiCast(numberSTR);
            //multiCast -= showString; 
            //Console.ReadLine();
        }
        static void NhapVaShowTen(myDelegate showTen)
        {
            Console.WriteLine("Mời nhập tên của bạn :");
            string ten = Console.ReadLine();
            showTen(ten);
        }
        static int ConvertStringToInt(string stringValue)
        {
            int valueInt = 0;
            Int32.TryParse(stringValue, out valueInt);
            Console.WriteLine("Đã ép kiểu thành công ");
            return valueInt;
        }
        static int ShowString(string stringValue)
        {
            Console.WriteLine(stringValue);
            return 0;
        }
    }
}
