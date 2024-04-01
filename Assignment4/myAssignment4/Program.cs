using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace myAssignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            new Thread(clock.Run).Start();
            Console.WriteLine("press any key to stop.");
            Console.ReadKey();
            clock.Stop();
        }
    }
}
