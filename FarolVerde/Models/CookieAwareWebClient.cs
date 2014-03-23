using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace FarolVerde.Models
{
    public class CookieAwareWebClient : WebClient
    {
        public CookieContainer m_container = new CookieContainer();
        public Uri m_address;
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = m_container;
            }

            m_address = address;
            return request;
        }
    }
}