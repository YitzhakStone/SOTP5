using System;
using System.Threading;
using System.Collections.Generic;
class Program
{
    const int BuffSize = 5;
    char[] Buffer = new char[BuffSize];
    volatile int Avail = 0;
    int ValuesToProduce;
    char[] input;
    Mutex _Buffer = new Mutex(false);
    Mutex IsFull = new Mutex(true);
    Mutex IsEmpty = new Mutex(true);

    public Program(string str)
    {
        ValuesToProduce = str.Length;
        input = str.ToCharArray();
    }

    public void Produce()
    {
        for (int i = 0; i < ValuesToProduce; i++)
        {

            Thread.Sleep(i * 500);

            while (Avail == BuffSize)
            {
                Console.WriteLine("\tEsperando consumidor\t\t");
                IsFull.WaitOne(1000);
            }

            try
            {
                //_Buffer.WaitOne();
                Monitor.Enter(this);

                Buffer[i % BuffSize] = input[i % ValuesToProduce];
                Avail++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t{0} => Produzido", Buffer[i % BuffSize]);
            }
            finally
            {
                //_Buffer.ReleaseMutex();
                Monitor.Exit(this);
            }

            try
            {
                IsEmpty.ReleaseMutex();
            }
            catch
            {

            }
        }
    }

    public void Consume()
    {
        for (int i = 0; i < ValuesToProduce; i++)
        {

            Thread.Sleep(3000);

            while (Avail < 1)
            {
                Console.WriteLine("\tEsperando produtor\t\t");
                IsEmpty.WaitOne(1000);
            }

            //_Buffer.WaitOne();
            try
            {
                Monitor.Enter(this);

                char c = Buffer[i % BuffSize];
                Avail--;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t{0} => Consumido", Buffer[i % BuffSize]);
            }
            finally
            {
                //_Buffer.ReleaseMutex();
                Monitor.Exit(this);
            }

            try
            {
                IsFull.ReleaseMutex();
            }
            catch
            {

            }
        }
    }

    private int random
    {
        get { return (new Random().Next(Convert.ToInt32(0.5), Convert.ToInt32(1.5))) * 1000; }
    }

}

class Test
{
    static void Main(string[] args)
    {
        
        Program program = new Program("YITZHAK STONE DE ANDRADE");

        Thread p = new Thread(new ThreadStart(program.Produce));
        Thread c = new Thread(new ThreadStart(program.Consume));
        p.Start();
        c.Start();

        p.Join();
        c.Join();

        Console.WriteLine();
        Console.WriteLine("\nAcabou!");
        Console.ReadLine();
    }
}