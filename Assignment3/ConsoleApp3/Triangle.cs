using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Triangle : shape
    {
        public Triangle(double[] edges) => Edges = edges;

        public double[] Edges { get; set; } = new double[3];

        public override bool checkValid()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Edges[i] <= 0)
                {
                    return false;
                }
                if (Edges[i] >= Edges[(i + 1) % 3] + Edges[(i + 2) % 3])
                {
                    return false;
                }
            }
            return true;
        }

        public override double getArea()
        {
            if (!checkValid()) { return -1; }
            double p = (Edges[0] + Edges[1] + Edges[2]) / 2;
            return Math.Sqrt(p * (p - Edges[0]) * (p - Edges[1]) * (p - Edges[2]));
        }
    }
}
