using FarolVerde.Models;
using FarolVerde.Models.DataBase;
using FarolVerde.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarolVerde.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var x1 = Veiculo.Get();

            var x2 = Vitima.Get();

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
            return Json(new RouteRS());
        }
    }
}