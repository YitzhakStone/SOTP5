using System;
using System.Threading;

class Hashis
{
    private bool[] _hashis;

    public Hashis(int i)
    {
        _hashis = new bool[i];
    }

    public void Pegar(int l, int r)
    {
        lock (this)
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
        lock (this)
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
                Console.WriteLine("Filosofo " + n + " está pensando.");

                Thread.Sleep(_tempoPensar);
                _hashis.Pegar(_l, _r);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Filosofo {0} está comendo.\t\t\tHashis {1} e {2} ocupados.", n, _l, _r);
                Thread.Sleep(_tempoComer);
                _hashis.Soltar(_l, _r);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Filosofo {0} acabou de comer.\t\t\tHashis {1} e {2} liberados.", n, _l, _r);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.ReadLine();
                return;
            }
        }
    }

}

public class JantarMain
{
    public static void Main(string[] args)
    {

        int j = 0;
        if (args.Length != 1 || !int.TryParse(args[0], out j) || j < 2) { return; }
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