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


class Hashis
{
    private bool[] _hashis;

    public Hashis(int i)
    {
        _hashis = new bool[i];
    }

    public void Pegar(int l, int r)
    {
        synchronized (this)
        {
            while (_hashis[l] || _hashis[r])
            {
                Monitor.Wait(this);
            }
            _hashis[l] = true;
            _hashis[r] = true;
        }
    }
    public void Soltar(int l, int r)
    {
        synchronized (this)
        {
            _hashis[l] = false;
            _hashis[r] = false;
            Monitor.PulseAll(this);
        }
    }

}

class Filosofo
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
        new Thread(new ThreadStart(Run)).Start();
    }
    public Filosofo(int n, int _tempoPensar, int _tempoComer, Hashis hashis, int l, int r)
    {
        this.n = n;
        this._tempoPensar = _tempoPensar;
        this._tempoComer = _tempoComer;
        this._hashis = hashis;
        this._l = l;
        this._r = r;
        new Thread(new ThreadStart(Run)).Start();
    }
    public void Run()
    {
        while (true)
        {
            try
            {

                Console.ForegroundColor = ConsoleColor.Gray;
                System.out.println("Filosofo " + n + " está pensando.");

                Thread.Sleep(_tempoPensar);
                _hashis.Pegar(_l, _r);

                Console.ForegroundColor = ConsoleColor.Red;
                System.out.println("Filosofo {0} está comendo.\t\t\tHashis {1} e {2} ocupados.", n, _l, _r);
                Thread.Sleep(_tempoComer);
                _hashis.Soltar(_l, _r);

                Console.ForegroundColor = ConsoleColor.Blue;
                System.out.println("Filosofo {0} acabou de comer.\t\t\tHashis {1} e {2} liberados.", n, _l, _r);

            }
            catch (Exception ex)
            {
                System.out.println("Exception: " + ex.Message);
                Console.ReadLine();
                return;
            }
        }
    }

}

public class JantarMain
{
    public static void Main(String[] args)
    {

        int j = 0;
        //if (args.Length != 1 || !int.TryParse(args[0], out j) || j < 2) 
        //{ 
            //System.out.println("Parametro invalido. Passar inteiro > 2");
            //return; 
        //}
        
        System.out.println("{0}\t\t{1}", "484555", "Mateus Fernando");
        System.out.println("{0}\t\t{1}", "482955", "Vinicius Ponciano");
        System.out.println("{0}\t\t{1}", "478493", "Yitzhak Stone");

        Hashis h = new Hashis(j);

        Random r = new Random();

        for(int i = 0; i < j; i++)
        {

            int pensar = r.Next(1, 3) * 1000;
            int comer = r.Next(1, 3) * 1000;
            int hashiFinal = i + 1;
            
            if(i + 1 == j)
            {
                hashiFinal = 0;
            }

            new Filosofo(i, pensar, comer, h, i, hashiFinal);
        }

    }
}
