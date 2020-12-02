using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("RESOURCE")]
    public partial class RESOURCE
    {
        public RESOURCE()
        {
            REQUEST_RESOURCEs = new HashSet<REQUEST_RESOURCE>();
        }

        [Key]
        public int ResourceId { get; set; }
        [Required]
        public string ResourceName { get; set; }
        public int OfficeId { get; set; }

        [ForeignKey(nameof(OfficeId))]
        [InverseProperty(nameof(OFFICE.RESOURCEs))]
        public virtual OFFICE Office { get; set; }
        [InverseProperty(nameof(REQUEST_RESOURCE.Resource))]
        public virtual ICollection<REQUEST_RESOURCE> REQUEST_RESOURCEs { get; set; }
    }
}
