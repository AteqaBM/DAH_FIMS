using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("REQUEST_RESOURCE")]
    public partial class REQUEST_RESOURCE
    {
        [Key]
        public int RequestId { get; set; }
        [Key]
        public int ResourceId { get; set; }

        [ForeignKey(nameof(RequestId))]
        [InverseProperty(nameof(REQUEST.REQUEST_RESOURCEs))]
        public virtual REQUEST Request { get; set; }
        [ForeignKey(nameof(ResourceId))]
        [InverseProperty(nameof(RESOURCE.REQUEST_RESOURCEs))]
        public virtual RESOURCE Resource { get; set; }
    }
}
