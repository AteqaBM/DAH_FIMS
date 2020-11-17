using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Table("RECEIVE_NOTIFICATION")]
    public partial class RECEIVE_NOTIFICATION
    {
        [Key]
        public int EmployeeId { get; set; }
        [Key]
        public int NotificationId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EMPLOYEE.RECEIVE_NOTIFICATIONs))]
        public virtual EMPLOYEE Employee { get; set; }
        [ForeignKey(nameof(NotificationId))]
        [InverseProperty(nameof(NOTIFICATION.RECEIVE_NOTIFICATIONs))]
        public virtual NOTIFICATION Notification { get; set; }
    }
}
