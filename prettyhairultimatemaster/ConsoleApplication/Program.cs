using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHairLibrary;
using ConsoleApplication;

namespace CLI
{
    delegate void MenuDelegate();
    class Program
    {
        private bool isRunning;
        private ProductTypeRepository productTypeRepository = new ProductTypeRepository();
        private OrderRepository orderRepository = new OrderRepository();
        private Menu menu; 

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Init();
            myProgram.Run();

        }

        private void Init()
        {
            productTypeRepository.Add(new ProductType(1, "Gel", 30.0, 20));
            productTypeRepository.Add(new ProductType(2, "Extra large gel", 50.0, 10));

        }

        private void Run()
        {
            menu = new Menu(productTypeRepository);
            isRunning = true;

            while (isRunning)
            {
                menu.HeadLine("Pretty Hair");
                menu.PrintMenu();
                MenuSelectOption();
            }
        }

        public static void ViewProductTypes()
        {
            Console.Clear();
            Console.WriteLine("Show all products");
        }
        private void MenuSelectOption()
        {

            int option;
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 3:
                    isRunning = false;
                    break;
                case 1:
                    Console.Clear();
                    menu.ViewProductTypes();
                    break;
                case 2:
                    Console.Clear();
                    UpdateProductTypes();
                    break;
                default:
                    Console.WriteLine("Wrong input try again.");
                    break;
            }
        }

        private ProductType SelectProduct()
        {
            bool loopRunning = true;
            ProductType productType = null;
            while (loopRunning)
            { 
                Console.WriteLine(productTypeRepository.ViewAllProducts());
                int option;
                Console.WriteLine("Select a product by typing in the ID or enter 0 to go back: ");

                int.TryParse(Console.ReadLine(), out option);
                productType = productTypeRepository.GetProduct(option);

                if (productType == null)
                {
                    Console.WriteLine("Either incorrect input or the ID was not found");
                }
                else
                {
                    loopRunning = false;
                }
                if (option == 0) loopRunning = false;
            }
            return productType;
        }
        

        private void UpdateProductTypes()
        {
            ProductType productType;

            productType = SelectProduct();

            if (productType != null)
            {
                SelectUpdateProductTypeOption(productType.ID);
            }
        }

        private void SelectUpdateProductTypeOption(int id)
        {   
            string option;
            bool loopRunning = true;
            Console.Clear();
            while (loopRunning)
            {
                menu.PrintUpdateOptions();
                option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        loopRunning = false;    
                        break;
                    case "1":
                            Console.Clear();
                            UpdateProductTypeDescription(id);
                    break;
                    case "2":
                            Console.Clear();
                            UpdateProductTypePrice(id);
                    break;
                    case "3":
                            Console.Clear();
                            UpdateProductTypeAmount(id);
                    break;
                        default:
                        Console.Clear();
                        Console.WriteLine("Wrong input.");
                        break;
                }
                Console.Clear();
            }
        }

        private int ConsoleReadLineTryParseInteger()
        {
            int input;

            while(!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Wrong input.");
            }
            return input;
        }

        private double ConsoleReadLineTryParseDouble()
        {
            double input;
            while (!double.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Wrong input.");
            }
            return input;
        }


        private void UpdateProductTypePrice(int id)
        {
            double price = -1;
            menu.PrintUpdatePriceText();
            while (price < 0)
            {
                price = ConsoleReadLineTryParseDouble();
                if (price < 0) Console.WriteLine("Price cannot be below on");
            }
            productTypeRepository.AdjustPrice(id, price);
        }

        private void UpdateProductTypeDescription(int id)
        {
            string description = "";
            Console.WriteLine("Enter the description(can't be empty):");
            while (description == "")
            {
                description = Console.ReadLine();
                if (description == "") Console.WriteLine("Error: Description can't be empty");
            }
            productTypeRepository.AdjustDescription(id, description);
        }

        private void UpdateProductTypeAmount(int id)
        {
            int amount = -1;
            menu.PrintUpdateAmountText();
            while (amount < 0)
            {
                amount = ConsoleReadLineTryParseInteger();
            }
            productTypeRepository.AdjustAmount(id, amount);
        }
    }
}

