//
// nome do programa: EX_3_1_P1.cs
//
// programadores: nome dos alunos
// Mateus Fernando          484555
// Vinicius Ponciano        482955
// Yitzhak Stone            478493
// data: 30/04/2015
// descricao:
// exibe na tela os parametros passados por linha de comando.
// imprime os numeros inteiros de 1 a 400, colocando 10 em cada linha.
// 

using System;
using System.Threading;

namespace EX_3_2_P1
{
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
    }
}