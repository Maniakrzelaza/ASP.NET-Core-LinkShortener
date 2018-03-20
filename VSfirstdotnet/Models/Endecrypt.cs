using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Google.Apis.Urlshortener.v1;
using Google.Apis.Services;

namespace VSfirstdotnet.Models
{
    public class Endecrypt
    {
        
             public static string shortenIt(string url)
        {
            UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCW2o9pP9a6q4FMLcmt1TdUiIpFuSlpb44",
                ApplicationName = "VSfirstapp",
            });

            var m = new Google.Apis.Urlshortener.v1.Data.Url();
            m.LongUrl = url;
            return service.Url.Insert(m).Execute().Id;
        }

        public static string unShortenIt(string url)
        {
            UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCW2o9pP9a6q4FMLcmt1TdUiIpFuSlpb44",
                ApplicationName = "VSfirstapp",
            });
            return service.Url.Get(url).Execute().LongUrl;
        }
    }

}

