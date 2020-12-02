using DAH_FIMS.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace DAH_FIMS.Services
{
    public class EmployeeService
    {
        // Instance of the db context
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public EmployeeService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>List of all employees</returns>
        public List<EMPLOYEE> GetEmployees()
        {
            //return db.EMPLOYEEs.Include("FACULTY").Include("DEPARTMENTs").Include("SCHOOLs").Include("POSITIONs").ToList();
           
            // Load the categories
            Include(nameof(db.FACULTies));
            Include(nameof(db.DEPARTMENTs));
            Include(nameof(db.SCHOOLs));
            Include(nameof(db.POSITIONs));

            return db.EMPLOYEEs.ToList();

        }

        public EMPLOYEE GetEmployee(int id)
        {
            return db.EMPLOYEEs.SingleOrDefault(c => c.EmployeeId == id);
        }

        public bool Addprofile(EMPLOYEE employee)
        {
            if (employee != null)
            {
                db.EMPLOYEEs.Add(employee);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// How to Archive a employee?
        /// </summary>


        public void EditProfile(EMPLOYEE employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Load related navigational properties (eager loading)
        /// </summary>
        /// <param name="property">The navigational property to load</param>
        public void Include(string property)
        {
            var employees = db.EMPLOYEEs.Include(property);
        }
    }
}
