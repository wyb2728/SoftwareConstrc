using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderList.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        Customer customer1 = new Customer(1, "张三");
        Customer customer2 = new Customer(2, "李四");

        Goods apple = new Goods(1, "apple", 1.9f);
        Goods banana = new Goods(2, "banana", 3.0f);
        Goods peach = new Goods(3, "peach", 5.3f);

        OrderService orderService = new OrderService();

        [TestInitialize]
        public void Init()
        {
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer2);
            
            order1.AddDetails(new OrderDetail(apple, 3));
            order1.AddDetails(new OrderDetail(banana, 10));
            order1.AddDetails(new OrderDetail(peach, 5));
            order2.AddDetails(new OrderDetail(banana, 3));
            order2.AddDetails(new OrderDetail(peach, 7));
            order3.AddDetails(new OrderDetail(banana, 80));

          
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Order order4 = new Order(4, customer2);
            orderService.AddOrder(order4);
            Assert.AreEqual(4,orderService.GetAllOrder().Count);
            CollectionAssert.Contains(orderService.GetAllOrder(), order4);
        }

        [TestMethod()]
        public void UpdateOrderTest()
        {
            Order order3 = new Order(3, customer1);
            order3.AddDetails(new OrderDetail(apple, 999999));
            orderService.UpdateOrder(order3);
            Assert.AreEqual(999999,orderService.QueryOrderByID(3).First().Details.First().Account);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            orderService.DeleteOrder(3);
            Assert.AreEqual(2, orderService.GetAllOrder().Count);
        }

        [TestMethod()]
        public void QueryOrderByIDTest()
        {
            Order _order2 = orderService.QueryOrderByID(2).First();
            Assert.IsNotNull(_order2);
            Assert.AreEqual(2, _order2.ID);
            Assert.AreEqual(customer2, _order2.Customer);
        }

        [TestMethod()]
        public void QueryOrderByCustomerTest()
        {
            Order _order1 = orderService.QueryOrderByCustomer("张三").First();
            Assert.IsNotNull(_order1);
            Assert.AreEqual(1, _order1.ID);
            Assert.AreEqual(customer1, _order1.Customer);
        }

        [TestMethod()]
        public void QueryOrderByGoodsTest()
        {
            Assert.AreEqual(1, orderService.QueryOrderByGoods("apple").Count);
            Assert.AreEqual(3, orderService.QueryOrderByGoods("banana").Count);
            Assert.AreEqual(2, orderService.QueryOrderByGoods("peach").Count);
        }
    }
}