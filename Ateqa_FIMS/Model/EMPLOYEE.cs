﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("EMPLOYEE")]
    [Index(nameof(FirstName), nameof(LastName), nameof(DepartmentId), Name = "IndexEmployeeDepartment")]
    [Index(nameof(FirstName), nameof(LastName), Name = "IndexEmployeeName")]
    public partial class EMPLOYEE
    {
        public EMPLOYEE()
        {
            RECEIVE_NOTIFICATIONs = new HashSet<RECEIVE_NOTIFICATION>();
            REQUESTs = new HashSet<REQUEST>();
            WORKLOADs = new HashSet<WORKLOAD>();

        }

        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "The First Name field is required ")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required ")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Email field is required ")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string EmailAdress { get; set; }
        [Required(ErrorMessage = "The Phone Extension field is required ")]
        [StringLength(3, ErrorMessage ="Phone Extention too long (3 char only).")]
        public string PhoneExtension { get; set; }
        public bool IsItPartTime { get; set; } = false;
        public bool AcceptEmailNotification { get; set; } = false;
        public int? PositionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? OfficeId { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(DEPARTMENT.EMPLOYEEs))]
        public virtual DEPARTMENT Department { get; set; }
        [ForeignKey(nameof(OfficeId))]
        [InverseProperty(nameof(OFFICE.EMPLOYEEs))]
        public virtual OFFICE Office { get; set; }
        [ForeignKey(nameof(PositionId))]
        [InverseProperty(nameof(POSITION.EMPLOYEEs))]
       
        public virtual POSITION Position { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SYSTEM_USER.EMPLOYEEs))]
        public virtual SYSTEM_USER User { get; set; }
        [InverseProperty("Employee")]
        public virtual CAADU_USER CAADU_USER { get; set; }
        [InverseProperty("Employee")]


        public virtual FACULTY FACULTY { get; set; }
        [InverseProperty("Employee")]
        public virtual HR_USER HR_USER { get; set; }
        [InverseProperty("Employee")]
        public virtual INFO_DESK_USER INFO_DESK_USER { get; set; }
        [InverseProperty("Employee")]
        public virtual IT_USER IT_USER { get; set; }
        [InverseProperty("Employee")]
        public virtual MAINTENANCE_USER MAINTENANCE_USER { get; set; }
        [InverseProperty("Employee")]
        public virtual SYSTEM_ADMIN SYSTEM_ADMIN { get; set; }
        [InverseProperty("Employee")]
        public virtual SYSTEM_ADMIN_ASSISTANT SYSTEM_ADMIN_ASSISTANT { get; set; }
        [InverseProperty("Employee")]
        public virtual SYSTEM_SUPERVISOR SYSTEM_SUPERVISOR { get; set; }
        [InverseProperty("Employee")]
        public virtual TEACHER_ASSISTANT TEACHER_ASSISTANT { get; set; }
        [InverseProperty(nameof(RECEIVE_NOTIFICATION.Employee))]
        public virtual ICollection<RECEIVE_NOTIFICATION> RECEIVE_NOTIFICATIONs { get; set; }

        [InverseProperty(nameof(REQUEST.Employee))]
        public virtual ICollection<REQUEST> REQUESTs { get; set; }

        [InverseProperty(nameof(WORKLOAD.Employee))]
        public virtual ICollection<WORKLOAD> WORKLOADs { get; set; }

    }

    public enum school
    {
        Business  = 1, Design, Health, Engineering
    }
}
