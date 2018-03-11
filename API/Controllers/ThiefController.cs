using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("/api/[controller]/[action]/hamtruyen/{url}")]
        public IActionResult Get(string url)
        {

            return Ok(url);
        }
        
    }
}
