//
// nome do programa: EX_4_2.cs
//
// programadores: nome dos alunos
// Mateus Fernando          484555
// Vinicius Ponciano        482955
// Yitzhak Stone            478493
// data: 30/04/2015
// descricao: programa inicia 3 threads simulando uma impressora
// e não deixa as páginas das impressoes se misturarem, usando monitor com 
// os métodos enter e exit.
// 


using System;
using System.Threading;
namespace monitor1
{
    class Printer
    {
        public void PrintNumbers()
        {
            Monitor.Enter(this);
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
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
                Monitor.Exit(this);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("{0}\t\t{1}", "484555", "Mateus Fernando");
            Console.WriteLine("{0}\t\t{1}", "482955", "Vinicius Ponciano");
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