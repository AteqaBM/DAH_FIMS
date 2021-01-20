using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAH_FIMS.Model;
using Microsoft.EntityFrameworkCore;

namespace DAH_FIMS.Services
{
    public class WorkloadService
    {
        // Instance of the db context
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public WorkloadService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Workloads
        /// </summary>
        /// <returns>List of all Workloads</returns>
        public List<WORKLOAD> GetWorkloads()
        {
            return db.WORKLOADs.ToList();
        }

        /// <summary>
        /// Get a Workload
        /// </summary>
        /// <param name="id">Id of the Workload to return</param>
        /// <returns>A Workload with the provided id or null</returns>
        public WORKLOAD GetWorkload(int id)
        {
            return db.WORKLOADs.SingleOrDefault(c => c.WorkloadId == id);
        }

        /// <summary>
        /// Add a new Workload
        /// </summary>
        /// <param name="Workload">The Workload to add</param>
        /// <returns>True if Workload is added successfuly otherwise false</returns>
        public bool AddWorkload(WORKLOAD workload)
        {
            if (workload != null)
            {
                db.WORKLOADs.Add(workload);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a workload
        /// </summary>
        /// <param name="id">Id of the workload to delete</param>
        /// <returns>True if workload is deleted successfuly otherwise false</returns>
        public bool DeleteWorkload(int id)
        {
            var workload = db.WORKLOADs.Find(id);
            if (workload != null)
            {
                db.WORKLOADs.Remove(workload);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a workload
        /// </summary>
        /// <param name="school">workload object</param>
        public void EditWorkload(WORKLOAD workload)
        {
            // Change the state of the workload object to modified, so it will be update in database
            db.Entry(workload).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}