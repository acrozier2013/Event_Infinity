using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Event_Infinity.Data;
using Event_Infinity.Models;

namespace Event_Infinity.Controllers
{
    public class HomeController : Controller
    {
        private Models.Event_InfinityDB db = new Models.Event_InfinityDB();
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

        public ActionResult EventSearch(string eventTypeSearched, string locationSearched)
        {
            var events = GetEvents(eventTypeSearched, locationSearched);
            return PartialView(events);
        }

        private List<Event> GetEvents(string eventTypeSearched, string locationSearched)
        {
            return db.Events
                .Where(a => a.EventType.Description.Contains(eventTypeSearched))
                .ToList();
        }
    }
}