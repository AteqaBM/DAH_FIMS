using System;
using System.Collections.Generic;
using System.Linq;
using DAH_FIMS.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DAH_FIMS.Services
{
    public class OfficesService
    {
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public OfficesService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all offices
        /// </summary>
        /// <returns>List of all offices</returns>
        public List<OFFICE> GetProducts()
        {
            return db.OFFICEs.ToList();
        }

        /// <summary>
        /// Get a office
        /// </summary>
        /// <param name="id">Id of the office to return</param>
        /// <returns>A office with the provided id or null</returns>
        public OFFICE GetProduct(int id)
        {
            return db.OFFICEs.SingleOrDefault(c => c.OfficeId == id);
        }

        /// <summary>
        /// Assign an office
        /// </summary>
        /// <param name="office">The office to assign</param>
        /// <returns>True if office is added successfuly otherwise false</returns>
        public bool Assignoffice(OFFICE office)
        {
            if (office != null)
            {
                db.OFFICEs.Add(office);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete an office
        /// </summary>
        /// <param name="id">Id of the office to delete</param>
        /// <returns>True if office is deleted successfuly otherwise false</returns>
        public bool DeleteOffice(int id)
        {
            var office = db.OFFICEs.Find(id);
            if (office != null)
            {
                db.OFFICEs.Remove(office);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit an office assignment
        /// </summary>
        /// <param name="office">office object</param>
        public void EditOffice(OFFICE office)
        {
            // Change the state of the office object to modified, so it will be update in database
            db.Entry(office).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
