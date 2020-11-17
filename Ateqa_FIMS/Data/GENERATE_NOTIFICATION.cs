using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Table("GENERATE_NOTIFICATION")]
    public partial class GENERATE_NOTIFICATION
    {
        [Key]
        public int NotificationId { get; set; }
        [Key]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(FACULTY.GENERATE_NOTIFICATIONs))]
        public virtual FACULTY Employee { get; set; }
        [ForeignKey(nameof(NotificationId))]
        [InverseProperty(nameof(NOTIFICATION.GENERATE_NOTIFICATIONs))]
        public virtual NOTIFICATION Notification { get; set; }
    }
}
