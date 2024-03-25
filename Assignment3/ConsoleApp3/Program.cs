using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Factory fct=new Factory();
            double[] ls = { 1, 2, 1 };
            double[] ls2 = { 3, 4, -5 };
            double[] ls3 = { 5, 12, 13 };
            List<shape> shapes = new List<shape>();
            shapes.Add(fct.getShape(0, ls));
            shapes.Add(fct.getShape(1, ls)); 
            shapes.Add(fct.getShape(2, ls)); 
            shapes.Add(fct.getShape(0, ls2));
            shapes.Add(fct.getShape(1, ls2));
            shapes.Add(fct.getShape(2, ls2));
            shapes.Add(fct.getShape(0, ls3));
            shapes.Add(fct.getShape(1, ls3));
            shapes.Add(fct.getShape(2, ls3));
            shapes.Add(fct.getShape(2, ls3));
           
            shapes.ForEach(s =>Console.WriteLine($"Area={s.getArea()}")); 
        }
    }
}
