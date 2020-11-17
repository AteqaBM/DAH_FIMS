using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Table("SECTION")]
    public partial class SECTION
    {
        [Key]
        public int SectionId { get; set; }
        [Required]
        [StringLength(20)]
        public string SectionNumber { get; set; }
        public string SectionDetails { get; set; }
        [Required]
        [StringLength(20)]
        public string AcademicYear { get; set; }
        [Required]
        [StringLength(20)]
        public string Semester { get; set; }
        public int EmployeeId { get; set; }
        public int FacultyCourseId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(TEACHER_ASSISTANT.SECTIONs))]
        public virtual TEACHER_ASSISTANT Employee { get; set; }
        [ForeignKey(nameof(FacultyCourseId))]
        [InverseProperty(nameof(FACULTY_COURSE.SECTIONs))]
        public virtual FACULTY_COURSE FacultyCourse { get; set; }
    }
}
