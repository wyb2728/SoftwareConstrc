using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp {
  public class Goods {
    public string ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Goods()
    {
        ID = Guid.NewGuid().ToString();
    }

    public Goods(string name, double price):this(){
      Name = name;
      Price = price;
    }

    public override bool Equals(object obj) {
      var goods = obj as Goods;
      return goods != null &&
             ID == goods.ID &&
             Name == goods.Name;
    }

        public override int GetHashCode()
        {
            int hashCode = 560300832;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }


}
