using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Rectangle : shape
    {
        double x;
        double y;

        public Rectangle(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool checkValid()
        {
            if (x > 0 && y > 0) { 
                return true; 
            }
            else
            {
                return false;
            }
        }

        public override double getArea()
        {
            if (!checkValid()) { return -1; }
            return x * y;
        }
    }
}
