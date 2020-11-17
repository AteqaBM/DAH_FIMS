using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Table("WORKLOAD")]
    [Index(nameof(Workload1), nameof(LoadType), nameof(EmployeeId), Name = "IndexWorkload")]
    public partial class WORKLOAD
    {
        public WORKLOAD()
        {
            NOTIFICATIONs = new HashSet<NOTIFICATION>();
        }

        [Key]
        public int WorkloadId { get; set; }
        [Required]
        [StringLength(20)]
        public string Semester { get; set; }
        [Required]
        [StringLength(20)]
        public string AcademicYear { get; set; }
        [Column("Workload")]
        public int Workload1 { get; set; }
        [Required]
        [StringLength(20)]
        public string LoadType { get; set; }
        public bool IsItApproved { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(FACULTY.WORKLOADs))]
        public virtual FACULTY Employee { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(TEACHER_ASSISTANT.WORKLOADs))]
        public virtual TEACHER_ASSISTANT Employee1 { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(SYSTEM_SUPERVISOR.WORKLOADs))]
        public virtual SYSTEM_SUPERVISOR EmployeeNavigation { get; set; }
        [InverseProperty(nameof(NOTIFICATION.Workload))]
        public virtual ICollection<NOTIFICATION> NOTIFICATIONs { get; set; }
    }
}
