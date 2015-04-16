/*  

Mateus Fernando			xxxxxx
Vinicius Ponciano		xxxxxx
Yitzhak Stone			478493

 */
class EX_5_1 {
    public static void main(String[] args) 
    {
        
        System.out.println("xxxxxx\t\tMateus Fernando");
        System.out.println("xxxxxx\t\tVinicius Ponciano");
        System.out.println("478493\t\tYitzhak Stone");
        System.out.println();


        try
        {

            int l = args.length;
            
            if (l != 2)
            {            
                System.out.println("Argumentos invalidos!");
                return;
            }

            int n1 = Integer.parseInt(args[0]);
            int n2 = Integer.parseInt(args[1]);

            for (int i = n1 + 1; i < n2 ; i++) {
                if (impar(i) && !multiplo5(i) && multiplo7(i)){
                    System.out.print(i + ", ");
                }
            }
        } 
        catch (Exception ex)
        {
            System.out.println("Argumentos invalidos!");
        }

        System.out.println();
        System.exit(0);

    }


    public static boolean impar(int n)
    {
        return (n%2==1);
    }

    public static boolean multiplo5(int n)
    {
        return (n%5==0);
    }

    public static boolean multiplo7(int n)
    {
        return (n%7==0);
    }
} 