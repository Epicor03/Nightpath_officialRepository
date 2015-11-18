using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nightpath.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult Catalog()
        {
            return View();
        }

        public ActionResult ReadEstablishment()
        {
            return View();
        }

        public ActionResult CreateEvent()
        {
            return View();
        }
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

        public ActionResult Points()
        {
            ViewBag.Message = "Manage your points.";

            return View();
        }
        public ActionResult BankTransfer()
        {
            ViewBag.Message = "Bank Transfer Data";

            return View();
        }
    }
}