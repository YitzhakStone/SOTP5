//
// nome do programa: EX_3_2_P2.cs
//
// programadores: nome dos alunos
// Mateus Fernando          484555
// Vinicius Ponciano        482955
// Yitzhak Stone            478493
// data: 30/04/2015
// descricao:
// Inicia um programa passado por parametro via linha de comando
// e espera 6 segundos antes de fecha-lo forçadamente. 
// 
// programa2
// referência: http://www.linhadecodigo.com.br/artigo/271

using System;
using System.Threading;
using System.Diagnostics;

namespace EX_3_2_P1
{
    class AplicacaoConsole
    {
        static void Main(string[] args){
            try
            {

                Console.WriteLine("{0}\t\t{1}", "484555", "Mateus Fernando");
                Console.WriteLine("{0}\t\t{1}", "482955", "Vinicius Ponciano");
                Console.WriteLine("{0}\t\t{1}", "478493", "Yitzhak Stone");

                Console.WriteLine();

                // Verifica se os parametros são validos
                if (args.Length != 1 || string.IsNullOrWhiteSpace(args[0]))
                {
                    throw new Exception("Parametros invalidos.");
                }

                // Inicia o programa que foi passado por parametro
                Process proc = Process.Start(args[0]);
                Console.WriteLine("Executando a aplicação console....");
                //Aguarda 6 segundos
                Thread.Sleep(6000);
                // Mata o processo que foi iniciado
                proc.Kill();
                Console.WriteLine("Matou o processo. A outra janela console é fechada.");
                Console.ReadLine();

            }
            catch (Exception ex) // Captura uma exceção, caso ocorra.
            {
                // e exibe a pilha de rastramento
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}