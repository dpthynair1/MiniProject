using System;
namespace CurrencyCoverter.CurrencyExchange
{

    public class Computer : Product
    {
        private string model;
        private DateTime dateTime;
        private double prodPrice;

        public Computer()
        {
        }

        public Computer(string category, string prodName, string model, DateTime dateTime, double prodPrice)
        {
            Category = category;
            ProdName = prodName;
            this.model = model;
            this.dateTime = dateTime;
            this.prodPrice = prodPrice;
        }

        public Computer(string category, string location, string prodName, string modelName, DateTime purchaseDate, double price, string currentFormat)
        {
            Category = category;
            ProdName = prodName;
            PurchaseDate = purchaseDate;
            Price = price;
            ModelName = modelName;
            ModelName = modelName;
            CurrencyFormat = currentFormat;
            Location = location;
        }

        string symbol;

        public string CurrencyFormat
        {
            get
            {

                return symbol;
            }
            set
            {
                symbol = value;
            }
        }

        public override string Log() => $"{Location.PadRight(20)}{Category.PadRight(15)}{ProdName.PadRight(15)}{ModelName.PadRight(8)}{PurchaseDate.ToShortDateString().PadRight(8)}\t{Price.ToString().PadRight(10)}{CurrencyFormat.PadLeft(10)}";




        public override void LogByExpiry(int daysLeft)
        {

            if (daysLeft <= 90 && daysLeft > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(this.Log());
                Console.ResetColor();
            }
            else if (daysLeft <= 180 && daysLeft > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(this.Log());
                Console.ResetColor();
            }
            else if (daysLeft < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(this.Log());
                Console.ResetColor();
            }
        }



    }
}


