using DanceTrackerDataAccess.Context;
using DanceTrackerDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceTrackerDataAccess.Repositories
{
    public class CompsRepository
    {
        private DanceTrackerContextDB _context;

        public CompsRepository(DanceTrackerContextDB context)
        {
            _context = context;
        }

        public int Create(Comps compEntry)
        {

            _context.Add(compEntry);
            _context.SaveChanges();

            return compEntry.EventId;
        }

        public int Update(Comps compEntry)
        {
            Comps existingCompEntry = _context.Comps.Find(compEntry.EventId);

            existingCompEntry.EventDate = compEntry.EventDate;
            existingCompEntry.EventName = compEntry.EventName;
            existingCompEntry.Competitions = compEntry.Competitions;
            existingCompEntry.Division = compEntry.Division;
            existingCompEntry.DancePartners = compEntry.DancePartners;
            existingCompEntry.Results = compEntry.Results;
            existingCompEntry.Videos = compEntry.Videos;

            _context.SaveChanges();

            return existingCompEntry.EventId;
        }

        public bool Delete(int eventId)
        {
            Comps compEntry = _context.Comps.Find(eventId);
            _context.Remove(compEntry);
            _context.SaveChanges();

            return true;
        }

        public List<Comps> GetAllComps()
        {
            List<Comps> compsList = _context.Comps.ToList();

            return compsList;
        }

        public Comps GetCompByID(int eventId)
        {
            Comps compEntry = _context.Comps.Find(eventId);

            return compEntry;
        }
    }
}
