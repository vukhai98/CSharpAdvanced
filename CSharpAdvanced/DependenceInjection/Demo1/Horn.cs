using System;
using System.Collections.Generic;
using System.Text;

namespace DependenceInjection.Demo1
{
    public class Horn
    {
        int level = 0; // độ lớn của còi 
        public Horn(int level) => this.level = level;
        public void Beep() => Console.WriteLine("Beep-Beep-Beep");
    }
}
