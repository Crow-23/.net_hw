using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace 课堂练习二
{
    class EX2_1
    {

        //输出用户指定数据的所有素数因子

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("输入要求的素数因子数字：");
                int num = Convert.ToInt32(Console.ReadLine());
                List<int> factor = PrimeFactor(num);
                Console.WriteLine("数字" + num + "的素数因子有：");
                foreach(int x in factor){
                    Console.Write("\n" + x);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERRO:{e.Message}");
            }
        }

        //计算素数因子
        private static List<int> PrimeFactor(int num)
        {
            List<int> factor = new List<int>();
            for (int fac = 2; fac * fac <= num; fac++)//从2开始除，若结果无余数，就加入到LIst中并除去最小素数因子，若有余数，则因子加1继续除
                while (num % fac == 0)
                {
                    factor.Add(fac);
                    num = num / fac;

                }
            if (num != 1)//剩
            {
                factor.Add(num);
            }
            return factor;
        }
    }
}
    

























