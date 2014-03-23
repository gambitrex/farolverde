using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace FarolVerde.Models.SPTrans
{
    public sealed class SPTransAPIManager
    {
        private static string SPTRANS_API_TOKEN = "463a618404cd3d881ebaf6439a7829be0312cfb1e26d763c8fc238e251f91f77";
        private static string SPTRANS_API_URL = "http://api.olhovivo.sptrans.com.br/v0";
        private static SPTransAPIManager _instance;
        static readonly object padlock = new object();

        SPTransAPIManager()
        {
        }

        public static SPTransAPIManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new SPTransAPIManager();
                    }
                    return _instance;
                }
            }
        }

        public string ConsumeSPTransAPI(string busNumber)
        {
            Contract.Requires<ArgumentNullException>(busNumber != null, "Parameter cannot be null.");
            string responseBody = "";
            CookieContainer cookies;
            CookieCollection login_cookies = new CookieCollection();
            int busId = 0;

            using (CookieAwareWebClient client = new CookieAwareWebClient())
            {
                var reqparm = new NameValueCollection();
                reqparm.Add("token", SPTRANS_API_TOKEN);

                var loginResponse = client.UploadValues(SPTRANS_API_URL + "/Login/Autenticar?token=" +
                                                        SPTRANS_API_TOKEN, "POST", reqparm);
                if ((new UTF8Encoding()).GetString(loginResponse) != "")
                {
                    // handle login error
                }

                cookies = client.m_container;
                login_cookies = client.m_container.GetCookies(client.m_address);
            }

            using (CookieAwareWebClient client = new CookieAwareWebClient())
            {
                try
                {
                    foreach (Cookie cookie in login_cookies)
                    {
                        cookies.Add(cookie);
                    }

                    client.m_container = cookies;
                    Stream stream = client.OpenRead(SPTRANS_API_URL + "/Linha/Buscar?termosBusca=" + busNumber);
                    StreamReader reader = new StreamReader(stream);
                    responseBody = reader.ReadToEnd();
                    dynamic searchResult = JsonConvert.DeserializeObject(responseBody);
                    busId = searchResult[0].CodigoLinha;
                    
                }
                catch (WebException ex)
                {
                    if (ex.Response is HttpWebResponse)
                    {
                        switch (((HttpWebResponse)ex.Response).StatusCode)
                        {
                            case HttpStatusCode.NotFound:
                                // TODO: Handle error
                                break;
                            default:
                                throw ex;
                        }
                    }
                }
            }

            using (CookieAwareWebClient client = new CookieAwareWebClient())
            {
                try
                {
                    
                    foreach (Cookie cookie in login_cookies)
                    {
                        cookies.Add(cookie);
                    }

                    client.m_container = cookies;
                    Stream stream = client.OpenRead(SPTRANS_API_URL + "/Linha/CarregarDetalhes?codigoLinha=");
                    
                    //Stream stream = client.OpenRead(SPTRANS_API_URL + "/Parada/BuscarParadasPorLinha?codigoLinha=" + busId);
                    StreamReader reader = new StreamReader(stream);
                    responseBody = reader.ReadToEnd();
                    
                }
                catch (WebException ex)
                {
                    if (ex.Response is HttpWebResponse)
                    {
                        switch (((HttpWebResponse)ex.Response).StatusCode)
                        {
                            case HttpStatusCode.NotFound:
                                // TODO: Handle error
                                break;
                            default:
                                throw ex;
                        }
                    }
                }
            }
            return responseBody;
        }


        // TODO: Handle error message from SPTrans API
        public dynamic GetBusStops(string busLineNumber)
        {
            Contract.Requires<ArgumentNullException>(busLineNumber != null, "Parameter cannot be null.");
            string response = ConsumeSPTransAPI(busLineNumber);

            return JsonConvert.DeserializeObject(response);
        }
    }
}