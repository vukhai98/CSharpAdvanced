using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayListCollection
{
    class Person
    {
        public Person()
        {

        }
        private string name;
        private int age;
        public int abc { set; get; }
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
        public Person(string _name , int _age)
        {
            this.Name = _name;
            this.Age = _age;
        }
        // Override phương thức ToString để khi cần có thể in thông tin của object ra nhanh chóng
        public override string ToString()
        {
            return "Name :" + name + "| Age: " + age;
        }

       
    }
}
