using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Table("EMPLOYEE")]
    [Index(nameof(FirstName), nameof(LastName), nameof(DepartmentId), Name = "IndexEmployeeDepartment")]
    [Index(nameof(FirstName), nameof(LastName), Name = "IndexEmployeeName")]
    public partial class EMPLOYEE
    {
        public EMPLOYEE()
        {
            RECEIVE_NOTIFICATIONs = new HashSet<RECEIVE_NOTIFICATION>();
        }

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string EmailAdress { get; set; }
        public int PhoneExtension { get; set; }
        public bool IsItPartTime { get; set; }
        public bool AcceptEmailNotification { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public int? OfficeId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(DEPARTMENT.EMPLOYEEs))]
        public virtual DEPARTMENT Department { get; set; }
        [ForeignKey(nameof(OfficeId))]
        [InverseProperty(nameof(OFFICE.EMPLOYEEs))]
        public virtual OFFICE Office { get; set; }
        [ForeignKey(nameof(PositionId))]
        [InverseProperty(nameof(POSITION.EMPLOYEEs))]
        public virtual POSITION Position { get; set; }
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
    }
}
