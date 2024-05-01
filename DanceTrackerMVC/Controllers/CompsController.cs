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
    public class CompsController : Controller
    {
        private DanceTrackerContextDB _context;

        public CompsController(DanceTrackerContextDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            CompsViewModel model = new CompsViewModel(_context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int eventId, string eventDate, string eventName, string competitions, string division, string dancePartners, string results, string videos)
        {
            CompsViewModel model = new CompsViewModel(_context);
            Comps compEntry = new(eventId, eventDate, eventName, competitions, division, dancePartners, results, videos);
            model.SaveComp(compEntry);
            model.IsActionSuccess = true;
            model.ActionMessage = "Entry has been saved successfully!";
            return View(model);
        }

        public IActionResult Update(int id)
        {
            CompsViewModel model = new CompsViewModel(_context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            CompsViewModel model = new CompsViewModel(_context);

            if (id > 0)
            {
                model.RemoveComp(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Entry has been deleted successfully";
            return View("Index", model);
        }
    }
}
