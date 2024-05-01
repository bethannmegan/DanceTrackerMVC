using DanceTrackerDataAccess.Context;
using DanceTrackerDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceTrackerDataAccess.Repositories
{
    public class EventsRepository
    {
        private DanceTrackerContextDB _context;

        public EventsRepository(DanceTrackerContextDB context)
        {
            _context = context;
        }

        public int Create(Events eventEntry)
        {

            _context.Add(eventEntry);
            _context.SaveChanges();

            return eventEntry.EventId;
        }

        public int Update(Events eventEntry)
        {
            Events existingeventEntry = _context.Events.Find(eventEntry.EventId);

            existingeventEntry.EventDate = eventEntry.EventDate;
            existingeventEntry.EventName = eventEntry.EventName;
            existingeventEntry.EventLocation = eventEntry.EventLocation;
            existingeventEntry.Competitions = eventEntry.Competitions;
            existingeventEntry.LessonsAndWorkshops = eventEntry.LessonsAndWorkshops;

            _context.SaveChanges();

            return existingeventEntry.EventId;
        }

        public bool Delete(int eventId)
        {
            Events eventEntry = _context.Events.Find(eventId);
            _context.Remove(eventEntry);
            _context.SaveChanges();

            return true;
        }

        public List<Events> GetAllEvents()
        {
            List<Events> eventsList = _context.Events.ToList();

            return eventsList;
        }

        public Events GetEventByID(int eventId)
        {
            Events eventEntry = _context.Events.Find(eventId);

            return eventEntry;
        }
    }
}
