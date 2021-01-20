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
          
            return db.EMPLOYEEs
                .Include(e => e.Department)
                .Include(e => e.Position)
                .Include(e => e.Office)
                .ToList();
        }

        public EMPLOYEE GetEmployee(int id)
        {
            return db.EMPLOYEEs
                .Include(e => e.Department)
                .Include(e => e.Position)
                .Include(e => e.Office)
                .Include(e=> e.FACULTY)
                .SingleOrDefault(c => c.EmployeeId == id);
        }
        public List<EMPLOYEE> GetOfficeEmployees(int id)
        {
            return db.EMPLOYEEs.Where(c => c.OfficeId == id).ToList();
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


        public void Editprofile(EMPLOYEE employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
