using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VSfirstdotnet.Models;
namespace VSfirstdotnet.Controllers
{   
    [Route("Unshorten")]
    [Route("")]
    public class UnshortenController : Controller
    {
        [Route("{id}")]
        public IActionResult Index(string id)
        {
            Link temp = new Link();
            temp.setShortLink("https://goo.gl/" + id);
            string decoded = temp.unShortenIt();

            return Redirect(decoded);
        }
        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {

            return Redirect("Home/Index");
        }
    }
}