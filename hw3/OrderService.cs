using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace hw3
{

    public class OrderService
    {

        private List<Order> orderList;

        public OrderService()
        {
            orderList = new List<Order>();
        }

        //添加新订单
        public void AddOrder(Order order)
        {
            if (orderList.Contains(order))
            {
                throw new ApplicationException($"the orderList contains an order with ID {order.Id} !");
            }
            orderList.Add(order);
        }

        //更新订单
        public void Update(Order order)
        {
            RemoveOrder(order.Id);
            orderList.Add(order);
        }

        //查找订单id
        public Order GetById(int orderId)
        {
            return orderList.FirstOrDefault(o => o.Id == orderId);
        }

        //删除订单
        public void RemoveOrder(int orderId)
        {
            orderList.RemoveAll(o => o.Id == orderId);
        }

        //所有订单
        public List<Order> QueryAll()
        {
            return orderList;
        }


        //根据名字查询订单
        public List<Order> QueryByGoodsName(string goodsName)
        {
            var query = orderList.Where(
              o => o.Details.Exists(
                d => d.Goods.Name == goodsName));
            return query.ToList();
        }

        //最小金额
        public List<Order> QueryByTotalAmount(float totalAmount)
        {
            var query = orderList.Where(o => o.TotalAmount >= totalAmount);
            return query.ToList();
        }

        //按客户名查询
        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderList
                .Where(o => o.Customer.Name == customerName);
            return query.ToList();
        }

        public void Sort(Comparison<Order> comparison)
        {
            orderList.Sort(comparison);
        }

        //将命令导出文件中
        public void Export(String fileName)
        {
            if (Path.GetExtension(fileName) != ".xml")
                throw new ArgumentException("the exported file must be a xml file!");
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, this.orderList);
            }
        }

        //导入
        public List<Order> Import(string path)
        {
            if (Path.GetExtension(path) != ".xml")
                throw new ArgumentException($"{path} isn't a xml file!");
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            List<Order> result = new List<Order>();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    return (List<Order>)xs.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("import error:" + e.Message);
            }

        }

    }
}
