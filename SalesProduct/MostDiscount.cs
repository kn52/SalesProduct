namespace SalesProduct
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class Sales
    {
        public string name;
        public string location;
        public string date;
        public string productName;
        public string price;
        public string paymentType;

        public Sales(string name, string location, string date, string productName, string price, string paymentType)
        {
            this.name = name;
            this.location = location;
            this.date = date;
            this.productName = productName;
            this.price = price;
            this.paymentType = paymentType;
        }
    }
    public class Product
    {
        public List<string> product = new List<string>();
        public void Register(string productName)
        {
            product.Add(productName);
        }
        public void GetNames(List<Sales> list, string checkProduct)
        {
            var name = list.Where(y => y.productName == checkProduct).OrderByDescending(x => x.price)
                    .Select(nm => nm.name).Last();
            Console.WriteLine(name);
        }
    }
    public class MostDiscount
    {
        public static void FindMostDiscountedPriceGivenToPerson()
        {
            Product product = new Product();
            product.Register("Samsung Battery");
            product.Register("Earphones");
            product.Register("USB Cable");
            List<Sales> salesList = new List<Sales>();
            try
            {
                using (var reader = new StreamReader(@"C:\Users\Kajal\Desktop\json\Test\sales.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        salesList.Add(new Sales(values[0], values[1], values[2], values[3].Trim(), values[4], values[5]));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            foreach (string productName in product.product)
            {
                product.GetNames(salesList, productName);
            }
        }
    }
}
