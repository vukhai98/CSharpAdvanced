using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCsharp
{
    class MyGeneric <T>
    {
        private T[] items;
        public T[] Items
        {
            get { return items; }
        }
        public MyGeneric (int size)
        {
            items = new T[size];
        }
        public T GetByIndex(int index)
        {
            // Nếu Index vượt ra khỏi chỉ số phần tử của mảng thì nên ra ngoại lệ
            if (index < 0 || index >= items.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return items[index];
            }
        }
        public void SetItemValue(int index, T value)
        {
            if (index < 0 || index >= items.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                items[index] = value;
            }
        }
    }
}
