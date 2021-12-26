using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchornous
{
    class Program
    {
        static void DoSomeThing(int seconds, string mgs, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10}....Start");
                Console.ResetColor();
            }
        

            for (int i = 0; i <= seconds; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mgs,10} {i,2}");
                    Console.ResetColor();
                }

                Thread.Sleep(1000);
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10}....End");
                Console.ResetColor();
            }
        }
        static async Task Task2()
        {
            Task task2 = new Task(
                () => { DoSomeThing(10, "Task2:", ConsoleColor.Green); }
                );//()=>{}
            task2.Start();
            await task2;
            Console.WriteLine($"Task2 is success");
        }
        static async Task Task3()
        {
            Task task3 = new Task(
               (object ob) => {
                   string str_Name = (string)ob;
                   DoSomeThing(6, "Task3:", ConsoleColor.Yellow);
               }
               , "Task 3"); // (Objet ob) => {}
            task3.Start();
            await task3;
            Console.WriteLine($"Task3 is success");     

        }
        static async Task<string> Task4()
        {
            Task<string> task4 = new Task<string>(
                () => {
                    DoSomeThing(10, "Task4", ConsoleColor.Blue);
                    return "Return from Task4";
                }); // () =>{return string;}
            task4.Start();
            var result_Task4 = await task4;
            Console.WriteLine("Task is successs");
            return result_Task4;
        }
        static async Task<string> Task5()
        {
            Task<string> task5 = new Task<string>(
                (object ob) => {
                    string t = (string)ob;
                    DoSomeThing(4, "Task5", ConsoleColor.Red);
                    return $"Return from {t}";
                }
                , "Task5");
            task5.Start();
            var result_Task5 = await task5;
            return result_Task5;
        }
        static async Task Main(string[] args)
        {
            // synchronous- phương pháp lập trình  đồng bộ 
            //DoSomeThing(6, "Task1:", ConsoleColor.Magenta); 

            //DoSomeThing(10, "Task2:", ConsoleColor.Green);

            //DoSomeThing(6, "Task1:", ConsoleColor.Yellow);
            // asynchronous
            // Task
            //task2.Start();// Thread
            //task3.Start(); // Thred
            //Task task2 = Task2();
            //Task task3 = Task3();
            //DoSomeThing(6, "Task1:", ConsoleColor.Magenta);// Thread
            //task2.Wait();// đảm bảo  task2 kết thúc mới làm nhiệm vụ tiếp theo
            //task3.Wait();// đảm bảo task3 kết thúc mới làm nhiệm vụ tiếp theo
            //Task.WaitAll(task2, task3);
            Task<string> task4 = Task4();
            Task<string> task5 = Task5();
            DoSomeThing(6, "Task1:", ConsoleColor.Magenta);// Thread
            await task4;
            await task5;
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
