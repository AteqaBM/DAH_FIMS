using System;
using System.Collections.Generic;
using System.Linq;
using DAH_FIMS.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DAH_FIMS.Services
{
    public class ResourcesService
    {
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public ResourcesService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all resources
        /// </summary>
        /// <returns>List of all resources</returns>
        public List<RESOURCE> GetResources()
        {
            // Load the Employees
            Include(nameof(db.EMPLOYEEs));


            return db.RESOURCEs.ToList();
        }

        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="id">Id of the resource to return</param>
        /// <returns>A resource with the provided id or null</returns>
        public RESOURCE GetResource(int id)
        {
            return db.RESOURCEs.SingleOrDefault(c => c.ResourceId == id);
        }

        /// <summary>
        /// Add a new resource
        /// </summary>
        /// <param name="resource">The resource to add</param>
        /// <returns>True if resource is added successfuly otherwise false</returns>
        public bool AddResource(RESOURCE resource)
        {
            if (resource != null)
            {
                db.RESOURCEs.Add(resource);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete an resource
        /// </summary>
        /// <param name="id">Id of the resource to delete</param>
        /// <returns>True if resource is deleted successfuly otherwise false</returns>
        public bool DeleteResource(int id)
        {
            var resource = db.RESOURCEs.Find(id);
            if (resource != null)
            {
                db.RESOURCEs.Remove(resource);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit an resource 
        /// </summary>
        /// <param name="resource">resource object</param>
        public void EditResource(RESOURCE resource)
        {
            //Change the state of the resource object to modified, so it will be update in database
            db.Entry(resource).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Load related navigational properties (eager loading)
        /// </summary>
        /// <param name="property">The navigational property to load</param>
        public void Include(string property)
        {
            var resourceS = db.RESOURCEs.Include(property);
        }
    }
}
