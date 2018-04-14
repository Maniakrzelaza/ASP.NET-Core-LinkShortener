using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSfirstdotnet.Models;

namespace VSfirstdotnet.Controllers
{

    [Route("linkApi")]
    [Route("Del")]
    public class LinkApiController : Controller
    {
        private readonly ILinkRepo linkRepo;
        public LinkApiController(ILinkRepo repository)
        {
            this.linkRepo = repository;

        }
        //GET LinkApi/Read?page=0
        [Route("Read")]
        [Route("{id}")]
        [HttpGet]
        public IActionResult Read(int page)
        {
            LinkPage linkPage=new LinkPage();
            double temp = Convert.ToDouble(linkRepo.Read().Count());
            linkPage.maxPage = ((int)Math.Ceiling(temp/20.0)-1)>=0 ? ((int)Math.Ceiling(temp / 20.0) - 1) : 0;
            linkPage.currentPage = page;
            linkPage.items = linkRepo.Read().OrderByDescending((theLink) => theLink.id).Skip(20 * page).Take(20);

            return Ok(linkPage);
        }
        //GET LinkApi/Delete?id=0&page=0
        [Route("Delete")]
        [Route("{id}")]
        [HttpGet]
        public IActionResult Delete(int id,int page)
        {
            linkRepo.Delete(id);
            LinkPage linkPage = new LinkPage();
            double temp = Convert.ToDouble(linkRepo.Read().Count());
            linkPage.maxPage = ((int)Math.Ceiling(temp / 20.0) - 1) >= 0 ? ((int)Math.Ceiling(temp / 20.0) - 1) : 0;
            linkPage.currentPage = page;
            linkPage.items = linkRepo.Read().OrderByDescending((theLink) => theLink.id).Skip(20 * page).Take(20);
            return Ok(linkPage);
        }
        [Route("GetLink")]
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetLink(string shortLink)
        {
            Link temp = new Link();
            temp.setShortLink("https://goo.gl/" + shortLink);
            string decoded = temp.unShortenIt();
            Object dec = new  {longLink= decoded};
            

            return Ok(dec);
        }
        [Route("AddLink")]
        [Route("{id}")]
        [HttpGet]
        public IActionResult AddLink(string longLink,int page)
        {

            Link link = new Link();
            link.setLongLink(longLink);
            link.setShortLink(link.shortenIt().Replace("https://goo.gl/", ""));
            linkRepo.Create(link);
            LinkPage linkPage = new LinkPage();
            double temp = Convert.ToDouble(linkRepo.Read().Count());
            linkPage.maxPage = ((int)Math.Ceiling(temp / 20.0) - 1) >= 0 ? ((int)Math.Ceiling(temp / 20.0) - 1) : 0;
            linkPage.currentPage = page;
            linkPage.items = linkRepo.Read().OrderByDescending((theLink) => theLink.id).Skip(20 * page).Take(20);

            return Ok(linkPage);
        }
    }
}
