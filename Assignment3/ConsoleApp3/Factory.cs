using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Factory
    {
        public shape getShape(int x, double[] edges)
        {
            switch (x)
            {
                case 0: return new Square(edges[0]);    
                case 1: return new Rectangle(edges[0], edges[1]);
                case 2: return new Triangle(edges);
                default: return null;
            }
        }
    }
}
