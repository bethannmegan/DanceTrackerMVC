using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceTrackerMVC.Controllers;
using DanceTrackerMVC.Models;
using DanceTrackerDataAccess.Context;
using DanceTrackerDataAccess.Models;

namespace DanceTrackerMVC.Controllers
{
    public class EventsController : Controller
    {
        private DanceTrackerContextDB _context;

        public EventsController(DanceTrackerContextDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            EventsViewModel model = new EventsViewModel(_context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int eventId, string eventDate, string eventName, string eventLocation, string competitions, string lessonsAndWorkshops)
        {
            EventsViewModel model = new EventsViewModel(_context);

            Events eventEntry = new(eventId, eventDate, eventName, eventLocation, competitions, lessonsAndWorkshops);

            model.SaveEvent(eventEntry);
            model.IsActionSuccess = true;
            model.ActionMessage = "Entry has been saved successfully!";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            EventsViewModel model = new EventsViewModel(_context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            EventsViewModel model = new EventsViewModel(_context);

            if (id > 0)
            {
                model.RemoveEvent(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Entry has been deleted successfully";
            return View("Index", model);
        }
    }
}
