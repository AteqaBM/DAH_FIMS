using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Keyless]
    public partial class TAList
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }
        public int SectionId { get; set; }
        public int Workload { get; set; }
        public bool IsItApproved { get; set; }
    }
}
