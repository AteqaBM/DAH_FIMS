using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Table("FACULTY")]
    public partial class FACULTY
    {
        public FACULTY()
        {
            FACULTY_COURSEs = new HashSet<FACULTY_COURSE>();
            GENERATE_NOTIFICATIONs = new HashSet<GENERATE_NOTIFICATION>();
            HIRING_DOCUMENTs = new HashSet<HIRING_DOCUMENT>();
            WORKLOADs = new HashSet<WORKLOAD>();
        }

        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(30)]
        public string Nationality { get; set; }
        [Required]
        [StringLength(10)]
        public string Status { get; set; }
        [Required]
        [StringLength(20)]
        public string MobileNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string HighestEducation { get; set; }
        [Required]
        [StringLength(50)]
        public string Institution { get; set; }
        [Required]
        [StringLength(50)]
        public string Division { get; set; }
        [Required]
        [StringLength(20)]
        public string TypeOfContract { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateNeeded { get; set; }
        [Required]
        [StringLength(20)]
        public string RecruitmentStatus { get; set; }
        [Column(TypeName = "date")]
        public DateTime ApplicationDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? HiringDate { get; set; }
        [Required]
        [StringLength(20)]
        public string Rank { get; set; }
        public int? RequiredLoad { get; set; }
        public int? ConversionRate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EMPLOYEE.FACULTY))]
        public virtual EMPLOYEE Employee { get; set; }
        [InverseProperty(nameof(FACULTY_COURSE.Employee))]
        public virtual ICollection<FACULTY_COURSE> FACULTY_COURSEs { get; set; }
        [InverseProperty(nameof(GENERATE_NOTIFICATION.Employee))]
        public virtual ICollection<GENERATE_NOTIFICATION> GENERATE_NOTIFICATIONs { get; set; }
        [InverseProperty(nameof(HIRING_DOCUMENT.Employee))]
        public virtual ICollection<HIRING_DOCUMENT> HIRING_DOCUMENTs { get; set; }
        [InverseProperty(nameof(WORKLOAD.Employee))]
        public virtual ICollection<WORKLOAD> WORKLOADs { get; set; }
    }
}

public enum FacultyStatus
{
    Single = 1, Married 
}
