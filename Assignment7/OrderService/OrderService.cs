using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp {

    /**
     * The service class to manage orders
     * */
    public class OrderService {

        //the order list
         public List<Order> Orders {
            get {
                using (var ctx = new OrderContext()) {
                    return ctx.Orders
                      .Include(o => o.Details.Select(d => d.GoodsItem))
                      .Include(o => o.Customer)
                      .ToList<Order>();
                }
            }
            set { Orders = value; }
        }


        public OrderService() {
            using (var ctx = new OrderContext()) {
                    ctx.Goods.Add(new Goods("apple", 100.0));
                    ctx.Goods.Add(new Goods("egg", 200.0));             
                    ctx.Customers.Add(new Customer("li"));
                    ctx.Customers.Add(new Customer("zhang"));
                    ctx.SaveChanges();
            }
        }


        public List<Order> GetAllOrders() {
            return Orders;
        }


        public Order GetOrder(string id) {
            using (var ctx = new OrderContext()) {
                return ctx.Orders
                  .Include(o => o.Details.Select(d => d.GoodsItem))
                  .Include(o => o.Customer)
                  .SingleOrDefault(o => o.OrderId == id);
            }
        }

        public void AddOrder(Order order) {
            order.CustomerId = order.Customer.ID;
            order.Customer = null;
            order.Details.ForEach(d => {
                d.GoodsId = d.GoodsItem.ID;
            });
            using (var ctx = new OrderContext()) {
                ctx.Entry(order).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void RemoveOrder(string orderId) {
            using (var ctx = new OrderContext()) {
                var order = ctx.Orders.Include("Details")
                  .SingleOrDefault(o => o.OrderId == orderId);
                if (order == null) return;
                ctx.OrderDetails.RemoveRange(order.Details);
                ctx.Orders.Remove(order);
                ctx.SaveChanges();
            }
        }

        public List<Order> QueryOrdersByGoodsName(string goodsName) {
            using (var ctx = new OrderContext()) {
                return ctx.Orders
                  .Include(o => o.Details.Select(d => d.GoodsItem))
                  .Include(o => o.Customer)
                  .Where(order => order.Details.Any(item => item.GoodsItem.Name == goodsName))
                  .ToList();
            }
        }

        public List<Order> QueryOrdersByCustomerName(string customerName) {
            using (var ctx = new OrderContext()) {
                return ctx.Orders
                  .Include(o => o.Details.Select(d => d.GoodsItem))
                  .Include(o => o.Customer)
                  .Where(order => order.Customer.Name == customerName)
                  .ToList();
            }
        }

        public void UpdateOrder(Order newOrder) {
            RemoveOrder(newOrder.OrderId);
            AddOrder(newOrder);
        }
    }
}
