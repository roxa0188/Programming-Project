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
        Dictionary<ProductType, int> orderLines = new Dictionary<ProductType, int>();
        private string deliveryDate;
        private string orderDate;
        public int OrderId { get; private set; } 
        
        public Order(int orderid, string delivDate,string ordDate, Dictionary<ProductType, int> ordLines)
        {
            orderLines = ordLines;
            deliveryDate = delivDate;
            orderDate = ordDate;
            OrderId = orderid;
        }

        public bool CheckQuantity()
        {
            bool condition = true;

            foreach(KeyValuePair<ProductType,int> productType in orderLines)
            {
                if (productType.Key.Amount < productType.Value) {
                    condition = false;
                }
            }
            return condition;
        }

        public Dictionary<ProductType, int> GetOrderLines()
        {
            return orderLines;
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
