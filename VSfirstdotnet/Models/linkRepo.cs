using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSfirstdotnet.Models
{
    public class linkRepo
    {
        public static List<string> list = new List<string>();
        public static void addToList(string s) { list.Add(s); }
        public static List<string> getList() { return list; }

        public static List<string> Hashlist = new List<string>();
        public static void addToHashList(string s) { Hashlist.Add(s); }
        public static List<string> getHashList() { return Hashlist; }
    }
}
