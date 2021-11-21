using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayListCollection
{
    class Person
    {
        private string name;
        private int age;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        // Tạo ra 1 constructor có tham số mặc định để tiện cho việc khởi tạo nhanh đối tượng Person với tham số cho sẵn
        public Person(string Name , int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        // Override phương thức ToString để khi cần có thể in thông tin của object ra nhanh chóng
        public override string ToString()
        {
            return "Name :" + name + "| Age: " + age;
        }


    }
}
