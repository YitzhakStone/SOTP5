//
// nome do programa: EX_5_2.java
//
// programadores: nome dos alunos
// Mateus Fernando          484555
// Vinicius Ponciano        482955
// Yitzhak Stone            478493
// data: 30/04/2015
// descricao: calculadora básica (soma, subtracao, multiplicacao e divisao)
// entrada(s: parametros na linha de comandos (lc), sendo:
// primeiro operando, operador e segundo operando, separados por espaco
// saida(s): exibe os valores de entrada e o resultado da operação.
// 

class EX_5_2 {
    public static void main(String[] args) 
    {
        
        System.out.println("484555\t\tMateus Fernando");
        System.out.println("482955\t\tVinicius Ponciano");
        System.out.println("478493\t\tYitzhak Stone");
        System.out.println();


        try
        {

            if (args.length != 3 ||
                (!(     "+-x/*".contains(args[1])       )))
            {
                System.out.println("Argumentos invalidos!");
                return;
            }

            double n1 = Double.parseDouble(args[0]);
            double n2 = Double.parseDouble(args[2]);
            double r;
            String operador = args[1];

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

            System.out.println(String.valueOf(n1) + " " + operador + " " + String.valueOf(n2) + " = " + String.valueOf(r));
            System.out.println();

        } 
        catch (Exception ex)
        {
            System.out.println("Argumentos invalidos!");
        }

        System.out.println();
        System.exit(0);

    }

    static double adicao(double n1, double n2)
    {
        return  (n1 + n2);
    }

    static double subtracao(double n1, double n2)
    {
        return (n1 - n2);
    }

    static double multiplicacao(double n1, double n2)
    {
        return (n1 * n2);
    }

    static double divisao(double n1, double n2)
    {            
        
        if (n2 == 0)
        {
            throw new IllegalArgumentException("Tentativa de divisão por zero.");
        }

        return n1 / n2;
    }

}
