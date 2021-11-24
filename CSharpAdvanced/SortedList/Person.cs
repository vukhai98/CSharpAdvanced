using System;
using System.Collections.Generic;
using System.Text;

namespace SortedListCsharp
{
    class Person
    {
        
        public int abc { set; get; }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public Person()
        {

        }

        // Tạo ra 1 constructor có tham số mặc định để tiện cho việc khởi tạo nhanh đối tượng Person với tham số cho sẵn
        public Person(string _name, int _age)
        {
            this.Name = _name;
            this.Age = _age;
        }
        // Override phương thức ToString để khi cần có thể in thông tin của object ra nhanh chóng
        public override string ToString()
        {
            return name + "-" +  age;
        }
    }
}
