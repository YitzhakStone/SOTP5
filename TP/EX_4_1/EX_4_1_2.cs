//
// nome do programa: EX_4_1_2.cs
//
// programadores: nome dos alunos
// Mateus Fernando          484555
// Vinicius Ponciano        482955
// Yitzhak Stone            478493
// data: 30/04/2015
// descricao: programa exemplo para simular
// concorrencia.
// 

using System;
using System.Threading;
namespace lock2
{
    class Account
    {
        private Object thisLock = new Object();
        int balance;
        Random r = new Random();
        public Account(int initial)
        {
            balance = initial;
        }
        int Withdraw(int amount)
        {
            // This condition never is true unless the lock statement
            // is commented out.
            if (balance < 0)
            {
                throw new Exception("Negative Balance");
            }
            // Comment out the next line to see the effect of leaving out
            // the lock keyword.
            lock (thisLock)
            {
                if (balance >= amount)
                {
                    Console.WriteLine("Balance before Withdrawal : " + balance);
                    Console.WriteLine("Amount to Withdraw : -" + amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after Withdrawal : " + balance);
                    return amount;
                }
                else
                {
                    return 0; // transaction rejected
                }
            }
        }

        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }


    class Test
    {
        static void Main()
        {

            Console.WriteLine("{0}\t\t{1}", "484555", "Mateus Fernando");
            Console.WriteLine("{0}\t\t{1}", "482955", "Vinicius Ponciano");
            Console.WriteLine("{0}\t\t{1}", "478493", "Yitzhak Stone");

            Console.WriteLine();

            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }

            Console.ReadLine();
        }
    }
}