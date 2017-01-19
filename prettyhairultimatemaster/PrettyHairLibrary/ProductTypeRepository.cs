using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{

    public class ProductTypeRepository
    {
        Dictionary<int, ProductType> listOfProductTypes = new Dictionary<int, ProductType>();

        public void Delete(int key)
        {
            listOfProductTypes.Remove(key);
           
        }

        public void Add(ProductType product)
        {
            listOfProductTypes.Add(product.ID, product);
        }

        public ProductType GetProduct(int key)
        {
            ProductType productType = null;
            if (listOfProductTypes.ContainsKey(key))
            {
                Console.WriteLine("true");
                productType = listOfProductTypes[key];
            }
            Console.WriteLine(key);

            return productType;
        }

        public void AdjustPrice(int key, double newPrice)
        {
            listOfProductTypes[key].Price = newPrice;
        }

        public void AdjustAmount(int key, int newAmount)
        {
            listOfProductTypes[key].Amount = newAmount;
        }

        public void AdjustDescription(int key, string newDescription)
        {
            listOfProductTypes[key].Description = newDescription;
        }


        public string ViewAllProducts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(KeyValuePair<int,ProductType> productType in listOfProductTypes){
                stringBuilder.Append(productType.Value);
                stringBuilder.Append("\n");
            }
            
            return stringBuilder.ToString();
        }

        public void UpdateProduct(int id, string description, double price, int amount)
        {
            ProductType productType = GetProduct(id);
            productType.Description = description;
            productType.Price = price;
            productType.Amount = amount;
        }
    }
}
