using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("COURSE")]
    public partial class COURSE
    {
        public COURSE()
        {
            FACULTY_COURSEs = new HashSet<FACULTY_COURSE>();
        }

        [Key]
        public int CourseId { get; set; }
        [Required]
        [StringLength(20)]
        public string CourseCode { get; set; }
        [Required]
        public string CourseTitle { get; set; }
        [Required]
        [StringLength(20)]
        public string CourseType { get; set; }
        public string CourseDetails { get; set; }
        public int CourseCredits { get; set; }
        public int RequiredContactHours { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(DEPARTMENT.COURSEs))]
        public virtual DEPARTMENT Department { get; set; }
        [InverseProperty(nameof(FACULTY_COURSE.Course))]
        public virtual ICollection<FACULTY_COURSE> FACULTY_COURSEs { get; set; }
    }
}
