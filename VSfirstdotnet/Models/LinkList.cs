using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSfirstdotnet.Models
{
    public class LinkList
    {

        public List<Link> list;
        public string link2 { get; set; }
        public int id { get; set; }
        public int getId() { return id; }
        public void setId(int a) { id = a; }
        public void setList(List<Link> l) { this.list = l; }
    }
}
