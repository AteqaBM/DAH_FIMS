using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Keyless]
    public partial class Faculty_List
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string EmailAdress { get; set; }
        public int PhoneExtension { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(30)]
        public string Nationality { get; set; }
        [Required]
        [StringLength(10)]
        public string Status { get; set; }
        [Required]
        [StringLength(20)]
        public string MobileNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string HighestEducation { get; set; }
        [Required]
        [StringLength(50)]
        public string Institution { get; set; }
        [Required]
        [StringLength(50)]
        public string Division { get; set; }
        [Required]
        [StringLength(20)]
        public string TypeOfContract { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateNeeded { get; set; }
        [Required]
        [StringLength(20)]
        public string RecruitmentStatus { get; set; }
        [Column(TypeName = "date")]
        public DateTime ApplicationDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? HiringDate { get; set; }
        [Required]
        [StringLength(20)]
        public string Rank { get; set; }
        public int? RequiredLoad { get; set; }
        public int? ConversionRate { get; set; }
        public bool IsItPartTime { get; set; }
    }
}
