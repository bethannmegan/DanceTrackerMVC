using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceTrackerDataAccess.Models
{
    public class Comps
    {
        [Key]
        public int EventId { get; set; }
        public string EventDate { get; set; } = "";

        public string EventName { get; set; } = "";

        public string Competitions { get; set; } = "";

        public string Division { get; set; } = "";

        public string DancePartners { get; set; } = "";

        public string Results { get; set; } = "";

        public string Videos { get; set; } = "";

        public Comps(int eventId, string eventDate, string eventName, string competitions, string division, string dancePartners, string results, string videos)
        {
            EventId = eventId;
            EventDate = eventDate;
            EventName = eventName;
            Competitions = competitions;
            Division = division;
            DancePartners = dancePartners;
            Results = results;
            Videos = videos;
        }

        public Comps()
        {

        }

    }
}
