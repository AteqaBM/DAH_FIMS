﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Table("OFFICE")]
    public partial class OFFICE
    {
        public OFFICE()
        {
            EMPLOYEEs = new HashSet<EMPLOYEE>();
            REQUESTs = new HashSet<REQUEST>();
            RESOURCEs = new HashSet<RESOURCE>();
        }

        [Key]
        public int OfficeId { get; set; }
        [Required]
        [StringLength(10)]
        public string OfficeNumber { get; set; }
        [Required]
        public string OfficeArea { get; set; }
        [Required]
        public string AvailableResources { get; set; }

        [InverseProperty(nameof(EMPLOYEE.Office))]
        public virtual ICollection<EMPLOYEE> EMPLOYEEs { get; set; }
        [InverseProperty(nameof(REQUEST.Office))]
        public virtual ICollection<REQUEST> REQUESTs { get; set; }
        [InverseProperty(nameof(RESOURCE.Office))]
        public virtual ICollection<RESOURCE> RESOURCEs { get; set; }
    }
}