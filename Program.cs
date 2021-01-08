using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using CurrencyCoverter.CurrencyExchange;


namespace CurrencyCoverter
{
    class MainClass
    {
        static void Main(string[] args)
        {

            Currency cur = new Currency();




            List<Product> InventoryList = new List<Product>();

            method use = new method();

            DateTime dateTime = new DateTime();
            string Category;
            Boolean ValidRegion;
            string nativeName;
            int LocCtr = 0;
            string prompt = "y";

            while (prompt == "y")
            {
                do
                {

                    Console.WriteLine("Enter location ");
                    nativeName = Console.ReadLine();

                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

                    nativeName = myTI.ToTitleCase(nativeName);

                    var region = CultureInfo
                   .GetCultures(CultureTypes.SpecificCultures)
                   .Select(ci => new RegionInfo(ci.LCID))
                   .FirstOrDefault(rg => rg.DisplayName == nativeName);

                    if (region != null)
                    {
                        ValidRegion = true;
                        LocCtr++;
                    }
                    else
                        ValidRegion = false;

                } while (!ValidRegion);


                var regionInfo = use.GetRegionInfo(nativeName);

                Console.WriteLine();
                int Counter = 0;
                string exit = "y";
                while (exit == "y")
                {

                    Category = use.Entry();

                    if ((Category == "Computer") || (Category == "Mobile"))
                    {
                        string prodName = use.ProductName();
                        string model = use.ProductModel();
                        dateTime = use.PurchaseDate();


                        var ExchangeCurrency = use.ISOCurrencySymbol(regionInfo);
                        var currencySymbol = use.currencyFormat(regionInfo);
                        Console.WriteLine(ExchangeCurrency + currencySymbol);

                        if (Category == "Mobile")
                        {
                            Mobile mobile = new Mobile(Category, nativeName, prodName, model, dateTime, ExchangeCurrency, currencySymbol);
                            InventoryList.Add(mobile);
                        }
                        else
                        {


                            Computer computer = new Computer(Category, nativeName, prodName, model, dateTime, ExchangeCurrency, currencySymbol);
                            InventoryList.Add(computer);

                        }


                        Counter++;
                    }




                    else
                    {
                        use.InvalidEntry();
                    }

                    Console.WriteLine("Enter Y to enter more products or N to exit");
                    exit = Console.ReadLine();
                    exit = exit.ToLower();


                    ValidRegion = false;


                }

                Console.WriteLine("Enter Y to enter another location or N to exit");
                prompt = Console.ReadLine();
                prompt = prompt.ToLower();


            }

            Console.WriteLine("                   ****** Sorted by Class *****");
            Console.WriteLine("");
            InventoryList.OrderBy(item => item.GetType());

            foreach (var item in InventoryList)
            {

                int daysLeft = use.ExpiryDateCalculation(item.PurchaseDate);
                item.LogByExpiry(daysLeft);

            }


            Console.WriteLine("                   ****** Sorted by Price *****");
            Console.WriteLine("");

            var ordered = InventoryList.OrderBy(item => item.Price).ToList();
            foreach (var item in ordered)
            {
                int daysLeft = use.ExpiryDateCalculation(item.PurchaseDate);

                item.LogByExpiry(daysLeft);
            }
            Console.WriteLine("");

            Console.WriteLine("           ****** Sorted by Purchase Date *****");
            Console.WriteLine("");

            var SortedByDate = InventoryList.OrderBy(item => item.PurchaseDate).ToList();

            foreach (var item in SortedByDate)
            {
                int daysLeft = use.ExpiryDateCalculation(item.PurchaseDate);

                item.LogByExpiry(daysLeft);
            }

            Console.WriteLine("");


            Console.ReadLine();

        }




    }
}