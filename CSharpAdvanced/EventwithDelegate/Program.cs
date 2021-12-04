using System;
using System.Text;

namespace EventwithDelegate
{
    delegate void UpdateHandler(string name);
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Student st = new Student();
           
            st.NameChanged += St_NameChanged;
            st.Name = "Kteam";
            Console.WriteLine("Tên từ class:" + st.Name);
            st.Name = " HowKteam ";
            Console.WriteLine("Tên từ class:" + st.Name);
            Console.ReadLine();
        }

        private static void St_NameChanged(string name)
        {
            Console.WriteLine("Tên mới: " + name);
        }
    }
    class Student
    {
        public event UpdateHandler NameChanged; 
        private string name;
        public string Name
        {
            get => name;
            set {
                name = value;
                if (NameChanged != null)
                {
                    NameChanged(Name);  
                }    
            }
        }
    }
}
