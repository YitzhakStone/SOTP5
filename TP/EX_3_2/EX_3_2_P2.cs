/*  

Mateus Fernando			xxxxxx
Vinicius Ponciano		xxxxxx
Yitzhak Stone			478493

 */

// programa2
// referência: http://www.linhadecodigo.com.br/artigo/271
using System;
using System.Threading;
using System.Diagnostics;
class AplicacaoConsole
{
    static void Main(string[] args){
        try
        {

            Console.WriteLine("{0}\t\t{1}", "xxxxxx", "Mateus Fernando");
            Console.WriteLine("{0}\t\t{1}", "xxxxxx", "Vinicius Ponciano");
            Console.WriteLine("{0}\t\t{1}", "478493", "Yitzhak Stone");

            Console.WriteLine();

            if (args.Length != 1 || string.IsNullOrWhiteSpace(args[0]))
            {
                throw new Exception("Parametros invalidos.");
            }

            Process proc = Process.Start(args[0]);
            Console.WriteLine("Executando a aplicação console....");
            Thread.Sleep(6000);
            proc.Kill();
            Console.WriteLine("Matou o processo. A outra janela console é fechada.");
            Console.ReadLine();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}