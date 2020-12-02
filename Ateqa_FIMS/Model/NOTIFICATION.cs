using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("NOTIFICATION")]
    public partial class NOTIFICATION
    {
        public NOTIFICATION()
        {
            GENERATE_NOTIFICATIONs = new HashSet<GENERATE_NOTIFICATION>();
            RECEIVE_NOTIFICATIONs = new HashSet<RECEIVE_NOTIFICATION>();
        }

        [Key]
        public int NotificationId { get; set; }
        public DateTime NotificationDateTime { get; set; }
        [Required]
        public string Content { get; set; }
        public int NotificationTypeId { get; set; }
        public int WorkloadId { get; set; }
        public int RequestId { get; set; }

        [ForeignKey(nameof(NotificationTypeId))]
        [InverseProperty(nameof(NOTIFICATION_TYPE.NOTIFICATIONs))]
        public virtual NOTIFICATION_TYPE NotificationType { get; set; }
        [ForeignKey(nameof(RequestId))]
        [InverseProperty(nameof(REQUEST.NOTIFICATIONs))]
        public virtual REQUEST Request { get; set; }
        [ForeignKey(nameof(WorkloadId))]
        [InverseProperty(nameof(WORKLOAD.NOTIFICATIONs))]
        public virtual WORKLOAD Workload { get; set; }
        [InverseProperty(nameof(GENERATE_NOTIFICATION.Notification))]
        public virtual ICollection<GENERATE_NOTIFICATION> GENERATE_NOTIFICATIONs { get; set; }
        [InverseProperty(nameof(RECEIVE_NOTIFICATION.Notification))]
        public virtual ICollection<RECEIVE_NOTIFICATION> RECEIVE_NOTIFICATIONs { get; set; }
    }
}
