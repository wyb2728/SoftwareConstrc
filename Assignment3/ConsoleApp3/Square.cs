using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Square : shape
    {
        double x;

        public Square(double x) => this.x = x;

        public override bool checkValid()
        {
            return x > 0;
        }

        public override double getArea()
        {
            if (!checkValid()) { return -1; }
            return x * x;
        }
    }
}
