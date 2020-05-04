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
            return PartialView("_EventSearch",  events);
        }

        private List<Event> GetEvents(string eventTypeSearched, string locationSearched)
        {
            return db.Events
                .Where(a => a.EventTitle.Contains(eventTypeSearched) && a.EventLocation.Contains(locationSearched))
                .ToList();
        }
         
        public ActionResult LastMinuteDeals()
        {
            var events = GetLastMinuteDeals();
            return PartialView("_LastMinuteDeals", events);
        }

        private List<Event> GetLastMinuteDeals()
        {


            return db.Events.ToList();
            //.Where(a => a.EventStartDate >= DateTime.Now.AddDays(-2))
                //.Where(a => a.EventStartDate >= DateTime.Now.Subtract(new TimeSpan(2,0,0,0)))
                //.Where(a => a.EventStartDate = a.EventStartDate && (a.EventStartDate - DateTime.Now).TotalDays.Equals("2")
                //.OrderBy(a => a.EventStartDate)
                //.First();

            //There are multiple ways to add and subtract dates.If you have 
            //    two DateTime objects you can call(EndDate - StartDate).TotalDays to return days as a fraction or(EndDate.Date -StartDate.Date).Days 
            //    if you want whole days.

            //.Where(p => p.StartDate > DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0)))

        }
    }
}