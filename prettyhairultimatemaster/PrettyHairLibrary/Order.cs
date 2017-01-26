using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{
   public class Order
    {
        // Unique key for the product, and then the amount of this product in the order
        
        public List<OrderLine> OrderLines { get; set; }
        private string deliveryDate { get; set; }
        private string orderDate { get; set; }
        public int OrderId { get; set; }
        


        public Order(int orderid, string delivDate, string ordDate)
        {
            
            deliveryDate = delivDate;
            orderDate = ordDate;
            OrderId = orderid;
        }

        public void AddOrderLine(OrderLine orderLine)
        {
            OrderLines.Add(orderLine);
        }

       
        

        public Order()
        {

        }



        public override string ToString()
        {

            string orderToString = "order [deliverydate=" + deliveryDate + ", orderdate=" + orderDate + "]";
            return orderToString;
        }
    }
}
