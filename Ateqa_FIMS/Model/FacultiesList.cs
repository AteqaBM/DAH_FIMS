﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Keyless]
    public partial class FacultiesList
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        public string PositionTitle { get; set; }
        public bool IsItPartTime { get; set; }
        [Required]
        [StringLength(100)]
        public string SchoolName { get; set; }
        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }
        [Required]
        [StringLength(20)]
        public string RecruitmentStatus { get; set; }
    }
}
