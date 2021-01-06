using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
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
        [Required(ErrorMessage = "The Date Of Birth field is required ")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage ="The Nationality field is required ")]
        [StringLength(30)]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "The Status field is required ")]
        [StringLength(10)]
        public string Status { get; set; }
        [Required(ErrorMessage = "The Mobile Number field is required ")]
        [StringLength(14)]
        [Phone(ErrorMessage = "Invalid Mobile Number Ex.(00966xxxxxxxxx)")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "The Highest Education field is required ")]
        [StringLength(50)]
        public string HighestEducation { get; set; }
        [Required(ErrorMessage = "The Institution field is required ")]
        [StringLength(50)]
        public string Institution { get; set; }
        [Required(ErrorMessage = "The Division field is required ")]
        [StringLength(50)]
        public string Division { get; set; }
        [Required(ErrorMessage = "The Type of Contract field is required ")]
        [StringLength(20)]
        public string TypeOfContract { get; set; }
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "The Date Needed field is required ")]
        public DateTime? DateNeeded { get; set; }
        [Required(ErrorMessage = "The Recruitment Status field is required ")]
        [StringLength(20)]
        public string RecruitmentStatus { get; set; }
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "The Application Date field is required ")]
        public DateTime? ApplicationDate { get; set; }
        public DateTime? HiringDate { get; set; }
        [Required(ErrorMessage = "The Rank field is required ")]
        [StringLength(20)]
        public string Rank { get; set; }
        public int? RequiredLoad { get; set; }
        public int? ConversionRate { get; set; }
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

    public enum ReqrutimentStatus
    {
        Pending = 1, Cancelled, Approved, Rejected
    }

    public enum Rank
    {
        Professor = 1, AssociateProfessor, AssistantProfessor, Lecturer
    }
        
}
