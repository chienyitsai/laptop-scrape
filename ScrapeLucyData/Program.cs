using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ScrapeLucyData
{
    class Program
    {
        static void Main(string[] args)
        {
            //load html from website
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document =
                web.Load("https://www.bol.com/nl/t/top-10-windows-laptops/N/42976/?page=1&sort=rank");

            HtmlNode[] products =
                document.DocumentNode.SelectNodes("//div[@class='product-item__content']").ToArray();

            string title;
            HtmlNode[] spec;
            string inch;
            string display;
            string processor;
            string memory;
            string price;

            using (StreamWriter writer = new StreamWriter("bol.txt"))
            {
                //write header 
                writer.WriteLine
                    ("title" + "\t" + "inch" + "\t" + "display" + "\t" + "processor" + "\t"
                    + "memory" + "\t" + "price");
                foreach (var product in products)
                {
                    title =
                        product.SelectNodes(".//a[@data-test='product-title']")
                        .First().InnerText;
                    spec =
                        product.SelectNodes(".//span").ToArray();
                    inch = spec[0].InnerText;
                    display = spec[1].InnerText;
                    processor = spec[2].InnerText;
                    memory = spec[3].InnerText;
                    price =
                        product.SelectNodes(".//span[@data-test='price']")
                        .Where(x => x.InnerText.Contains('-')).First().InnerText;
                    price = price.Replace(",\n", "").Replace("-\n", "");
                    //write row
                    writer.WriteLine   
                        (title + "\t" + inch + "\t" + display + "\t" + processor + "\t"
                        + memory + "\t" + price);
                }

            }
        }
    }
}
