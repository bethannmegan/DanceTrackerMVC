using DanceTrackerDataAccess.Repositories;
using DanceTrackerDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceTrackerDataAccess.Context;

namespace DanceTrackerMVC.Models
{
    public class CompsViewModel
    {
        private CompsRepository _repo;

        public List<Comps> CompList { get; set; }

        public Comps CurrentComp { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; }

        public CompsViewModel(DanceTrackerContextDB context)
        {
            _repo = new CompsRepository(context);
            CompList = GetAllComps();
            CurrentComp = CompList.FirstOrDefault();
        }

        public CompsViewModel(DanceTrackerContextDB context, int eventId)
        {
            _repo = new CompsRepository(context);
            CompList = GetAllComps();

            if (eventId > 0)
            {
                CurrentComp = GetComp(eventId);
            }
            else
            {
                CurrentComp = new Comps();
            }
        }

        public void SaveComp(Comps compEntry)
        {
            if (compEntry.EventId > 0)
            {
                _repo.Update(compEntry);
            }
            else
            {
                compEntry.EventId = GetNextId();
                compEntry.EventId = _repo.Create(compEntry);
            }

            CompList = GetAllComps();
            CurrentComp = GetComp(compEntry.EventId);
        }

        public void RemoveComp(int eventId)
        {
            _repo.Delete(eventId);
            CompList = GetAllComps();
            CurrentComp = CompList.FirstOrDefault();
        }

        public List<Comps> GetAllComps()
        {
            return _repo.GetAllComps();
        }

        public Comps GetComp(int eventId)
        {
            return _repo.GetCompByID(eventId);
        }

        private int GetNextId()
        {
            int id = 1;
            var comps = GetAllComps();

            if (comps != null && comps.Any())
            {
                comps = comps.OrderByDescending(e => e.EventId).ToList();
                id = comps[0].EventId + 1;
            }
            return id;
        }

    }
}

       
