using System;
using System.Collections.Generic;
using System.Linq;

namespace PrettyHairLibrary
{
    public class OrderRepository
    {
        private Dictionary<int, Order> Orders = new Dictionary<int, Order>();

        IKeyGenerator KeyGenerator = FactoryKeyGenerator.SelectMethod(1);
        

        public void Add(Order order)
        {
            Orders.Add(order.OrderId, order);
        }

        public Order Get(int id)
        {
            return Orders[id];
        }

        public Order Create(string orderDate, string deliveryDate)
        {
            Order Order = new Order(KeyGenerator.NextKey, orderDate, deliveryDate);
            return Order;
        }

        public List<Order> GetAll()
        {
            return Orders.Values.ToList();
        }

        
    }
}
