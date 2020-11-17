using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Table("SYSTEM_ADMIN")]
    public partial class SYSTEM_ADMIN
    {
        public SYSTEM_ADMIN()
        {
            REQUESTs = new HashSet<REQUEST>();
        }

        [Key]
        public int EmployeeId { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EMPLOYEE.SYSTEM_ADMIN))]
        public virtual EMPLOYEE Employee { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SYSTEM_USER.SYSTEM_ADMINs))]
        public virtual SYSTEM_USER User { get; set; }
        [InverseProperty(nameof(REQUEST.Employee))]
        public virtual ICollection<REQUEST> REQUESTs { get; set; }
    }
}
