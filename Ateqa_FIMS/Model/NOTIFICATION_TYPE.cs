using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("NOTIFICATION_TYPE")]
    public partial class NOTIFICATION_TYPE
    {
        public NOTIFICATION_TYPE()
        {
            NOTIFICATIONs = new HashSet<NOTIFICATION>();
        }

        [Key]
        public int NotificationTypeId { get; set; }
        [Required]
        public string Type { get; set; }

        [InverseProperty(nameof(NOTIFICATION.NotificationType))]
        public virtual ICollection<NOTIFICATION> NOTIFICATIONs { get; set; }
    }
}
