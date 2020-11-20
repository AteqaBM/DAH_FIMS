using DAH_FIMS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace DAH_FIMS.Services
{
    public class FacultyService
    {
        private readonly DahFIMSDbContext db;

        //private List<EMPLOYEE> employeesList;
        //private List<FACULTY> facultyList;
        //string departmentName;
        //string schoolName;

        // Constructor using dependency injection
        public FacultyService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all faculties
        /// </summary>
        /// <returns>List of all faculties</returns>
        public List<EMPLOYEE> GetFaculties()
        {
            //return db.EMPLOYEEs.Include("FACULTY").ToList();
            return db.EMPLOYEEs.ToList();
        }

        public EMPLOYEE GetFaculty (int id)
        {
            return db.EMPLOYEEs.SingleOrDefault(c => c.EmployeeId == id);
        }

        public bool Addprofile(EMPLOYEE faculty)
        {
            if (faculty != null)
            {
                db.EMPLOYEEs.Add(faculty);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void EditProfile(EMPLOYEE faculty)
        {
            db.Entry(faculty).State = EntityState.Modified;
            db.SaveChanges();
        }

        //public void showProfile(int id)
        //{
        //    employeesList = db.EMPLOYEEs.Where(c => c.EmployeeId == id).ToList();
        //    facultyList = db.FACULTies.Where(c => c.EmployeeId == id).ToList();
        //    departmentName = db.DEPARTMENTs.Where(c => c.DepartmentId == employeesList[0].DepartmentId).Select(c => c.DepartmentName).ToString();
        //    schoolName = db.SCHOOLs.Where(c => c.SchoolId == employeesList[0].Department.SchoolId).Select(c => c.SchoolName).ToString();
        //}
    }
}
