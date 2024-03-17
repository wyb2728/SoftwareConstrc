using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s;
            double a=0,b=0;
            s=Console.ReadLine();
            a=Double.Parse(s);
            s = Console.ReadLine();
            b = Double.Parse(s);
            s = Console.ReadLine();
            switch (s)
            {
                case "+":
                    a=a+b;
                    break;
                case "-":
                    a=a-b;
                    break;
                case "*":
                    a=a*b;
                    break;
                case "/":
                    a=a/b;
                    break;
                default:
                    Console.WriteLine("Illegal input");
                    break;
            }

            Console.WriteLine($"{a}");
        }
    }
}
