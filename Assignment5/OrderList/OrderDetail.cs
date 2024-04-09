using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderList
{
    public class OrderDetail
    {

        public Goods Goods { get; set; }
        public int Account { get; set; }

        public float TotalPrice
        {
            get { return Goods.price*Account; }
        }
        public OrderDetail()
        {
        }

        public OrderDetail(Goods goods, int account)
        {
            this.Goods = goods;
            this.Account = account;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetail detail &&
                   EqualityComparer<Goods>.Default.Equals(Goods, detail.Goods) &&
                   Account == detail.Account &&
                   TotalPrice == detail.TotalPrice;
        }

        public override int GetHashCode()
        {
            int hashCode = 2075573951;
            hashCode = hashCode * -1521134295 + EqualityComparer<Goods>.Default.GetHashCode(Goods);
            hashCode = hashCode * -1521134295 + Account.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"OrderDetail:\n{Goods}\nAccount: {Account}";
        }
    }
}
