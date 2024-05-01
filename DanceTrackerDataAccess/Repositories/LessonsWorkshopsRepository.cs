using DanceTrackerDataAccess.Context;
using DanceTrackerDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceTrackerDataAccess.Repositories
{
    public class LessonsWorkshopsRepository
    {
        private DanceTrackerContextDB _context;

        public LessonsWorkshopsRepository(DanceTrackerContextDB context)
        {
            _context = context;
        }

        public int Create(LessonsWorkshops lessonEntry)
        {

            _context.Add(lessonEntry);
            _context.SaveChanges();

            return lessonEntry.EventId;
        }

        public int Update(LessonsWorkshops lessonEntry)
        {
            LessonsWorkshops existingLessonEntry = _context.LessonsWorkshops.Find(lessonEntry.EventId);

            existingLessonEntry.EventDate = lessonEntry.EventDate;
            existingLessonEntry.EventName = lessonEntry.EventName;
            existingLessonEntry.PrivateLessons = lessonEntry.PrivateLessons;
            existingLessonEntry.Workshops = lessonEntry.Workshops;
            existingLessonEntry.Videos = lessonEntry.Videos;

            _context.SaveChanges();

            return existingLessonEntry.EventId;
        }

        public bool Delete(int eventId)
        {
            LessonsWorkshops lessonEntry = _context.LessonsWorkshops.Find(eventId);
            _context.Remove(lessonEntry);
            _context.SaveChanges();

            return true;
        }

        public List<LessonsWorkshops> GetAllLessons()
        {
            List<LessonsWorkshops> lessonsList = _context.LessonsWorkshops.ToList();

            return lessonsList;
        }

        public LessonsWorkshops GetLessonByID(int eventId)
        {
            LessonsWorkshops lessonEntry = _context.LessonsWorkshops.Find(eventId);

            return lessonEntry;
        }
    }
}
