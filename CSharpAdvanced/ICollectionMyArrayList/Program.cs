using System;
using System.Collections;

namespace ICollectionMyArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class MyArrayList : ICollection
    {
        private object[] listObj;// mảng giá trị
        private int count; // số lượng phần tử 
        private int maxCount = 100; //số lượng phần tử tối đa
        public MyArrayList()
        {
            count = -1;
            listObj = new object[maxCount];
        }
        public MyArrayList(int count)
        {
            this.count = count;
            listObj = new object[count];
        }
        public MyArrayList(Array array)
        {
            array.CopyTo(listObj, 0);
            count = array.Length;
        
        }

        public int Count
        {
            get {
                return count;
            }
        }

        public bool IsSynchronized
        {
            get {
                throw new NotImplementedException();
            }
        }

        public object SyncRoot
        {
            get {
                throw new NotImplementedException();
            }
        }

        public void CopyTo(Array array, int Index)
        {
            // thực hiện coppy các phần tử trpmg listobj từ vị trí Index đến cuối sang mảng array
            listObj.CopyTo(array, Index);

        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
