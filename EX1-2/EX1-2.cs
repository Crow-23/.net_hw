using System;

namespace EX2_2
{
    //求一个整数数组的最大值、最小值、平均值和所有数组元素的和
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 9, 1, 5, 4, 1, 6, 2, 3 };
            Console.Write("数组元素为：");
            foreach (int a in nums)
            {
                Console.Write("\t" + a);
            }
            Calculate(nums, out int max, out int min, out double sum, out double ave);
            Console.WriteLine($"\n最大值 = {max}\n最小值 = {min}\n平均值 = {ave}\n元素和 = {sum}");
        }
        private static void Calculate(int[] nums, out int max, out int min, out double sum, out double ave)
        {
            max = nums[0];//out参数必须赋初始值
            min = nums[0];
            sum = 0;
            foreach (int a in nums)
            {
                if (a > max) { max = a; };
                if (a < min) { min = a; };
                sum += a;
            }
            ave = sum / nums.Length;
        }
    }
}
