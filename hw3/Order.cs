using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{


    [Serializable]
    public class Order : IComparable<Order>
    {

        private List<OrderDetail> details = new List<OrderDetail>();
        public Order() { }
        public Order(int orderId, Customer customer)
        {
            Id = orderId;//订单ID
            Customer = customer;//顾客
        }

        public int Id { get; set; }

        public Customer Customer { get; set; }

        public float TotalAmount//订单总额
        {
            get => details.Sum(d => d.Amount);
        }

        public List<OrderDetail> Details
        {
            get => this.details;
        }

        //在订单中添加订单信息
        //添加新的订单详细信息 
        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetail of the goods ({orderDetail.Goods.Name}) exists in order {Id}");
            }
            details.Add(orderDetail);
        }

        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return Id - other.Id;
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null && Id == order.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        //删除订单细节
        public void RemoveDetails(int num)
        {
            details.RemoveAt(num);
        }

        public override string ToString()
        {
            String result = $"orderId:{Id}, customer:({Customer})";
            details.ForEach(detail => result += "\n\t" + detail);
            return result;
        }


    }
}
