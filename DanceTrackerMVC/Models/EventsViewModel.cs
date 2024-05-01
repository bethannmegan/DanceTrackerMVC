using DanceTrackerDataAccess.Repositories;
using DanceTrackerDataAccess.Models;
using DanceTrackerMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceTrackerDataAccess.Context;

namespace DanceTrackerMVC.Models
{
    public class EventsViewModel
    {
        private EventsRepository _repo;

        public List<Events> EventList { get; set; }

        public Events CurrentEvent { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; }

        public EventsViewModel(DanceTrackerContextDB context)
        {
            _repo = new EventsRepository(context);
            EventList = GetAllEvents();
            CurrentEvent = EventList.FirstOrDefault();
        }

        public EventsViewModel(DanceTrackerContextDB context, int eventId)
        {
            _repo = new EventsRepository(context);
            EventList = GetAllEvents();

            if (eventId > 0)
            {
                CurrentEvent = GetEvent(eventId);
            }
            else
            {
                CurrentEvent = new Events();
            }
        }

        public void SaveEvent(Events eventEntry)
        {
            if (eventEntry.EventId > 0)
            {
                _repo.Update(eventEntry);
            }
            else
            {
                eventEntry.EventId = GetNextId();
                eventEntry.EventId = _repo.Create(eventEntry);
            }

            EventList = GetAllEvents();
            CurrentEvent = GetEvent(eventEntry.EventId);
        }

        public void RemoveEvent(int eventId)
        {
            _repo.Delete(eventId);
            EventList = GetAllEvents();
            CurrentEvent = EventList.FirstOrDefault();
        }

        public List<Events> GetAllEvents()
        {
            return _repo.GetAllEvents();
        }

        public Events GetEvent(int eventId)
        {
            return _repo.GetEventByID(eventId);
        }

        private int GetNextId()
        {
            int id = 1;
            var events = GetAllEvents();

            if (events != null && events.Any())
            {
                events = events.OrderByDescending(e => e.EventId).ToList();
                id = events[0].EventId + 1;
            }
            return id;
        }
    }
}
