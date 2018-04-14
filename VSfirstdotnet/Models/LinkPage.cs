using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSfirstdotnet.Models
{
    public class LinkPage
    {
        public int maxPage { get; set; }
        public int currentPage { get; set; }
        public IEnumerable<Link> items {get; set;}

    }
}
