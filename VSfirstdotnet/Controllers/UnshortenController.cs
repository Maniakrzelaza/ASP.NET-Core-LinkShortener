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
            string decoded = Endecrypt.unShortenIt("https://goo.gl/"+id);

            return Redirect(decoded);
        }
        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            // string decoded = Endecrypt.unShortenIt(Id);

            return Redirect("Home/Index");
        }
    }
}