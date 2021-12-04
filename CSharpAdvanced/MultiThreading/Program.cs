using System;
using System.Threading;
namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread t = new Thread(()=> {
            //    DemoThread("Thread 1");
            //});
            //t.Start();
            //Thread t1 = new Thread(() => {
            //    DemoThread("Thread 2");
            //});
            //t1.Start();
            //Thread t2 = new Thread(() => {
            //    DemoThread("Thread 3");
            //});
            //t2.Start();
            for (int i = 0; i < 5; i++)
            {
                var valueStemp = i;
                Thread t = new Thread(() => {
                    DemoThread("Thread " + valueStemp);
                    
                });


                t.IsBackground = true;

                t.Start();
            }





            Console.ReadKey();
        }
        static void DemoThread(string threadIndex)
        {
            for (int i = 0; i < 5; i++)
            {
              
                //Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine(threadIndex + "-" + i);
            }
        }
    }
}
