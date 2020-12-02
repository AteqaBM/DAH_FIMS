using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("TEACHER_ASSISTANT")]
    public partial class TEACHER_ASSISTANT
    {
        public TEACHER_ASSISTANT()
        {
            SECTIONs = new HashSet<SECTION>();
            WORKLOADs = new HashSet<WORKLOAD>();
        }

        [Key]
        public int EmployeeId { get; set; }
        public int TotalCredit { get; set; }
        public int TotalContactHours { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EMPLOYEE.TEACHER_ASSISTANT))]
        public virtual EMPLOYEE Employee { get; set; }
        [InverseProperty(nameof(SECTION.Employee))]
        public virtual ICollection<SECTION> SECTIONs { get; set; }
        [InverseProperty(nameof(WORKLOAD.Employee1))]
        public virtual ICollection<WORKLOAD> WORKLOADs { get; set; }
    }
}
