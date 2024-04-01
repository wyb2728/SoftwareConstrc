using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Node<T>
    {
        private Node<T> n;

        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
        public Node(Node<T> n)
        {
            this.n = n;
        }
    }
    public class NodeList<T>
    {
        public Node<T> head { get; set; }
        public Node<T> tail { get; set; }

        public NodeList(){
            head = null;
            tail = null;
        }
        public void Add(Node<T> n)
        {
            Node<T> t = new Node<T>(n.Data);

            if (head == null)
            {
                head = t;
                tail = t;
            }
            else
            {
                tail.Next = t;
                tail = t;
            }
        }
        public void ForEach(Action<Node<T>> a)
        {
            for (Node<T> n = head; n != null; n = n.Next)
            {
                a(n);
            }
        }

        public int Sum(Func<T, int> selector)
        {
            int sum = 0;
            for (Node<T> n = head; n != null; n = n.Next)
            {
                sum += selector(n.Data);
            }
            return sum;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            NodeList<int> nl = new NodeList<int>();
            nl.Add(new Node<int>(0));
            nl.Add(new Node<int>(1));
            nl.Add(new Node<int>(2));
            nl.Add(new Node<int>(3));
            nl.Add(new Node<int>(4));
            int max = int.MinValue;
            int min = int.MaxValue;
            nl.ForEach(n =>
            {
                if (n.Data > max) { max = n.Data; }
                if (n.Data < min) { min = n.Data; };
                Console.WriteLine(n.Data);
            });
            int sum = nl.Sum(n => n);
            Console.WriteLine("max: " + max);
            Console.WriteLine("min: " + min);
            Console.WriteLine("sum: " + sum);
        }
    }
}
