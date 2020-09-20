using System;

namespace EX2_3
{
    //用“埃氏筛法”求2~ 100以内的素数。2~ 100以内的数，先去掉2的倍数，再去掉3的倍数，再去掉4的倍数，以此类推...最后剩下的就是素数
    class Program
    {
        static void Main(string[] args)
        {
            int num = 10;
            bool[] primes = new bool[num + 1];
            for(int i = 2;i< num + 1; i++)
            {
                primes[i] = true;
            }
            FilterPrimes(primes);
            
            for (int i = 2; i < num + 1; i++)//显示数组中为True的元素
            {
                if (primes[i])
                {
                    Console.WriteLine(i);
                }
            }
            
        }

        //埃氏筛法
        private static bool[] FilterPrimes(bool[] primes)
        {
            for(int i = 2; i * i < primes.Length; i++)//从2开始筛，如果第i个元素不为true，则将第i个元素的倍数剔除（设为false)，直到数组长度比i平方小
            {
                if (!primes[i]) continue;
                for(int mul = 2 * i;mul < primes.Length;mul += i)
                {
                    primes[mul] = false;
                }
            }
            return primes;
        }
    }
}
