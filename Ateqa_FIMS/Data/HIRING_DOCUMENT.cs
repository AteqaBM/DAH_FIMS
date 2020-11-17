using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Data
{
    [Table("HIRING_DOCUMENTS")]
    [Index(nameof(DocumentFile), nameof(EmployeeId), Name = "IndexHiringDocumentFacultyName")]
    public partial class HIRING_DOCUMENT
    {
        [Key]
        public int DocumentId { get; set; }
        [Required]
        [StringLength(30)]
        public string DocumentName { get; set; }
        [Required]
        [StringLength(30)]
        public string DocumentFile { get; set; }
        [Column(TypeName = "date")]
        public DateTime DocumentDate { get; set; }
        [Required]
        [StringLength(10)]
        public string DocumentFormat { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(FACULTY.HIRING_DOCUMENTs))]
        public virtual FACULTY Employee { get; set; }
    }
}
