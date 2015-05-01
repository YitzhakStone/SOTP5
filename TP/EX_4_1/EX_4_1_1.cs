/*  

Mateus Fernando         xxxxxx
Vinicius Ponciano       xxxxxx
Yitzhak Stone           478493

 */


using System;
using System.Threading;
namespace lock1
{
    class Printer
    {
        public void PrintNumbers()
        {
            lock (this)
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(i + ",");
                }
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("{0}\t\t{1}", "xxxxxx", "Mateus Fernando");
            Console.WriteLine("{0}\t\t{1}", "xxxxxx", "Vinicius Ponciano");
            Console.WriteLine("{0}\t\t{1}", "478493", "Yitzhak Stone");

            Console.WriteLine();

            Console.WriteLine("======MultiThreads======");
            Printer p = new Printer();
            Thread[] Threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                Threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                Threads[i].Name = "threadFilha " + i;
            }
            foreach (Thread t in Threads)
                t.Start();
            Console.ReadLine();

        }
    }
}