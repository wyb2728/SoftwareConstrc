using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderList
{
    public class Goods
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public float price;

        public Goods(int iD, string name, float price)
        {
            ID = iD;
            this.Name = name;
            this.price = price;
        }

        public Goods()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Goods goods &&
                   ID == goods.ID &&
                   this.Name == goods.Name &&
                   price == goods.price;
        }

        public override int GetHashCode()
        {
            int hashCode = 1332412544;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + price.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"Goods ID: {ID} , name: {Name} , price :{price}";
        }
    }
}
