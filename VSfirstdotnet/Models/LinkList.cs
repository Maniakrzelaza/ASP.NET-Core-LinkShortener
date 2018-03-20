using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSfirstdotnet.Models
{
    public class LinkList
    {

        public List<string> list = new List<string>();
        public List<string> Hashlist = new List<string>();
        public string link2 { get; set; }
        public int id { get; set; }
        public int getId() { return id; }
        public void setId(int a) { id = a; }

    }
}
