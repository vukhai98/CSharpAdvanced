using System;
using System.Text;

namespace EventChuanNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Student st = new Student();
            st.NameChanged += St_NameChanged;
            st.Name = " Thay đổi lần 1";
            st.Name = " Thay đổi lần 2";
            st.Name = " Thay đổi lần 3";
            Console.ReadKey();
            
        }

        private static void St_NameChanged(object sender, NameChangedEventArgs e)
        {
            Console.WriteLine("Tên có thay đổi."+e.Name);
        }
    }
    class Student
    {
        private string _name;
        public string Name
        {
            get => _name;
            set {
                _name = value;
                OnNameChanged(value);
            }

        }
        private event EventHandler<NameChangedEventArgs> _nameChanged;
        public event EventHandler<NameChangedEventArgs> NameChanged
        {
            add {
                _nameChanged += value;
            }
            remove {
                _nameChanged -= value;
            }
        }
        void OnNameChanged(string name)
        {
            if (_nameChanged != null)
            {
                _nameChanged(this, new NameChangedEventArgs(name));
            }
        }
            
    }
    public class NameChangedEventArgs : EventArgs
    {
        public string Name
        {
            get; set;
        }
        public NameChangedEventArgs(string name)
        {
            Name = name;
        }
    }
      

}
