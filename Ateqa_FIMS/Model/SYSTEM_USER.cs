using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAH_FIMS.Model
{
    [Table("SYSTEM_USERS")]
    public partial class SYSTEM_USER
    {
        public SYSTEM_USER()
        {
            CAADU_USERs = new HashSet<CAADU_USER>();
            EMPLOYEEs = new HashSet<EMPLOYEE>();
            HR_USERs = new HashSet<HR_USER>();
            INFO_DESK_USERs = new HashSet<INFO_DESK_USER>();
            IT_USERs = new HashSet<IT_USER>();
            MAINTENANCE_USERs = new HashSet<MAINTENANCE_USER>();
            SYSTEM_ADMIN_ASSISTANTs = new HashSet<SYSTEM_ADMIN_ASSISTANT>();
            SYSTEM_ADMINs = new HashSet<SYSTEM_ADMIN>();
            SYSTEM_SUPERVISORs = new HashSet<SYSTEM_SUPERVISOR>();
        }

        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }

        [InverseProperty(nameof(CAADU_USER.User))]
        public virtual ICollection<CAADU_USER> CAADU_USERs { get; set; }
        [InverseProperty(nameof(EMPLOYEE.User))]
        public virtual ICollection<EMPLOYEE> EMPLOYEEs { get; set; }
        [InverseProperty(nameof(HR_USER.User))]
        public virtual ICollection<HR_USER> HR_USERs { get; set; }
        [InverseProperty(nameof(INFO_DESK_USER.User))]
        public virtual ICollection<INFO_DESK_USER> INFO_DESK_USERs { get; set; }
        [InverseProperty(nameof(IT_USER.User))]
        public virtual ICollection<IT_USER> IT_USERs { get; set; }
        [InverseProperty(nameof(MAINTENANCE_USER.User))]
        public virtual ICollection<MAINTENANCE_USER> MAINTENANCE_USERs { get; set; }
        [InverseProperty(nameof(SYSTEM_ADMIN_ASSISTANT.User))]
        public virtual ICollection<SYSTEM_ADMIN_ASSISTANT> SYSTEM_ADMIN_ASSISTANTs { get; set; }
        [InverseProperty(nameof(SYSTEM_ADMIN.User))]
        public virtual ICollection<SYSTEM_ADMIN> SYSTEM_ADMINs { get; set; }
        [InverseProperty(nameof(SYSTEM_SUPERVISOR.User))]
        public virtual ICollection<SYSTEM_SUPERVISOR> SYSTEM_SUPERVISORs { get; set; }
    }
}
