using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Keyless]
    public partial class Requests_List
    {
        [Required]
        [StringLength(10)]
        public string OfficeNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        public string ResourceName { get; set; }
        public int ResourceQuantity { get; set; }
        public DateTime RequestDateTime { get; set; }
        public DateTime DeliveryDateTime { get; set; }
    }
}
