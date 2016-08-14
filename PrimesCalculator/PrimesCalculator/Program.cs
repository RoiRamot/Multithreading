using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimesCalculator
{
    class Program
    {

        public static List<long> CalcPrime(int low, int high)
        {
            var primes = new List<long>();
            var options = new ParallelOptions {MaxDegreeOfParallelism = Int32.MaxValue};
            var rnd = new Random();
            Parallel.For((long)low, high,options, (p,state) =>
            {
                Monitor.Enter(rnd);
                int target = rnd.Next(0, 10);
                Thread.Sleep(2);
                Monitor.Exit(rnd);
                bool isPrime = true;
                    for (int j = 2; j < p; j++)
                    {
                        if (target==0)
                        {
                            state.Break();
                            return;
                        }


                        if (p % j == 0)
                        {
                            isPrime = false;
                        }
                    }
                    if (isPrime)
                    {
                        primes.Add(p);
                    }
                
            });
            return primes;

        } 
        static void Main(string[] args)
        {
            int userLow =int.Parse(Console.ReadLine());
            int userHigh =int.Parse(Console.ReadLine());
            foreach (var prime  in  CalcPrime(userLow, userHigh))
            {
                Console.WriteLine(prime);
            }
            Console.ReadLine();
        }
    }
}
