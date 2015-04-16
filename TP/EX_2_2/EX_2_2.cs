/*  

Mateus Fernando			xxxxxx
Vinicius Ponciano		xxxxxx
Yitzhak Stone			478493

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_2_2
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

            	Console.WriteLine("{0}\t\t{1}", "xxxxxx", "Mateus Fernando");
            	Console.WriteLine("{0}\t\t{1}", "xxxxxx", "Vinicius Ponciano");
            	Console.WriteLine("{0}\t\t{1}", "478493", "Yitzhak Stone");

            	Console.WriteLine();

                int n1, n2;

                if (args.Length != 2 ||
                    (!(int.TryParse(args[0], out n1) && int.TryParse(args[1], out n2))) ||
                    n1 > n2)
                {
                    Console.WriteLine("Parametros Inválidos");
                    return;
                }

                calcular(n1, n2);

                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

        }

        static void calcular(int n1, int n2)
        {
            for (int i = n1 + 1; i < n2; i++)
            {
            	if (impar(i) && !multiplo5(i) && multiplo7(i))
            	{
            		Console.Write("{0}, ", i);
            	}
            }
        }

        static bool impar(int n1)
        {
        	return (n1 % 2 == 1);
        }

        static bool multiplo5(int n1)
        {
            return (n1 % 5 == 0);
        }

        static bool multiplo7(int n1)
        {            
            
        	return (n1 % 7 == 0);
        }

    }
}
