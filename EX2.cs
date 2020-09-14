using System;
using System.Collections.Generic;
using System.Text;

namespace 课堂练习二
{
    class EX2_2
    {
        public static void Main(string [] args)
        {
            int[] nums = { 9, 8, 7, 5, 6 };
            Calculate(nums, out int max, out int min, out int sum, out double ave);
            Console.WriteLine($"max = {max}\nmin = {min}\nsum = {sum}\nave = {ave}");
        }
        private static void Calculate (int [] nums ,out int max,out int min,out int sum,out double ave)
        {
            max = nums[0];
            min = nums[0];
            sum = 0;
            foreach(int a in nums)
            {
                if (a > max) { max = a; };
                if (a < min) { min = a; };
                sum += a;
            }
            ave = sum / nums.Length;
        }
    }
}
