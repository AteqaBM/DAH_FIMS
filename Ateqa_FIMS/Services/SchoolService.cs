using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAH_FIMS.Model;
using Microsoft.EntityFrameworkCore;

namespace DAH_FIMS.Services
{
    public class SchoolService
    {
        // Instance of the db context
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public SchoolService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Schools
        /// </summary>
        /// <returns>List of all Schools</returns>
        public List<SCHOOL> GetSchools()
        {
            return db.SCHOOLs.ToList();
        }

        /// <summary>
        /// Get a School
        /// </summary>
        /// <param name="id">Id of the School to return</param>
        /// <returns>A School with the provided id or null</returns>
        public SCHOOL GetSchool(int id)
        {
            return db.SCHOOLs.SingleOrDefault(c => c.SchoolId == id);
        }

        /// <summary>
        /// Add a new School
        /// </summary>
        /// <param name="School">The School to add</param>
        /// <returns>True if School is added successfuly otherwise false</returns>
        public bool AddSchool(SCHOOL school)
        {
            if (school != null)
            {
                db.SCHOOLs.Add(school);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a school
        /// </summary>
        /// <param name="id">Id of the school to delete</param>
        /// <returns>True if school is deleted successfuly otherwise false</returns>
        public bool DeleteSchool(int id)
        {
            var school = db.SCHOOLs.Find(id);
            if (school != null)
            {
                db.SCHOOLs.Remove(school);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a school
        /// </summary>
        /// <param name="school">school object</param>
        public void EditSchool(SCHOOL school)
        {
            // Change the state of the school object to modified, so it will be update in database
            db.Entry(school).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}