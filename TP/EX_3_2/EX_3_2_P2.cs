/*  

Mateus Fernando			xxxxxx
Vinicius Ponciano		xxxxxx
Yitzhak Stone			478493

 */

using System;
using System.Threading;
class AplicacaoConsole
{
    static void Main(string[] args)
    {

        Console.WriteLine("{0}\t\t{1}", "xxxxxx", "Mateus Fernando");
        Console.WriteLine("{0}\t\t{1}", "xxxxxx", "Vinicius Ponciano");
        Console.WriteLine("{0}\t\t{1}", "478493", "Yitzhak Stone");

        Console.WriteLine();

        if ((args != null) && (args.Length > 0)) // Verifica se o array que recebe argumentos não é null nem vazio
        {
            Console.WriteLine("Parâmetros passados para aplicação");
            for (int i = 0; i < args.Length; i++) // Percorre o array de argumentos
            {
                Console.WriteLine(args[i]); // imprime na tela os argumentos passados
                Thread t = new Thread(() => abrirPrograma(args[0])); // thread que abre o programa externo
                t.Start(); // inicia a thread assincrona
            }
        }
        else // Programa não recebeu argumentos
        {
            Console.WriteLine("Aplicação console não recebeu parâmetros");
        }


        for (int i = 1; i <= 400; i++) // Iteração que se repete 400 vezes
        {

            if (i % 10 == 0) // se a variavel i for multiplo de 10
            {
                Console.WriteLine(i); // imprime na tela e passa para a proxima linha
            }
            else // senão...
            {
                Console.Write(i + " "); // imprime i mais um espaço a direita
            }
        }
    }

    static async void abrirPrograma(string s)
    {
        System.Diagnostics.Process.Start(s); // abre o programa externo
    }
}