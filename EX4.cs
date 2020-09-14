using System;

namespace EX2_4
{
    //如果矩阵上每一条由左上到右下的对角线上的元素都相同，那么这个矩阵是托普利茨矩阵 。给定一个 M x N 的矩阵，当且仅当它是托普利茨矩阵时返回 True
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = { { 1, 2, 5 }, { 3, 1, 2 }, { 4, 3, 1 } };
            Console.WriteLine($"res:{Program.Toeplitz(matrix)}");
        }
        //第i行第j列的元素等于i行-1，j行-1的元素时，为托普利茨矩阵
        public static bool Toeplitz(int[,] matrix)
        {
            for(int i = 1; i < matrix.GetLength(0); i++)//行数
            {
                for (int j = 1; j < matrix.GetLength(1); j++)//列数
                {
                    if (matrix[i, j] != matrix[i - 1, j - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
