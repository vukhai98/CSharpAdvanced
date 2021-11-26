using System;
using System.Collections;

namespace BitArrayCs
{
    class Program
    {

        public void PrinBits(BitArray myBA, int Width)
        {
            int i = Width;
            foreach (bool item in myBA)
            {
                if (i < 1)
                {
                    i = Width;
                    Console.WriteLine();
                }
                i--;
                Console.WriteLine(item.GetHashCode());// in ra 0 và 1 thay vì true or false

            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            #region
            // khởi tạo bitarray có 10 phần tử 
            // mỗi phần tử có giá trị mặc định là  0(false)
            BitArray myBA = new BitArray(10);
            //khởi tạo bitarray có 10 phần tử 
            // mỗi phần tử có giá trị mặc định là 1 (true)
            BitArray bitArray2 = new BitArray(10, true);
            /*
             * Có thể khởi tạo 1 bitarray từ 1 mảng bool có sẵn
             */
            bool[] myBools = new bool[5] { true, false, true, true, false };
            BitArray myBA3 = new BitArray(myBools);
            // khởi tạo 1 bittaray từ 1 mảng  byte có sẵn
            byte[] myByte = new byte[5] { 1, 2, 3, 4, 5 };
            BitArray myBA4 = new BitArray(myByte);
            Console.WriteLine("So bit của mảng Bitarray là {0}", myBA4.Length);
          
                #endregion



        }


    }
}
