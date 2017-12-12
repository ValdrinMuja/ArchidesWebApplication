using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ArchidesArchitectureWeb.Controllers
{
    public class HomeController : Controller
    {
        public string defaultemailReceiver = "fisnikbrexhepi@gmail.com";
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }//k

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
        
    }
}