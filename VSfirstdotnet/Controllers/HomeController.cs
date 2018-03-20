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
       
        [HttpGet]
        public IActionResult Index()
        {

            return View("IndexWithForm");
        }

        [HttpPost]
        public IActionResult Index(LinkList model)
        {
            linkRepo.addToList(model.link2);
            linkRepo.addToHashList(Endecrypt.shortenIt(model.link2).Replace("https://goo.gl/", ""));
            model.list = linkRepo.getList();
            model.Hashlist = linkRepo.getHashList();
            return View(model);
         
        }
        [HttpPost]
        public IActionResult IndexDelete(LinkList model)
        {

            
            model.list= linkRepo.getList();
            model.Hashlist = linkRepo.getHashList();
            model.list.RemoveAt(model.getId());
            model.Hashlist.RemoveAt(model.getId());
            return View("Index",model);

        }
    }
}
