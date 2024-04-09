using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderList
{
    public class Order
    {
        public int ID { get; set; }

        public List<OrderDetail> Details=new List<OrderDetail>();

        public Customer Customer { get; set; }

        public float TotalPrice
        {
            get => Details.Sum(d => d.TotalPrice);
        }

        public Order()
        {
        }

        public Order(int iD, Customer customer)
        {
            ID = iD;
            Customer = customer;
        }

        public Order(int iD, List<OrderDetail> details, Customer customer)
        {
            ID = iD;
            Details = details;
            Customer = customer;
        }

        public void AddDetails(OrderDetail orderDetail)
        {
            if (Details.Contains(orderDetail))
            {
                throw new ApplicationException($"The goods ({orderDetail.Goods.Name}) exist ");
            }
            Details.Add(orderDetail);
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   ID == order.ID &&
                   EqualityComparer<List<OrderDetail>>.Default.Equals(Details, order.Details) &&
                   EqualityComparer<Customer>.Default.Equals(Customer, order.Customer) &&
                   TotalPrice == order.TotalPrice;
        }

        public override int GetHashCode()
        {
            int hashCode = 1157360952;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderDetail>>.Default.GetHashCode(Details);
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(Customer);
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"Order info:\nID:{ID}\ndetails:{Details}\nCustomer:{Customer}\nTotalPrice:{TotalPrice}";
        }
    }
}
