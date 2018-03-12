using API.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ThiefController : Controller
    {
        // GET: api/Thief
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET: api/Thief/5
        [HttpGet("/api/[controller]/[action]/hamtruyen")]
        public IActionResult GetChapter(string url)
        {
            var domain = "https://hamtruyen.com";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var allChapter = doc.DocumentNode.Descendants("a")
                            .Where(e =>
                                    e.ParentNode.Attributes["class"] != null
                                    &&
                                    e.ParentNode.Attributes["class"].Value == "col_chap tenChapter");
            var linkAllChapter = allChapter.Select(e => domain + e.Attributes["href"].Value);
            return Ok(linkAllChapter);
        }
        [HttpGet("/api/[controller]/[action]/hamtruyen")]
        public IActionResult GetImgChapter(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var imglink = doc.DocumentNode.Descendants("img")
                             .Where(e =>
                                 e.ParentNode.Attributes["class"] != null
                                 &&
                                 e.ParentNode.Attributes["class"].Value == "content_chap");
            var linkAllImg = imglink.Select(e => new ChapterImg() { src = e.Attributes["src"].Value });
            return Ok(linkAllImg);
        }
    }
}
