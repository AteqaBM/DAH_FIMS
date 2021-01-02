using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAH_FIMS.Model;
using Microsoft.EntityFrameworkCore;

namespace DAH_FIMS.Services
{
    public class DepartmentService
    {
        // Instance of the db context
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public DepartmentService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Departments
        /// </summary>
        /// <returns>List of all Departments</returns>
        public List<DEPARTMENT> GetDepartments()
        {
            return db.DEPARTMENTs.ToList();
        }

        /// <summary>
        /// Get a Department
        /// </summary>
        /// <param name="id">Id of the Department to return</param>
        /// <returns>A Department with the provided id or null</returns>
        public DEPARTMENT GetDepartment(int id)
        {
            return db.DEPARTMENTs
                .Include(s => s.School)
                .SingleOrDefault(c => c.DepartmentId == id);
        }

        /// <summary>
        /// Add a new Department
        /// </summary>
        /// <param name="Department">The Department to add</param>
        /// <returns>True if Department is added successfuly otherwise false</returns>
        public bool AddDepartment(DEPARTMENT department)
        {
            if (department != null)
            {
                db.DEPARTMENTs.Add(department);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a department
        /// </summary>
        /// <param name="id">Id of the department to delete</param>
        /// <returns>True if department is deleted successfuly otherwise false</returns>
        public bool DeleteDepartment(int id)
        {
            var department = db.DEPARTMENTs.Find(id);
            if (department != null)
            {
                db.DEPARTMENTs.Remove(department);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a department
        /// </summary>
        /// <param name="department">department object</param>
        public void EditDepartment(DEPARTMENT department)
        {
            // Change the state of the department object to modified, so it will be update in database
            db.Entry(department).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}