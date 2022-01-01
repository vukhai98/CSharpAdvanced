using System;
using System.Collections.Generic;
using System.Text;

namespace DependenceInjection.Demo1
{
    public static class DemoP1
    {
        public static void Init()
        {

            IClassC objectC = new ClassC1(); //new ClassC();
            IClassB objectB = new ClassB1(objectC);
            ClassA objectA = new ClassA(objectB);

            var b = new ClassB(objectC);
            b.ActionB();


            objectA.ActionA();
            Horn horn = new Horn(3);
            Car car = new Car(horn);
            car.Beep();
        }
    }
}
