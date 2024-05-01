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
    public class LessonsWorkshopsController : Controller
    {
        private DanceTrackerContextDB _context;

        public LessonsWorkshopsController(DanceTrackerContextDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            LessonsWorkshopsViewModel model = new LessonsWorkshopsViewModel(_context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int eventId, string eventDate, string eventName, string privateLessons, string workshops, string videos)
        {
            LessonsWorkshopsViewModel model = new LessonsWorkshopsViewModel(_context);

            LessonsWorkshops lessonEntry = new(eventId, eventDate, eventName, privateLessons, workshops, videos);

            model.SaveLesson(lessonEntry);
            model.IsActionSuccess = true;
            model.ActionMessage = "Entry has been saved successfully!";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            LessonsWorkshopsViewModel model = new LessonsWorkshopsViewModel(_context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            LessonsWorkshopsViewModel model = new LessonsWorkshopsViewModel(_context);

            if (id > 0)
            {
                model.RemoveLesson(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Entry has been deleted successfully";
            return View("Index", model);
        }
    }
}
