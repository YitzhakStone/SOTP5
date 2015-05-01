/*  

Mateus Fernando         xxxxxx
Vinicius Ponciano       xxxxxx
Yitzhak Stone           478493

 */


using System;
using System.Threading;
namespace monitor1
{
    class Printer
    {
        public void PrintNumbers()
        {
            //Monitor.Enter(this);
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    //Thread.Sleep(new Random().Next(1, 10) * 100);
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Monitor.Exit(this);
            }
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