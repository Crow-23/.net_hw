using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{
    //商品
    public class Goods
    {

        private float price;


        public Goods() { }

        //商品id、名字、价格
        public Goods(uint id, string name, float price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }


        public uint Id { get; set; }


        public string Name { get; set; }


        public float Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value must >= 0!");
                price = value;
            }
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null && Id == goods.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }


        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Value:{Price}";
        }
    }
}
