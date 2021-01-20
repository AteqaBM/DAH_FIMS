using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("FACULTY_COURSE")]
    public partial class FACULTY_COURSE
    {
        public FACULTY_COURSE()
        {
            SECTIONs = new HashSet<SECTION>();
        }

        [Key]
        public int FacultyCourseId { get; set; }
        [Required]
        [StringLength(20)]
        public string AcademicYear { get; set; }
        [Required]
        [StringLength(20)]
        public string Semester { get; set; }
        [Required]
        [StringLength(30)]
        public string CourseTeachingType { get; set; }
        public int TotalContactHours { get; set; }
        public int EmployeeId { get; set; }
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty(nameof(COURSE.FACULTY_COURSEs))]
        public virtual COURSE Course { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(FACULTY.FACULTY_COURSEs))]
        public virtual FACULTY Employee { get; set; }
        [InverseProperty(nameof(SECTION.FacultyCourse))]
        public virtual ICollection<SECTION> SECTIONs { get; set; }
    }


    public enum Semester
    {
        Fall = 1, Spring
    }

}
