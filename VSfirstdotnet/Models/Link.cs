using Google.Apis.Services;
using Google.Apis.Urlshortener.v1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VSfirstdotnet.Models
{
    public class Link
    {
        public Link()
        {
        }
        public string longLink { get; set; }
        public string shortLink { get; set; }
        [Key]
        public int id { get; set; }
        public int getId() { return id; }
        public void setId(int a) { id = a; }
        public void setLongLink(string l) { this.longLink = l; }
        public string getLongLink() { return longLink; }
        public void setShortLink(string l) { this.shortLink = l; }
        public string getShortLink() { return shortLink; }
        public  string shortenIt()
        {
             UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
             {
                 ApiKey = " AIzaSyAx-OPO93_1Jk7w5stGQ7dU82K4jWoq2Fo ",
                 ApplicationName = "VSfirstapp",
             });

             var m = new Google.Apis.Urlshortener.v1.Data.Url();
             m.LongUrl = longLink;
             return service.Url.Insert(m).Execute().Id;
        }

        public  string unShortenIt()
        {
            UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
            {
                ApiKey = " AIzaSyAx-OPO93_1Jk7w5stGQ7dU82K4jWoq2Fo ",
                ApplicationName = "VSfirstapp",
            });
            return service.Url.Get(getShortLink()).Execute().LongUrl;
        }
    }

}
