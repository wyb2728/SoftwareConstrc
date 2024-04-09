using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer1 = new Customer(1, "张三");
                Customer customer2 = new Customer(2, "李四");

                Goods milk = new Goods(1, "Milk", 69.9f);
                Goods eggs = new Goods(2, "eggs", 4.99f);
                Goods apple = new Goods(3, "apple", 5.59f);
                 
                Order order1 = new Order(1, customer1);
                order1.AddDetails(new OrderDetail(apple, 8));
                order1.AddDetails(new OrderDetail(eggs, 10));
                order1.AddDetails(new OrderDetail(milk, 10));

                Order order2 = new Order(2, customer2);
                order2.AddDetails(new OrderDetail(eggs, 10));
                order2.AddDetails(new OrderDetail(milk, 10));

                Order order3 = new Order(3, customer2);
                order3.AddDetails(new OrderDetail(milk, 100));

                OrderService orderService = new OrderService();
                orderService.AddOrder(order1);
                orderService.AddOrder(order2);
                orderService.AddOrder(order3);

                Console.WriteLine("\n GetById");
                Console.WriteLine(orderService.QueryOrderByID(1));
                Console.WriteLine(orderService.QueryOrderByID(5));

                List<Order> orders =new List<Order>();
                Console.WriteLine("\nGetOrdersByCustomerName:'李四'");
                orders = orderService.QueryOrderByCustomer("李四");
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nGetOrdersByGoodsName:'eggs'");
                orders = orderService.QueryOrderByGoods("eggs");
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nGetOrdersTotalAmount:1000");
                orders = orderService.QueryOrderByTotalPrice(1000);
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nQueryByCondition");
                var query = orderService.Query(o => o.TotalPrice > 1000);
                foreach (Order order in query)
                {
                    Console.WriteLine(order);
                }

                Console.WriteLine("\nRemove order(id=2) and qurey all");
                orderService.DeleteOrder(2);
                orderService.GetAllOrder().ForEach(
                    o => Console.WriteLine(o));

                Console.WriteLine("\n order by Amount");
                orderService.Sort(
                  (o1, o2) => o2.TotalPrice.CompareTo(o1.TotalPrice));
                orderService.GetAllOrder().ForEach(
                    o => Console.WriteLine(o));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
