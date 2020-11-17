using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Table("SYSTEM_ADMIN_ASSISTANT")]
    public partial class SYSTEM_ADMIN_ASSISTANT
    {
        [Key]
        public int EmployeeId { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EMPLOYEE.SYSTEM_ADMIN_ASSISTANT))]
        public virtual EMPLOYEE Employee { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SYSTEM_USER.SYSTEM_ADMIN_ASSISTANTs))]
        public virtual SYSTEM_USER User { get; set; }
    }
}
