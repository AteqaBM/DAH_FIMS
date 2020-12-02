using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("SYSTEM_SUPERVISOR")]
    public partial class SYSTEM_SUPERVISOR
    {
        public SYSTEM_SUPERVISOR()
        {
            WORKLOADs = new HashSet<WORKLOAD>();
        }

        [Key]
        public int EmployeeId { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EMPLOYEE.SYSTEM_SUPERVISOR))]
        public virtual EMPLOYEE Employee { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SYSTEM_USER.SYSTEM_SUPERVISORs))]
        public virtual SYSTEM_USER User { get; set; }
        [InverseProperty(nameof(WORKLOAD.EmployeeNavigation))]
        public virtual ICollection<WORKLOAD> WORKLOADs { get; set; }
    }
}
