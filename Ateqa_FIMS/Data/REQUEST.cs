using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Table("REQUEST")]
    [Index(nameof(RequestId), nameof(ResourceQuantity), nameof(DeliveryDateTime), Name = "IndexRequestDeliveryDateTime")]
    public partial class REQUEST
    {
        public REQUEST()
        {
            NOTIFICATIONs = new HashSet<NOTIFICATION>();
            REQUEST_RESOURCEs = new HashSet<REQUEST_RESOURCE>();
        }

        [Key]
        public int RequestId { get; set; }
        [Required]
        public string ResourceType { get; set; }
        public int ResourceQuantity { get; set; }
        public string Note { get; set; }
        public DateTime RequestDateTime { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public int EmployeeId { get; set; }
        public int OfficeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(SYSTEM_ADMIN.REQUESTs))]
        public virtual SYSTEM_ADMIN Employee { get; set; }
        [ForeignKey(nameof(OfficeId))]
        [InverseProperty(nameof(OFFICE.REQUESTs))]
        public virtual OFFICE Office { get; set; }
        [InverseProperty(nameof(NOTIFICATION.Request))]
        public virtual ICollection<NOTIFICATION> NOTIFICATIONs { get; set; }
        [InverseProperty(nameof(REQUEST_RESOURCE.Request))]
        public virtual ICollection<REQUEST_RESOURCE> REQUEST_RESOURCEs { get; set; }
    }
}
