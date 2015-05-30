//
// nome do programa: EX_2_1.cs
//
// programadores: nome dos alunos
// Mateus Fernando			484555
// Vinicius Ponciano		482955
// Yitzhak Stone			478493
// data: 30/04/2015
// descricao: calculadora básica (soma, subtracao, multiplicacao e divisao)
// entrada(s: parametros na linha de comandos (lc), sendo:
// primeiro operando, operador e segundo operando, separados por espaco
// saida(s): exibe os valores de entrada e o resultado da operação.
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_2_1
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

            	Console.WriteLine("{0}\t\t{1}", "484555", "Mateus Fernando");
            	Console.WriteLine("{0}\t\t{1}", "482955", "Vinicius Ponciano");
            	Console.WriteLine("{0}\t\t{1}", "478493", "Yitzhak Stone");

            	Console.WriteLine();

                decimal n1, n2, r;

                if (args.Length != 3 ||
                    (!(decimal.TryParse(args[0], out n1) && decimal.TryParse(args[2], out n2))) ||
                    (!(new string[] { "+", "-", "x", "/", "*" }.Contains(args[1]))))
                {
                    Console.WriteLine("Parametros Inválidos");
                    return;
                }

                string operador = args[1];

                switch (operador)
                {
                    case "+":
                        r = adicao(n1, n2);
                        break;
                    case "-":
                        r = subtracao(n1, n2);
                        break;
                    case "x":
                    case "*":
                        r = multiplicacao(n1, n2);
                        break;
                    case "/":
                        r = divisao(n1, n2);
                        break;
                    default:
                        r = 0;
                        break;
                }

                Console.Write("{0} {1} {2} = {3}", n1.ToString(), operador.ToString(), n2.ToString(), r.ToString());
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

        }

        static decimal adicao(decimal n1, decimal n2)
        {
            return  (n1 + n2);
        }

        static decimal subtracao(decimal n1, decimal n2)
        {
            return (n1 - n2);
        }

        static decimal multiplicacao(decimal n1, decimal n2)
        {
            return (n1 * n2);
        }

        static decimal divisao(decimal n1, decimal n2)
        {            
            
            if (n2 == 0)
            {
                throw new Exception("Tentativa de divisão por zero.");
            }

            return n1 / n2;
        }

    }
}
