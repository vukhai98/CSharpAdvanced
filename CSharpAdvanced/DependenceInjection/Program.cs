using System;
using DependenceInjection.Demo1;
using DependenceInjection.Demo2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DependenceInjection
{
    /// <summary>
    /// Dependency injection 
    /// Dependency - phụ thuộc 
    /// solid principles
    /// https://toidicodedao.com/2015/03/24/solid-la-gi-ap-dung-cac-nguyen-ly-solid-de-tro-thanh-lap-trinh-vien-code-cung/
    /// </summary>
    #region Dependency 
    //class ClassA
    //{
    //    public void ActionA() => Console.WriteLine("Action in ClassA");
    //}
    //class ClassB
    //{
    //    public void ActionB()
    //    {
    //        Console.WriteLine("Action in ClassB");
    //        var a = new ClassA();
    //        a.ActionA();
    //    }
    //}
    #endregion

    #region Depedency Injection
    public interface IClassB
    {
        public void ActionB();
    }
    public interface IClassC
    {
        public void ActionC();
    }
    public class ClassC : IClassC
    {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    public class ClassB : IClassB
    {
        // Phụ thuộc của ClassB là ClassC
        IClassC c_dependency;

        public ClassB(IClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    public class ClassA
    {
        // Phụ thuộc của ClassA là ClassB
        IClassB b_dependency;

        public ClassA(IClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }

    }
    public class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC()
        {
            Console.WriteLine("Action in C1");
        }
    }

    public class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in B1");
            c_dependency.ActionC();
        }
    }
    public class ClassB2 : IClassB
    {
        IClassC c_dependency;
        string message;
        public ClassB2(IClassC classc, string mgs)
        {
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB2 is created");
        }
        public void ActionB()
        {
            Console.WriteLine(message);
            c_dependency.ActionC();
        }
    }
    #endregion

  
    class Program
    {

        static void Main(string[] args)
        {
            //DemoP1.Init();
            DemoP2.Init();
      
        }


    }
}