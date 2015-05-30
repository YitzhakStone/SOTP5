//
// nome do programa: EX_4_3.cs
//
// programadores: nome dos alunos
// Mateus Fernando          484555
// Vinicius Ponciano        482955
// Yitzhak Stone            478493
// data: 30/04/2015
// descricao: resolução do problema de produtor/consumidor usando monitores. 
// O buffer deve armazena caracteres, os quais são extraídos pelo produtor dos números de matrícula e dos nomes
// completos dos alunos do grupo, os quais são passados como parâmetro. O ciclo produção e
// consumo é interrompido pelo programa principal ao pressionar a tecla ‘T. 
// 


using System;
using System.Threading;
using System.Collections.Generic;

namespace EX_4_3
{
    class Program
    {
        const int BuffSize = 9999;
        char[] Buffer = new char[BuffSize];
        volatile int Avail = 0;
        int ValuesToProduce;
        char[] input;

        public Program(string str)
        {
            ValuesToProduce = str.Length;
            input = str.ToCharArray();
        }

        public void Produce()
        {
            for (int i = 0; i < ValuesToProduce; i++)
            {

                Thread.Sleep(random);

                while (Avail == BuffSize)
                {
                    Console.WriteLine("\tEsperando consumidor\t\t");
                    Thread.Sleep(1000);
                }

                try
                {
                    Monitor.Enter(this);
                    Buffer[i % BuffSize] = input[i % ValuesToProduce];
                    Avail++;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\t{0} => Produzido", Buffer[i % BuffSize]);
                }
                finally
                {
                    Monitor.Exit(this);
                }
            }
        }

        public void Consume()
        {
            for (int i = 0; i < ValuesToProduce; i++)
            {

                Thread.Sleep(random);

                while (Avail < 1)
                {
                    Console.WriteLine("\tEsperando produtor\t\t");
                    Thread.Sleep(1000);
                }

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
                    Monitor.Exit(this);
                }
            }
        }

        private int random
        {
            get { return (new Random().Next(Convert.ToInt32(1.0), Convert.ToInt32(5.0))) * 1000; }
        }

    }

    class Test
    {
        static void Main(string[] args)
        {

            //Program program = new Program("YITZHAK STONE DE ANDRADE");
            Program program = new Program(args[0]);

            Thread p = new Thread(new ThreadStart(program.Produce));
            Thread c = new Thread(new ThreadStart(program.Consume));

            Thread k = new Thread(new ThreadStart(ExitKeyListner));
            k.Start();

            p.Start();
            c.Start();

            p.Join();
            c.Join();

            Console.WriteLine();
            Console.WriteLine("\nAcabou!");
            Console.ReadLine();
        }

        private static void ExitKeyListner()
        {

            ConsoleKeyInfo k1 = new ConsoleKeyInfo('T', ConsoleKey.T, false, false, false);
            ConsoleKeyInfo k2 = new ConsoleKeyInfo('t', ConsoleKey.T, false, false, false);
            ConsoleKeyInfo k = Console.ReadKey(false);

            if (k== k1 || k == k2)
            {
                Environment.Exit(1);
            }


        }

    }
}