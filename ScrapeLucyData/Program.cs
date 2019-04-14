using System;
using System.Collections.Generic;
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
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = 
                web.Load("https://www.bol.com/nl/t/top-10-windows-laptops/N/42976/?page=1&sort=rank");

            HtmlNode [] allproducts =
                document.DocumentNode.SelectNodes("//div[@class='product-item__content']").ToArray();

            HtmlNode[] titles =
                document.DocumentNode.SelectNodes("//a[@data-test='product-title']").ToArray();

            string title; 

            foreach (HtmlNode item in titles)
            {
                //get product title
                title = item.InnerText;
                Console.WriteLine("product name: " + title);
                //get product specs
                
                //options
                //get product price
            }
        }
    }
}
