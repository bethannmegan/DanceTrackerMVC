using DanceTrackerDataAccess.Repositories;
using DanceTrackerDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceTrackerDataAccess.Context;

namespace DanceTrackerMVC.Models
{
    public class LessonsWorkshopsViewModel
    {
        private LessonsWorkshopsRepository _repo;

        public List<LessonsWorkshops> LessonList { get; set; }

        public LessonsWorkshops CurrentLesson { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; }

        public LessonsWorkshopsViewModel(DanceTrackerContextDB context)
        {
            _repo = new LessonsWorkshopsRepository(context);
            LessonList = GetAllLessons();
            CurrentLesson = LessonList.FirstOrDefault();
        }

        public LessonsWorkshopsViewModel(DanceTrackerContextDB context, int eventId)
        {
            _repo = new LessonsWorkshopsRepository(context);
            LessonList = GetAllLessons();

            if (eventId > 0)
            {
                CurrentLesson = GetLesson(eventId);
            }
            else
            {
                CurrentLesson = new LessonsWorkshops();
            }
        }

        public void SaveLesson(LessonsWorkshops lessonEntry)
        {
            if (lessonEntry.EventId > 0)
            {
                _repo.Update(lessonEntry);
            }
            else
            {
                lessonEntry.EventId = GetNextId();
                lessonEntry.EventId = _repo.Create(lessonEntry);
            }

            LessonList = GetAllLessons();
            CurrentLesson = GetLesson(lessonEntry.EventId);
        }

        public void RemoveLesson(int eventId)
        {
            _repo.Delete(eventId);
            LessonList = GetAllLessons();
            CurrentLesson = LessonList.FirstOrDefault();
        }

        public List<LessonsWorkshops> GetAllLessons()
        {
            return _repo.GetAllLessons();
        }

        public LessonsWorkshops GetLesson(int eventId)
        {
            return _repo.GetLessonByID(eventId);
        }

        private int GetNextId()
        {
            int id = 1;
            var lessons = GetAllLessons();

            if (lessons != null && lessons.Any())
            {
                lessons = lessons.OrderByDescending(e => e.EventId).ToList();
                id = lessons[0].EventId + 1;
            }
            return id;
        }
    }
}
