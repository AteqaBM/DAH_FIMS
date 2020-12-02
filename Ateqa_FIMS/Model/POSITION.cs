using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("POSITION")]
    public partial class POSITION
    {
        public POSITION()
        {
            EMPLOYEEs = new HashSet<EMPLOYEE>();
        }

        [Key]
        public int PositionId { get; set; }
        [Required]
        public string PositionTitle { get; set; }

        //[InverseProperty(nameof(EMPLOYEE.Position))]
        [InverseProperty("Position")]
        public virtual ICollection<EMPLOYEE> EMPLOYEEs { get; set; }
    }
}
