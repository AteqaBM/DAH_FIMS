using System;
using System.Collections.Generic;
using System.Linq;
using DAH_FIMS.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DAH_FIMS.Services
{
    public class RequestsService
    {
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public RequestsService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all requests
        /// </summary>
        /// <returns>List of all requests</returns>
        public List<REQUEST> GetRequests()
        {
            // Load the Employees
            Include(nameof(db.EMPLOYEEs));

            Include(nameof(db.POSITIONs));

            Include(nameof(db.OFFICEs));



            return db.REQUESTs.ToList();
        }

        /// <summary>
        /// Get a request
        /// </summary>
        /// <param name="id">Id of the request to return</param>
        /// <returns>A requests with the provided id or null</returns>
        public REQUEST GetRequest(int id)
        {
            return db.REQUESTs.SingleOrDefault(c => c.RequestId == id);
        }

        /// <summary>
        /// Add a new request
        /// </summary>
        /// <param name="request">The request to add</param>
        /// <returns>True if request is added successfuly otherwise false</returns>
        public bool AddRequest(REQUEST request)
        {
            if (request != null)
            {
                db.REQUESTs.Add(request);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete an request
        /// </summary>
        /// <param name="id">Id of the request to delete</param>
        /// <returns>True if request is deleted successfuly otherwise false</returns>
        public bool DeleteRequest(int id)
        {
            var request = db.REQUESTs.Find(id);
            if (request != null)
            {
                db.REQUESTs.Remove(request);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit an request 
        /// </summary>
        /// <param name="office">request object</param>
        public void EditRequest(REQUEST request)
        {
            //Change the state of the request object to modified, so it will be update in database
            db.Entry(request).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Load related navigational properties (eager loading)
        /// </summary>
        /// <param name="property">The navigational property to load</param>
        public void Include(string property)
        {
            var requests = db.REQUESTs.Include(property);
        }
    }
}
