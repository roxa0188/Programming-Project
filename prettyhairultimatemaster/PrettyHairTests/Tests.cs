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
    public class Tests
    {
        ProductTypeRepository productRepository = new ProductTypeRepository();

        [TestMethod]
        public void CanAddProduct()
        {
            ProductType productType = new ProductType(00, "product", 5.99, 10);
            productRepository.Add(productType);
            Assert.AreEqual(productType, productRepository.GetProduct(00));
        }
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void CanDeleteProduct()
        {
            ProductType productType = new ProductType(00, "product", 5.99, 10);
            productRepository.Add(productType);
            productRepository.Delete(productType.ID);
            productRepository.GetProduct(00);
        }
        [TestMethod]
        public void CanAdjustPrice()
        {
            ProductType productType = new ProductType(00, "product", 5.99, 10);
            productRepository.Add(productType);
            productRepository.AdjustPrice(00, 4.99);
            Assert.AreEqual(4.99, productRepository.GetProduct(00).Price);
        }
        [TestMethod]
        public void ToStringReturnsCorrectString()
        {
            ProductType productType = new ProductType(00, "product", 5.99, 10);
            productRepository.Add(productType);
            Assert.AreEqual("Product ID: " + 00 +
                            "Product description: product" +
                            "Product price: " + 5.99 +
                            "Product amount: " + 10, productRepository.GetProduct(00).ToString());
        }
        [TestMethod]
        public void CanAdjustAmount()
        {
            ProductType productType = new ProductType(00, "product", 5.99, 10);
            productRepository.Add(productType);
            productRepository.AdjustAmount(00, 5);
            Assert.AreEqual(5, productRepository.GetProduct(00).Amount);
        }
        [TestMethod]
        public void CanAdjustDescription()
        {
            ProductType productType = new ProductType(00, "product", 5.99, 10);
            productRepository.Add(productType);
            productRepository.AdjustDescription(00, "not a product");
            Assert.AreEqual("not a product", productRepository.GetProduct(00).Description);
        }
        [TestMethod]
        public void CanHaveMultipleProducts()
        {
            ProductType product1 = new ProductType(00, "product", 5.99, 10);
            productRepository.Add(product1);
            ProductType product2 = new ProductType(01, "product2", 10.99, 50);
            productRepository.Add(product2);
            Assert.AreEqual("Product ID: " + 00 +
                            "Product description: product" +
                            "Product price: " + 5.99 +
                            "Product amount: " + 10 +
                            "Product ID: " + 01 +
                            "Product description: product2" +
                            "Product price: " + 10.99 +
                            "Product amount: " + 50, productRepository.GetProduct(00).ToString() +
                            productRepository.GetProduct(01).ToString());
        }
        [TestMethod]
        public void CanTrigerEvent()
        {

        }
        [TestMethod]
        public void CanSendEmail()
        {

        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Please input a price that is greater than or equal to 0.")]
        public void CanNotHaveNegativePrice()
        {
            ProductType product = new ProductType(00, "product", -5.99, 10);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Please input an amount that is greater than or equal to 0.")]
        public void CanNotHaveNegativeAmount()
        {
            ProductType product = new ProductType(00, "product", 5.99, -10);
        }
        
    }
}
