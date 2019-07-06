using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Linq;

namespace http_exchange
{
    class Http_Get
    {
        public static string Get()
        {
            string str;
            using (StreamReader stream = new StreamReader(WebRequest.Create(@"https://api.ratesapi.io/api/latest").GetResponse().GetResponseStream()))
                str = stream.ReadToEnd();
            return str;
        }

    }
}
