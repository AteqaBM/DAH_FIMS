using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAH_FIMS.Model;
using Microsoft.EntityFrameworkCore;

namespace DAH_FIMS.Services
{
    public class FacultyService
    {
        // Instance of the db context
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public FacultyService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Faculties
        /// </summary>
        /// <returns>List of all Faculties</returns>
        public List<FACULTY> GetFaculties()
        {
            return db.FACULTies.ToList();
        }

        /// <summary>
        /// Get a Faculty
        /// </summary>
        /// <param name="id">Id of the Faculty to return</param>
        /// <returns>A Faculty with the provided id or null</returns>
        public FACULTY GetFaculty(int id)
        {
            return db.FACULTies.SingleOrDefault(c => c.EmployeeId == id);
        }

        //public List<FACULTY> GetFacultEmployees(int id)
        //{
        //    return db.FACULTies.Where(c => c.EmployeeId == id).ToList();
        //}

        /// <summary>
        /// Add a new Faculty
        /// </summary>
        /// <param name="Faculty">The Faculty to add</param>
        /// <returns>True if Faculty is added successfuly otherwise false</returns>
        public bool AddFaculty(FACULTY faculty)
        {
            if (faculty != null)
            {
                db.FACULTies.Add(faculty);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a faculty
        /// </summary>
        /// <param name="id">Id of the faculty to delete</param>
        /// <returns>True if faculty is deleted successfuly otherwise false</returns>
        public bool DeleteFaculty(int id)
        {
            var faculty = db.FACULTies.Find(id);
            if (faculty != null)
            {
                db.FACULTies.Remove(faculty);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a faculty
        /// </summary>
        /// <param name="faculty">faculty object</param>
        public void EditFaculty(FACULTY faculty)
        {
            // Change the state of the faculty object to modified, so it will be update in database
            db.Entry(faculty).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}