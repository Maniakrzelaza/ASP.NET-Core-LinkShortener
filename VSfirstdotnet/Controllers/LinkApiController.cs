using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSfirstdotnet.Models;

namespace VSfirstdotnet.Controllers
{

    [Route("linkApi")]
    public class LinkApiController : Controller
    {
        private readonly ILinkRepo linkRepo;
        public LinkApiController(ILinkRepo repository)
        {
            this.linkRepo = repository;

        }
        //GET LinkApi/Read?page=0
        [Route("{id}")]
        [HttpGet]
        public IActionResult Read(int page)
        {
            var result = linkRepo.Read().Skip(20*page).Take(20);
            return Ok(result);
          //  return Ok("dfsd");
        }
    }
}
