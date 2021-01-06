using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
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
        [Required(ErrorMessage = "The Office Number field is required.")]
        [StringLength(6, ErrorMessage = "Office Number Should be 5 char")]
        [RegularExpression ("[0-3][0-9][0-9]", ErrorMessage ="Wrong Office Number Format. Ex. 009")]
        public string OfficeNumber { get; set; }
        [Required(ErrorMessage = "The Office Area field is required.")]
        public string OfficeArea { get; set; }
        [Required(ErrorMessage = "The Available Resources field is required.")]
        public string AvailableResources { get; set; }

        [InverseProperty(nameof(EMPLOYEE.Office))]
        public virtual ICollection<EMPLOYEE> EMPLOYEEs { get; set; }

        [InverseProperty(nameof(REQUEST.Office))]
        public virtual ICollection<REQUEST> REQUESTs { get; set; }
        [InverseProperty(nameof(RESOURCE.Office))]
        public virtual ICollection<RESOURCE> RESOURCEs { get; set; }
    }
}
