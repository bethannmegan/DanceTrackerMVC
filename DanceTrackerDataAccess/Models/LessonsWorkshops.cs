using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceTrackerDataAccess.Models
{
    public class LessonsWorkshops
    {
        [Key]
        public int EventId { get; set; }

        public string EventDate { get; set; } = "";

        public string EventName { get; set; } = "";

        public string PrivateLessons { get; set; } = "";        

        public string Workshops { get; set; } = ""; 

        public string Videos { get; set; } = "";

        public LessonsWorkshops(int eventId, string eventDate, string eventName, string privateLessons, string workshops, string videos)
        {
            EventId = eventId;
            EventDate = eventDate;
            EventName = eventName;
            PrivateLessons = privateLessons;
            Workshops = workshops;
            Videos = videos;
        }

        public LessonsWorkshops() 
        { 
        
        }
    }
}
