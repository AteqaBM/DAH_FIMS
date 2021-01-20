using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAH_FIMS.Model;
using Microsoft.EntityFrameworkCore;

namespace DAH_FIMS.Services
{
    public class CourseService
    {
        // Instance of the db context
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public CourseService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <returns>List of all Courses</returns>
        public List<COURSE> GetCourses()
        {
            return db.COURSEs.ToList();
        }

        /// <summary>
        /// Get a Course
        /// </summary>
        /// <param name="id">Id of the Course to return</param>
        /// <returns>A Course with the provided id or null</returns>
        public COURSE GetCourse(int id)
        {
            return db.COURSEs.SingleOrDefault(c => c.CourseId == id);
        }

        /// <summary>
        /// Add a new Course
        /// </summary>
        /// <param name="Course">The Course to add</param>
        /// <returns>True if Course is added successfuly otherwise false</returns>
        public bool AddCourse(COURSE course)
        {
            if (course != null)
            {
                db.COURSEs.Add(course);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a course
        /// </summary>
        /// <param name="id">Id of the course to delete</param>
        /// <returns>True if course is deleted successfuly otherwise false</returns>
        public bool DeleteCourse(int id)
        {
            var course = db.COURSEs.Find(id);
            if (course != null)
            {
                db.COURSEs.Remove(course);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a course
        /// </summary>
        /// <param name="course">course object</param>
        public void EditCourse(COURSE course)
        {
            // Change the state of the course object to modified, so it will be update in database
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}