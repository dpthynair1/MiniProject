using System;
using System.Globalization;
using System.Linq;

namespace CurrencyCoverter
{
    public class method
    {
        public method()
        {



        }

        Currency cs = new Currency();
        double final;
        TextInfo myT = new CultureInfo("en-US", false).TextInfo;


        public string ProductModel()
        {
            Console.WriteLine("Enter Model");
            string model = Console.ReadLine();
            return model;
        }

        public double Price()
        {
            double prodPrice;
            double userPrice;
            Boolean validPrice;
            do
            {
                Console.WriteLine("Enter Price");

                if (double.TryParse(Console.ReadLine(), out userPrice))
                {
                    validPrice = true;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect value.");
                    validPrice = false;
                }

            } while (!validPrice);

            prodPrice = userPrice;


            return prodPrice;
        }

        public string currencyFormat(string input)
        {
            RegionInfo myRI1 = new RegionInfo(input);

            string format = myRI1.CurrencySymbol;

            return format;
        }

        public double ISOCurrencySymbol(string input)
        {

            RegionInfo RI = new RegionInfo(input);

            var toCurrency = RI.ISOCurrencySymbol;
            var fromCurrency = "USD";

            Console.WriteLine("Enter Price");
            double userPrice;
            var result = (double.TryParse(Console.ReadLine(), out userPrice));

            var dec = userPrice;

            double output;

            if (!(toCurrency == "USD"))
            {
                var ConvertedRate = cs.CurrencyConversion(dec, fromCurrency, toCurrency);
                output = double.Parse(ConvertedRate);
                final = Math.Round(output, 2);



            }

            return final;
        }


        public string GetRegionInfo(string nativeName)
        {
            var region = CultureInfo
           .GetCultures(CultureTypes.SpecificCultures)
           .Select(ci => new RegionInfo(ci.LCID))
           .FirstOrDefault(rg => rg.DisplayName == nativeName);

            var input = region.TwoLetterISORegionName;
            return input;
        }

        public DateTime PurchaseDate()
        {
            DateTime userDateTime;
            DateTime date;
            Boolean validDate;
            do
            {
                Console.WriteLine("Enter a date: ");

                if (DateTime.TryParse(Console.ReadLine(), out userDateTime))

                {
                    validDate = true;
                }

                else

                {
                    Console.WriteLine("You have entered an incorrect value.");
                    validDate = false;
                }

            } while (!validDate);


            date = userDateTime;
            return date;
        }


        public string ProductName()
        {
            Console.WriteLine("Enter Product Name");
            string prodName = Console.ReadLine();
            return myT.ToTitleCase(prodName);
        }

        public string Entry()
        {
            string Category;
            Console.WriteLine("Select a Category: Computer / Mobile");
            Category = Console.ReadLine();
            Category = myT.ToTitleCase(Category);


            return Category;
        }


        public void InvalidEntry()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Category");
            Console.ResetColor();

        }

        public int ExpiryDateCalculation(DateTime dateOnly)
        {
            DateTime expiry = dateOnly.AddYears(3);
            DateTime date2 = DateTime.Today;
            TimeSpan timeSpan = expiry - date2;
            double days = timeSpan.TotalDays;
            int daysLeft = Convert.ToInt32(days);

            return daysLeft;
        }
    }
}
