using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Keyless]
    public partial class Office_Information
    {
        [Required]
        [StringLength(10)]
        public string OfficeNumber { get; set; }
        [Required]
        public string AvailableResources { get; set; }
        [Required]
        public string ResourceType { get; set; }
        public DateTime DeliveryDateTime { get; set; }
    }
}
