using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{

    //记录货物与数量
    public class OrderDetail
    {

        public OrderDetail() { }

        //商品，数量
        public OrderDetail(Goods goods, uint quantity)
        {
            this.Goods = goods;
            this.Quantity = quantity;
        }
    
        public Goods Goods { get; set; }

        public uint Quantity { get; set; }

        //订单价格总和
        public float Amount
        {
            get => Goods.Price * Quantity;
        }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null &&
                   EqualityComparer<Goods>.Default.Equals(Goods, detail.Goods);
        }

        public override int GetHashCode()
        {
            return 785010553 + EqualityComparer<Goods>.Default.GetHashCode(Goods);
        }


        public override string ToString()
        {
            return $"orderDetail:{Goods},{Quantity}";
        }


    }
}
