using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAH_FIMS.Model;
using Microsoft.EntityFrameworkCore;

namespace DAH_FIMS.Services
{
    public class FCService
    {
        // Instance of the db context
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public FCService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all FCourses
        /// </summary>
        /// <returns>List of all FCourses</returns>
        public List<FACULTY_COURSE> GetFCourses()
        {
            return db.FACULTY_COURSEs.ToList();
        }

        /// <summary>
        /// Get a FCourse
        /// </summary>
        /// <param name="id">Id of the FCourse to return</param>
        /// <returns>A Course with the provided id or null</returns>
        public FACULTY_COURSE GetFCourse(int id)
        {
            return db.FACULTY_COURSEs.SingleOrDefault(c => c.FacultyCourseId == id);
        }

        /// <summary>
        /// Add a new FCourse
        /// </summary>
        /// <param name="FCourse">The FCourse to add</param>
        /// <returns>True if FCourse is added successfuly otherwise false</returns>
        public bool AddFCourse(FACULTY_COURSE fCourse)
        {
            if (fCourse != null)
            {
                db.FACULTY_COURSEs.Add(fCourse);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a Fcourse
        /// </summary>
        /// <param name="id">Id of the Fcourse to delete</param>
        /// <returns>True if Fcourse is deleted successfuly otherwise false</returns>
        public bool DeleteFCourse(int id)
        {
            var fCourse = db.FACULTY_COURSEs.Find(id);
            if (fCourse != null)
            {
                db.FACULTY_COURSEs.Remove(fCourse);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a Fcourse
        /// </summary>
        /// <param name="Fcourse">Fcourse object</param>
        public void EditFCourse(FACULTY_COURSE fCourse)
        {
            // Change the state of the Fcourse object to modified, so it will be update in database
            db.Entry(fCourse).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}