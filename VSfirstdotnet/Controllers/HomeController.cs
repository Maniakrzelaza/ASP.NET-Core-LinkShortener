using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;
using VSfirstdotnet.Models;
using System.Security.Cryptography;
namespace VSfirstdotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILinkRepo linkRepo;

        public HomeController(ILinkRepo repository)
        {
            this.linkRepo = repository;

        }

        [HttpGet]
        public IActionResult Index()
        {
            LinkList model = new LinkList();
            model.setList(linkRepo.Read());
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(LinkList model)
        {
            Link link = new Link();
            link.setLongLink(model.link2);
            link.setShortLink(link.shortenIt().Replace("https://goo.gl/", ""));
            linkRepo.Create(link);
            model.setList(linkRepo.Read());
            return View(model);
         
        }
        [HttpPost]
        public IActionResult IndexDelete(LinkList model)
        {
            linkRepo.Delete(model.getId());
            model.setList(linkRepo.Read());
            return View("Index", model);

        }
    }
}
