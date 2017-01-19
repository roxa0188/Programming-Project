using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHairLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrettyHairTests
{
    [TestClass]
    public class TestOrder
    {
        [TestMethod]
        public void CanCreateOrder()
        {
            ProductType product1 = new ProductType(00, "product", 5.99, 10);
            ProductType product2 = new ProductType(00, "product", 5.99, 10);
            Dictionary<ProductType, int> orderLines = new Dictionary<ProductType, int>();
            orderLines.Add(product1, 2);
            orderLines.Add(product2, 2);
            Order order = new Order(1, "2016-11-26", "2016-12-26", orderLines);
            Assert.AreEqual("order [deliverydate=2016-11-26, orderdate=2016-12-26]", order.ToString());
        }

        [TestMethod]
        public void CanAddOrderToRepository()
        {
            ProductType product1 = new ProductType(00, "product", 5.99, 10);
            ProductType product2 = new ProductType(00, "product", 5.99, 10);
            OrderRepository orderRepository = new OrderRepository();
            Dictionary<ProductType, int> orderLines = new Dictionary<ProductType, int>();
            orderLines.Add(product1, 2);
            orderLines.Add(product2, 2);
            Order order = new Order(1, "2016-11-26", "2016-12-26", orderLines);
            int orderId = 1;
            orderRepository.Add(order);
            Assert.AreEqual(orderRepository.GetOrder(orderId).ToString(), "order [deliverydate=2016-11-26, orderdate=2016-12-26]");

        }
        
        [TestMethod]
        public void CanRemoveOrderFromRepository()
        {
            ProductType product1 = new ProductType(00, "product", 5.99, 10);
            ProductType product2 = new ProductType(01, "product2", 5.99, 10);
            OrderRepository orderRepository = new OrderRepository();
            Dictionary<ProductType, int> listOfProducts = new Dictionary<ProductType, int>();
            listOfProducts.Add(product1, 2);
            listOfProducts.Add(product2, 2);
            Order order = new Order(1, "2016-11-26", "2016-12-26", listOfProducts);
           
            orderRepository.Add(order);
            orderRepository.Remove(order);
            
            Assert.AreEqual(null, orderRepository.GetOrder(order.OrderId));
        }



        [TestMethod]
        public void CanNotifyWarehouseManager()
        {
            ProductType product1 = new ProductType(00, "product", 5.99, 10);
            OrderRepository orderRepository = new OrderRepository();
            Dictionary<ProductType, int> listOfProducts = new Dictionary<ProductType, int>();
            listOfProducts.Add(product1, 2);
            Order order = new Order(1, "2016-11-26", "2016-12-26", listOfProducts);
            
            MailServer mailServer = new MailServer();
            mailServer.Subscribe(orderRepository);
            // When adding an order to the repository, the MailServer which is subscribed to OrderRepository executes the event handle
            // Method does nothing, just there to test if events work, test it by checking if an integer is being incremented
            orderRepository.Add(order);
                    
            Assert.AreEqual(1, mailServer.EmailsSent);

        }

        [TestMethod]
        public void CanCheckAmountInOrderlinesAgainstStock()
        {
            //products for the first order
            ProductType product1 = new ProductType(00, "product", 5.99, 4);
            ProductType product2 = new ProductType(01, "product2", 5.99, 10);
            
            //products for the orderlines in the 2nd order has a lower amount in stock than in the order and should return false in the 2nd assert equal
            ProductType product3 = new ProductType(02, "product3", 5.99, 0);
            ProductType product4 = new ProductType(03, "product4", 5.99, 2);

            OrderRepository orderRepository = new OrderRepository();

            Dictionary<ProductType, int> listOfProductTypes1 = new Dictionary<ProductType, int>();
            listOfProductTypes1.Add(product1, 2);
            listOfProductTypes1.Add(product2, 2);

            Dictionary<ProductType, int> listOfProductTypes2 = new Dictionary<ProductType, int>();
            listOfProductTypes2.Add(product3, 2);
            listOfProductTypes2.Add(product4, 2);

            Order order1 = new Order(1, "2016-11-26", "2016-12-26", listOfProductTypes1);
            Order order2 = new Order(2, "2016-11-22", "2016-12-23", listOfProductTypes2);

            Assert.AreEqual(true, order1.CheckQuantity());
            Assert.AreEqual(false, order2.CheckQuantity());

        }

        [TestMethod]
        public void CanTriggerEventWhenInadaquiteAmount() {

            //products for an order inadaquite amount
            ProductType product1 = new ProductType(00, "product", 5.99, 0);
            ProductType product2 = new ProductType(01, "product2", 5.99, 1);

            OrderRepository orderRepository = new OrderRepository();

            Dictionary<ProductType, int> listOfProducts = new Dictionary<ProductType, int>();
            listOfProducts.Add(product1, 2);
            listOfProducts.Add(product2, 3);

            Order order = new Order(1, "2016-11-26", "2016-12-26", listOfProducts);

            MailServer mailServer = new MailServer();
            mailServer.Subscribe(orderRepository);
            orderRepository.Add(order);
            // One email sent when adding and then another when the event fires from having an inadaquate amount
            Assert.AreEqual(mailServer.EmailsSent, 2);
        }
    }
}
