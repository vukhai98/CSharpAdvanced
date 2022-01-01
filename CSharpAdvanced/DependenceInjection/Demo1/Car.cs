using System;
using System.Collections.Generic;
using System.Text;

namespace DependenceInjection.Demo1
{
    public class Car
    {
        // horn là một Dependecy của Car
        Horn Horn
        {
            set; get;
        }

        // Inject bằng phương thức khởi tạo
        // dependency Horn được đưa vào Car qua hàm khởi tạo
        public Car(Horn horn) => this.Horn = horn;
        public void Beep()
        {
            // Sử dụng Dependecy đã được Inject
            Horn.Beep();
        }
    }
}
