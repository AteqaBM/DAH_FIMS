using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("DEPARTMENT")]
    [Index(nameof(DepartmentName), Name = "IndexDepartmentName")]
    public partial class DEPARTMENT
    {
        public DEPARTMENT()
        {
            COURSEs = new HashSet<COURSE>();
            EMPLOYEEs = new HashSet<EMPLOYEE>();
        }

        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "The Department Name field is required.")]
        [StringLength(100)]
        public string DepartmentName { get; set; }
        public int? SchoolId { get; set; }

        [ForeignKey(nameof(SchoolId))]
        [InverseProperty(nameof(SCHOOL.DEPARTMENTs))]
        public virtual SCHOOL School { get; set; }
        [InverseProperty(nameof(COURSE.Department))]
        public virtual ICollection<COURSE> COURSEs { get; set; }
        [InverseProperty(nameof(EMPLOYEE.Department))]
        public virtual ICollection<EMPLOYEE> EMPLOYEEs { get; set; }
    }
}
