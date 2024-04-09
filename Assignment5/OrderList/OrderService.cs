using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderList
{
    public class OrderService
    {
        private List<Order> Orders=new List<Order>();

        public OrderService()
        {
        }

        public void AddOrder(Order order)
        {
            if (Orders.Contains(order))
            {
                throw new ApplicationException($"this order is exist");
            }
            Orders.Add(order);
        }
        public void UpdateOrder(Order order)
        {
            int idx = Orders.FindIndex(o => o.ID == order.ID);
            if (idx < 0)
            {
                throw new ApplicationException("the order doesn't exist!");
            }
            Orders.RemoveAt(idx);
            Orders.Add(order);
        }
        public void DeleteOrder(int id)
        {
            int idx=Orders.FindIndex(o => o.ID == id);
            if (idx < 0)
            {
                throw new ApplicationException("the order doesn't exist!");
            }
            Orders.RemoveAt(idx);
        }
        public List<Order> QueryOrderByID(int id)
        {
            var query = Orders
                .Where(o => o.ID == id)
                .OrderBy(o => o.TotalPrice);
            return query.ToList(); 
        }
        public List<Order> QueryOrderByCustomer(string cusName)
        {
            var query = Orders
                .Where(o => o.Customer.Name == cusName)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }
        public List<Order> QueryOrderByGoods(string goodsName)
        {
            var query = Orders
                .Where(o => o.Details.Any(d=>d.Goods.Name==goodsName))
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }
        public List<Order> QueryOrderByTotalPrice(float totalPrice)
        {
            var query = Orders
                .Where(o => o.TotalPrice >= totalPrice)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }
        public List<Order> GetAllOrder()
        {
            return Orders;
        }
        public void Sort(Comparison<Order> comparison)
        {
            Orders.Sort(comparison);
        }
        public IEnumerable<Order> Query(Predicate<Order> condition)
        {
            return Orders.Where(o => condition(o)).OrderBy(o => o.TotalPrice);
        }
    }
}
