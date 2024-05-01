using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceTrackerDataAccess.Models 
{
    public class Events
    {
        [Key]
        public int EventId {get; set;}

        public string EventDate { get; set; } = "";

        public string EventName { get; set; } = "";

        public string EventLocation { get; set; } = "";

        public string Competitions { get; set; } = "";

        public string LessonsAndWorkshops { get; set; } = "";

        public Events(int eventId, string eventDate, string eventName, string eventLocation, string competitions, string lessonsAndWorkshops)
        {
            EventId = eventId;
            EventDate = eventDate;
            EventName = eventName;
            EventLocation = eventLocation;
            Competitions = competitions;
            LessonsAndWorkshops = lessonsAndWorkshops;
        }

        public Events()
        {

        }

    }
}
