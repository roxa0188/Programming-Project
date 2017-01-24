using PrettyHairLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication
{

    public class Menu
    { 
        private ProductTypeRepository productType;

        public Menu(ProductTypeRepository productTypeRepo)
        {
            productType = productTypeRepo;
        }

        public void PrintMenu()
        {
            Console.WriteLine("1. View all product types");
            Console.WriteLine("2. Update product.");
            Console.WriteLine("3. Create Order");
            Console.WriteLine("4. Close");
        }

        public void ViewProductTypes()
        {
            Console.Clear();
            HeadLine("Show all products");
            Console.WriteLine(productType.ViewAllProducts());
        }

        public void PrintUpdateOptions()
        {
            HeadLine("Update Option for ProductType");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Change description");
            Console.WriteLine("2. Change price");
            Console.WriteLine("3. Change amount");
        }

        public void PrintUpdateAmountText()
        {
            HeadLine("Update amount by inputting a new value");
            Console.WriteLine("(*Note the value it cannot be below 0)");
        }

        public void PrintUpdatePriceText()
        {
            HeadLine("Update price by inputting a new value");
            Console.WriteLine("(*Note the value it cannot be below 0)");
        }

        public void HeadLine(string headLine)
        {
            Console.WriteLine("*------------------" + headLine + "------------------*");
        }
    }
}
