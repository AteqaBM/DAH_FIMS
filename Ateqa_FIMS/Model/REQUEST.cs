using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
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
        [Required(ErrorMessage = "The Resource field is required")]
        public string ResourceType { get; set; }
        [Required(ErrorMessage = "The Quantity field is required")]
        public int ResourceQuantity { get; set; }
        public string Note { get; set; }
     
        [Required(ErrorMessage = "The Request Date&Time field is required ")]
        public DateTime? RequestDateTime { get; set; }
        
        [Required(ErrorMessage = "The Delivery Date&Time field is required ")]
        public DateTime? DeliveryDateTime { get; set; }
        public int EmployeeId { get; set; }
        public int OfficeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EMPLOYEE.REQUESTs))]
        public virtual EMPLOYEE Employee { get; set; }
        [ForeignKey(nameof(OfficeId))]
        [InverseProperty(nameof(OFFICE.REQUESTs))]
        public virtual OFFICE Office { get; set; }
        [InverseProperty(nameof(NOTIFICATION.Request))]
        public virtual ICollection<NOTIFICATION> NOTIFICATIONs { get; set; }
        [InverseProperty(nameof(REQUEST_RESOURCE.Request))]
        public virtual ICollection<REQUEST_RESOURCE> REQUEST_RESOURCEs { get; set; }
    }



    public enum ResourceType
    {
        EquipmentResource = 1, ITResource , DoorSign
    }
}
