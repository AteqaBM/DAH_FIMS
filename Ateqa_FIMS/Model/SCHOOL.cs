using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("SCHOOL")]
    public partial class SCHOOL
    {
        public SCHOOL()
        {
            DEPARTMENTs = new HashSet<DEPARTMENT>();
        }

        [Key]
        public int SchoolId { get; set; }
        [Required]
        [StringLength(100)]
        public string SchoolName { get; set; }

        [InverseProperty(nameof(DEPARTMENT.School))]
        public virtual ICollection<DEPARTMENT> DEPARTMENTs { get; set; }
    }
}
