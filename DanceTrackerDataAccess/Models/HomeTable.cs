using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceTrackerDataAccess.Models 
{
    public class HomeTable
    {
        public int EventId {get; set;}

        public DateTime DateOfEvent { get; set; }

        public string? EventName { get; set; }

        public string? EventLocation { get; set; }

        public string? Competitions { get; set; }

        public string? LessonsAndWorkshops { get; set; }


    }
}
