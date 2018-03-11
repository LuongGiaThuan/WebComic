using HtmlAgilityPack;
using System;
using System.Linq;

namespace TestFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var domain = "https://hamtruyen.com";
            var url = "https://hamtruyen.com/doc-truyen/nguyen-muc-chapter-179.html";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            //var alink = doc.DocumentNode.Descendants("a").Where(e => e.ParentNode.Attributes["class"] != null && e.ParentNode.Attributes["class"].Value == "col_chap tenChapter");
            var imglink= doc.DocumentNode.Descendants("img")
                            .Where(e => 
                                e.ParentNode.Attributes["class"] != null 
                                && 
                                e.ParentNode.Attributes["class"].Value == "content_chap");
            imglink.ToList().ForEach(e => Console.WriteLine(e.Attributes["src"].Value));
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
