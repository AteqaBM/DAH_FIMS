using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAH_FIMS.Model;
using Microsoft.EntityFrameworkCore;

namespace DAH_FIMS.Services
{
    public class TAService 
    {
        // Instance of the db context
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public TAService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all TA'S
        /// </summary>
        /// <returns>List of all TA'S</returns>
        public List<TEACHER_ASSISTANT> GetTAs()
        {
            return db.TEACHER_ASSISTANTs.ToList();
        }

        /// <summary>
        /// Get a TA
        /// </summary>
        /// <param name="id">Id of the TA to return</param>
        /// <returns>A TA with the provided id or null</returns>
        public TEACHER_ASSISTANT GetTA(int id)
        {
            return db.TEACHER_ASSISTANTs.SingleOrDefault(c => c.EmployeeId == id);
        }

        /// <summary>
        /// Add a new TA
        /// </summary>
        /// <param name="TA">The TA to add</param>
        /// <returns>True if TA is added successfuly otherwise false</returns>
        public bool AddTA(TEACHER_ASSISTANT ta)
        {
            if (ta != null)
            {
                db.TEACHER_ASSISTANTs.Add(ta);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a TA
        /// </summary>
        /// <param name="id">Id of the TA to delete</param>
        /// <returns>True if TA is deleted successfuly otherwise false</returns>
        public bool DeleteTA(int id)
        {
            var ta = db.TEACHER_ASSISTANTs.Find(id);
            if (ta != null)
            {
                db.TEACHER_ASSISTANTs.Remove(ta);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a TA
        /// </summary>
        /// <param name="TA">TA object</param>
        public void EditTA(TEACHER_ASSISTANT ta)
        {
            // Change the state of the TA object to modified, so it will be update in database
            db.Entry(ta).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}