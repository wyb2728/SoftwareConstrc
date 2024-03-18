using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            getPrimeFactors();
            getArrayInfo();
            getPrimeUnder100();
            getToeplitz();
        }

        static void getPrimeFactors()
        {
            Console.WriteLine("##分解质因子->输入数据：");
            string s = Console.ReadLine();
            int a = int.Parse(s);
            Console.WriteLine("质因子如下：");
            printPrime(a);
        }
        static void printPrime(int a)
        {
            for(int i=1; i<=a; i++)
            {   
                //只需判断能否整除以及是不是质数即可
                if (a % i == 0&&cheakPrime(i))
                {
                    Console.WriteLine(i.ToString());
                }
            }
        }
        static bool cheakPrime(int a)
        {
            if (a == 1) { return true; }
            int c = 0;
            for(int i = 1; i <= a; i++)
            {
                if (a % i == 0)
                {
                    c++;
                }
            }
            if (c == 2) { return true; }
            return false;
        }

        static void getArrayInfo()
        {
            Console.WriteLine("##数组计算->输入数据，数据间用空格分隔：");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            int[] intArray = Array.ConvertAll(numbers, int.Parse);
            Console.WriteLine("数组最大值："+intArray.Max());
            Console.WriteLine("数组最小值："+intArray.Min());
            Console.WriteLine("数组平均值："+intArray.Average());
            Console.WriteLine("数组求和："+intArray.Sum());
        }

        static void getPrimeUnder100()
        {
            //创建一个长为101的数组，直接用下标表示对应数字
            bool[] boolArray=new bool[101];
            for(int i=0; i<101; i++)
            {
                boolArray[i]=true;
            }
            boolArray[0]=false;
            int a,b;
            //进于一个数，若还未被置false，则说明其是质数，将其100以内的倍数全部置false
            for(int i=2; i<101; i++)
            {
                if (boolArray[i] == true)
                {
                    a = i;
                    b = 2;
                    while (a * b <= 100)
                    {
                        if (boolArray[a * b] == true)
                        {
                            boolArray[a * b] = false;
                        }
                        b++;
                    }
                }
            }
            Console.WriteLine("##100以内的素数->");
            for (int i=0; i < 101; i++)
            {
                if (boolArray[i])
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void getToeplitz()
        {
            Console.WriteLine("##判断是否为Toeplitz矩阵->");
            Console.WriteLine("输入矩阵行数");
            string s=Console.ReadLine();
            int rows=int.Parse(s);
            Console.WriteLine("输入矩阵列数");
            s=Console.ReadLine();
            int cols=int.Parse(s);
            int[,] matrix = new int[rows, cols];
            Console.WriteLine("按行输入矩阵,用空格进行分割");
            for (int i=0; i<rows; i++)
            {
                //按行输入元素，利用split进行分割填入矩阵
                string[] rowValues = Console.ReadLine().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(rowValues[j]);
                }
            }
            if (checkToeplitz(matrix))
            {
                Console.WriteLine("true!");
            }
            else
            {
                Console.WriteLine("false!");
            }
        }
        static bool checkToeplitz(int[,] m)
        {
            //在判断时，除去第一行和第一列，依次与左上元素进行比对
            for(int i = 1; i < m.GetLength(0) ; i++)
            {
                for(int j = 1; j < m.GetLength(1) ; j++)
                {
                    if (m[i, j] != m[i - 1, j - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
