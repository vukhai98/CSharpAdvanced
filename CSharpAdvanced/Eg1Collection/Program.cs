using ArrayListCollection;
using System;
using System.Collections;

namespace Eg1Collection
{
    #region Sắp xếp 1 danh sách object trong ArrayList
    class Program
    {
        static void Main(string[] args)
        {
            // Tạo 1 danh sách kiểu ArrayList rỗng
            ArrayList arrPersons = new ArrayList();
            // thêm 3 Person vào danh sách 
            arrPersons.Add(new Person("Nguyen Van A", 18));
            arrPersons.Add(new Person("Nguyen Van B", 25));
            arrPersons.Add(new Person("Nguyen Van A", 20));
            // In thử danh sách Person ban đầu ra.
            Console.WriteLine("Danh sach ban dau: ");
            foreach (Person item in arrPersons)
            {
                Console.WriteLine(item.ToString());
            }
            /*
             * Thực hiện sắp xếp danh sách Person theo tiêu chí đã được định nghĩa
             * Trong phương thức Compare cửa lớp SortPerson(tuổi tăng dần)
             */
            arrPersons.Sort(new SortPersons());
            // In ra màn mình danh sắp xếp
            Console.WriteLine();
            Console.WriteLine("Danh sach Person da duoc sap xep theo tuoi tang dan : ");
            foreach (Person item in arrPersons)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();

        }
        public class SortPersons : IComparer
        {
            
            public int Compare(object x, object y)
            {
                // ép kiểu  2 object truyền vào về Parson
                Person p1 = x as Person;
                Person p2 = y as Person;
                /*
                 * Vì có thể 2 object truyền vào không phải Person thì khi đó ta không thể so sánh được.
                 * Trường hợp tốt nhất ta nên ném ra lỗi cho lập trình viên sửa chữa.
                 * 
                 */
                if (p1 == null || p2 == null)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    /*
                     * ta so sánh và trả về giá trị 1 0 -1 tương ứng lớn hơn, bằng , nhỏ hơn.
                     */
                    if (p1.Age < p2.Age)
                    {
                        return 1;
                    }
                    else if (p1.Age == p2.Age)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                
            }
        }
    }

    #endregion
}
