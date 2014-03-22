using FarolVerde.Models;
using FarolVerde.Models.DataBase;
using FarolVerde.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FarolVerde.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetRoute(RouteRQ rq)
        {
            string response = "";
            string url = "http://maps.googleapis.com/maps/api/directions/json?sensor=false&region=br&origin=";
            url += rq.Origin.Name + "&destination=" + rq.Destination.Name + "&mode=transit&arrival_time=1343605500"; // +rq.ArrivalTime;
            //var url = "http://maps.googleapis.com/maps/api/directions/json?origin=Rua%20Dom%20Manuel%20D%27elboux,%20S%C3%A3o%20Paulo&destination=Rua%20Os%C3%ADris%20Magalhaes%20de%20Almeida,%20S%C3%A3o%20Paulo&sensor=false&region=br&mode=transit&arrival_time=1343605500";


            /*switch (switch_on)
            {
                default:
            }*/


            try
            {
                WebClient webClient = new WebClient();
                Stream stream = webClient.OpenRead(url);
                StreamReader reader = new StreamReader(stream);
                response = reader.ReadToEnd();
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse)
                {
                    switch (((HttpWebResponse)ex.Response).StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            //tratar erro
                            return null;
                            break;

                        default:
                            throw ex;
                    }
                }
            }


            dynamic obj = JsonConvert.DeserializeObject(response);

            /*if (obj.status != null)
            {
                // tratar erro
                return null;
            }*/



            return Json(response, JsonRequestBehavior.AllowGet);
        }





    }
}