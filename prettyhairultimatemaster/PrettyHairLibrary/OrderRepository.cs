using System;
using System.Collections.Generic;

namespace PrettyHairLibrary
{
    public class OrderRepository
    {
        public event TickHandler Tick;
        public EventArgs eventArgs = null;
        public delegate void TickHandler(OrderRepository orderReposit, EventArgs evArgs);
        private List<Order> listOfOrders = new List<Order>();

        public void Add(Order order)
        {
            listOfOrders.Add(order);
            ReceivedOrderNotification();
            if (!order.CheckQuantity()) NotifyWarehouseManagerAboutAmount(); 
        }


        private void ReceivedOrderNotification()
        {
            // send info instead
            // if diff from null
            Tick?.Invoke(this, eventArgs);
        }

        private void NotifyWarehouseManagerAboutAmount()
        {
            // send info instead
            // if diff from null
            Tick?.Invoke(this, eventArgs);
        }


        public void Remove(Order order) {
            listOfOrders.Remove(order);
        }

        public void Remove(int orderId)
        {
            listOfOrders.Remove(FindOrder(orderId));
        }

        public Order FindOrder(int orderId)
        {
            Order order = null;
            foreach (Order ord in listOfOrders)
            {
                if (ord.OrderId == orderId) order = ord;
            }
            return order;
        }

        public Order GetOrder(int orderId)
        {
            return FindOrder(orderId);
        }

    }
}
