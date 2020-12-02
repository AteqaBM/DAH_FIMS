using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("IT_USER")]
    public partial class IT_USER
    {
        [Key]
        public int EmployeeId { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EMPLOYEE.IT_USER))]
        public virtual EMPLOYEE Employee { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SYSTEM_USER.IT_USERs))]
        public virtual SYSTEM_USER User { get; set; }
    }
}
