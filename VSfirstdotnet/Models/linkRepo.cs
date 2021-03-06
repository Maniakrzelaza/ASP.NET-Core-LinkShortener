﻿using Google.Apis.Services;
using Google.Apis.Urlshortener.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSfirstdotnet.Models
{
    public interface ILinkRepo
    {
        void Delete(int id);
        Link Create(Link link);
        List<Link> Read();
        Link Read(int id);
    }
        public class LinkRepo : ILinkRepo
    {


        private readonly LinkContext _dbContext;
        public LinkRepo(LinkContext context)
        {
            _dbContext = context;
        }
        


        public void Delete(int id)
        {
            Link link = _dbContext.links.Find(id);
            _dbContext.links.Remove(link);
            _dbContext.SaveChanges();
        }
        public Link Create(Link link)
        {
            _dbContext.links.Add(link);
            _dbContext.SaveChanges();
            return link;
        }

        public List<Link> Read()
        {
            List<Link>  search = _dbContext.links.ToList();
            return search;
        }

        public Link Read(int id)
        {
            return _dbContext.links.Find(id);
        }
    }
}
