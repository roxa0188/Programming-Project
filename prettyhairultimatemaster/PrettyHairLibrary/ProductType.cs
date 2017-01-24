using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{
    public class ProductType
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public ProductType(int ID, string Desc, double Price, int Amount)
        {
            this.ID = ID;
            this.Description = Desc;
            this.Price = Price;
            this.Amount = Amount;
        }

        private double price;
        private int  amount;
        public double SetPrice
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Please input a price that is greater than or equal to 0.");
                }
                else
                {
                    price = value;
                }
            }
        }
        public int SetAmount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Please input an amount that is greater than or equal to 0.");
                }
                else
                {
                    amount = value;
                }
            }
        }
        public override string ToString()
        {
            string output = "*---- Product ID: " + ID + "----*" +
                            "\n Product description: " + Description +
                            "\n Product price: " + Price +
                            "\n Product amount: " + Amount;
            return output;
        }
    }
}
