import java.util.Random;
import java.util.Scanner;


//
// nome do programa: EX_2_2.cs
//
// programadores: nome dos alunos
// Mateus Fernando          484555
// Vinicius Ponciano        482955
// Yitzhak Stone            478493
// data: 30/04/2015
// descricao:
// resolução do problema jantar dos filosofos usando monitor.
// passar por parametro via linha de comando o numero de filosofos (maior que 2).
// 

public class EX_6_4
{
    public static void main(String[] args)
    {

        
/***************************/
//java.io.InputStreamReader reader = new java.io.InputStreamReader(System.in); 
//boolean b = false;
//while(!b) 
//{ 
//    try{
//        if ( reader.ready()) 
//        { 
//            // read a character and process it 
//            System.out.println("entrou");
//            b = true;
//        } 
//    }
//    catch (java.io.IOException ioex)
//    {
//        System.out.println("excecao2");
//    }
// 
//    // edit, lets not hog any cpu time 
//    try 
//    { 
//        Thread.sleep(50); 
//        System.out.println("ainda nao");
//    } 
//    catch (InterruptedException ex) 
//    { 
//        // can't do much about it can we? Ignoring  
//        System.out.println("excecao2");
//    } 
//}
/***************************/


        int j;

        if (args.length != 1)
        {
        	System.out.println("Parametro invalido. Passar inteiro > 2");
        	return;
        }

		try  
		{  
		 	j = Integer.parseInt(args[0]);
		 	if (j < 2)
		 	{
		 		System.out.println("Parametro invalido. Passar inteiro > 2");
		  		return;
		 	}
		} 
		catch(NumberFormatException nfe) 
		{  
		  System.out.println("Parametro invalido. Passar inteiro > 2");
		  return;
		}
        
        System.out.println("484555\t\tMateus Fernando");
        System.out.println("482955\t\tVinicius Ponciano");
        System.out.println("478493\t\tYitzhak Stone");
        System.out.println("");

        Hashis h = new Hashis(j);

        Random r = new Random();

        for(int i = 0; i < j; i++)
        {

            int pensar = (r.nextInt(3) + 1) * 1000;
            int comer = (r.nextInt(3) + 1) * 1000;
            int hashiFinal = i + 1;
            
            if(i + 1 == j)
            {
                hashiFinal = 0;
            }

            new Filosofo(i, pensar, comer, h, i, hashiFinal).start();
        }

    }
}

class Hashis
{
    private boolean[] _hashis;

    public Hashis(int i)
    {
        _hashis = new boolean[i];
    }

    public void Pegar(int l, int r)
    {
        synchronized (this)
        {
            while (_hashis[l] || _hashis[r])
            {
                try {
                    this.wait();
                    _hashis[l] = true;
                    _hashis[r] = true;
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
    }
    public void Soltar(int l, int r)
    {
        synchronized (this)
        {
            _hashis[l] = false;
            _hashis[r] = false;
            this.notifyAll();
        }
    }

}


class Filosofo extends Thread
{
    int n;
    int _tempoPensar;
    int _tempoComer;
    int _l;
    int _r;
    Hashis _hashis;

    public Filosofo(int n, int _tempoPensar, int _tempoComer, Hashis hashis)
    {
        this.n = n;
        this._tempoPensar = _tempoPensar;
        this._tempoComer = _tempoComer;
        this._hashis = hashis;
        this._l = n == 0 ? 4 : n - 1;
        this._r = (n + 1) % 5;
    }
    public Filosofo(int n, int _tempoPensar, int _tempoComer, Hashis hashis, int l, int r)
    {
        this.n = n;
        this._tempoPensar = _tempoPensar;
        this._tempoComer = _tempoComer;
        this._hashis = hashis;
        this._l = l;
        this._r = r;
    }
    public void run()
    {
        while (true)
        {
            try
            {

                //Console.ForegroundColor = ConsoleColor.Gray;
                System.out.println("Filosofo " + n + " esta pensando.");

                Thread.sleep(_tempoPensar);
                _hashis.Pegar(_l, _r);

                //Console.ForegroundColor = ConsoleColor.Red;
                System.out.println("Filosofo " + n + " esta comendo.\t\t\tHashis " + _l + " e " + _r + " ocupados.");
                Thread.sleep(_tempoComer);
                _hashis.Soltar(_l, _r);

                //Console.ForegroundColor = ConsoleColor.Blue;
                System.out.println("Filosofo " + n + " acabou de comer.\t\t\tHashis " + _l + " e " + _r + " liberados.");

            }
            catch (Exception ex)
            {
                System.out.println("Exception: " + ex.getMessage());
                return;
            }
        }
    }

}