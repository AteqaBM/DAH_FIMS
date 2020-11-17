using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAH_FIMS.Data
{
    public partial class DahFIMSDbContext : DbContext
    {
        public DahFIMSDbContext()
        {
        }

        public DahFIMSDbContext(DbContextOptions<DahFIMSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CAADU_USER> CAADU_USERs { get; set; }
        public virtual DbSet<COURSE> COURSEs { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTs { get; set; }
        public virtual DbSet<Databank> Databanks { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<FACULTY> FACULTies { get; set; }
        public virtual DbSet<FACULTY_COURSE> FACULTY_COURSEs { get; set; }
        public virtual DbSet<FacultiesList> FacultiesLists { get; set; }
        public virtual DbSet<Faculty_Information> Faculty_Informations { get; set; }
        public virtual DbSet<Faculty_JobType> Faculty_JobTypes { get; set; }
        public virtual DbSet<Faculty_List> Faculty_Lists { get; set; }
        public virtual DbSet<GENERATE_NOTIFICATION> GENERATE_NOTIFICATIONs { get; set; }
        public virtual DbSet<HIRING_DOCUMENT> HIRING_DOCUMENTs { get; set; }
        public virtual DbSet<HR_USER> HR_USERs { get; set; }
        public virtual DbSet<INFO_DESK_USER> INFO_DESK_USERs { get; set; }
        public virtual DbSet<IT_USER> IT_USERs { get; set; }
        public virtual DbSet<MAINTENANCE_USER> MAINTENANCE_USERs { get; set; }
        public virtual DbSet<NOTIFICATION> NOTIFICATIONs { get; set; }
        public virtual DbSet<NOTIFICATION_TYPE> NOTIFICATION_TYPEs { get; set; }
        public virtual DbSet<OFFICE> OFFICEs { get; set; }
        public virtual DbSet<Office_Information> Office_Informations { get; set; }
        public virtual DbSet<OfficesList> OfficesLists { get; set; }
        public virtual DbSet<POSITION> POSITIONs { get; set; }
        public virtual DbSet<RECEIVE_NOTIFICATION> RECEIVE_NOTIFICATIONs { get; set; }
        public virtual DbSet<REQUEST> REQUESTs { get; set; }
        public virtual DbSet<REQUEST_RESOURCE> REQUEST_RESOURCEs { get; set; }
        public virtual DbSet<RESOURCE> RESOURCEs { get; set; }
        public virtual DbSet<Requests_List> Requests_Lists { get; set; }
        public virtual DbSet<SCHOOL> SCHOOLs { get; set; }
        public virtual DbSet<SECTION> SECTIONs { get; set; }
        public virtual DbSet<SYSTEM_ADMIN> SYSTEM_ADMINs { get; set; }
        public virtual DbSet<SYSTEM_ADMIN_ASSISTANT> SYSTEM_ADMIN_ASSISTANTs { get; set; }
        public virtual DbSet<SYSTEM_SUPERVISOR> SYSTEM_SUPERVISORs { get; set; }
        public virtual DbSet<SYSTEM_USER> SYSTEM_USERs { get; set; }
        public virtual DbSet<TAList> TALists { get; set; }
        public virtual DbSet<TA_Information> TA_Informations { get; set; }
        public virtual DbSet<TEACHER_ASSISTANT> TEACHER_ASSISTANTs { get; set; }
        public virtual DbSet<WORKLOAD> WORKLOADs { get; set; }
        public virtual DbSet<WorkloadList> WorkloadLists { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-N0H2G67;Database=FIMS;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CAADU_USER>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.CAADU_USER)
                    .HasForeignKey<CAADU_USER>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAADU_USER_EMPLOYEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CAADU_USERs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CAADU_USER_SYSTEM_USERS");
            });

            modelBuilder.Entity<COURSE>(entity =>
            {
                entity.Property(e => e.CourseId).ValueGeneratedNever();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.COURSEs)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSE_DEPARTMENT");
            });

            modelBuilder.Entity<DEPARTMENT>(entity =>
            {
                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.HasOne(d => d.School)
                    .WithMany(p => p.DEPARTMENTs)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_DEPARTMENT_SCHOOL");
            });

            modelBuilder.Entity<Databank>(entity =>
            {
                entity.ToView("Databank");
            });

            modelBuilder.Entity<EMPLOYEE>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EMPLOYEEs)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_DEPARTMENT");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.EMPLOYEEs)
                    .HasForeignKey(d => d.OfficeId)
                    .HasConstraintName("FK_EMPLOYEE_OFFICE");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.EMPLOYEEs)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_POSITION");
            });

            modelBuilder.Entity<FACULTY>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.FACULTY)
                    .HasForeignKey<FACULTY>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FACULTY_EMPLOYEE");
            });

            modelBuilder.Entity<FACULTY_COURSE>(entity =>
            {
                entity.Property(e => e.FacultyCourseId).ValueGeneratedNever();

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.FACULTY_COURSEs)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FACULTY_COURSE_COURSE");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.FACULTY_COURSEs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FACULTY_COURSE_FACULTY");
            });

            modelBuilder.Entity<FacultiesList>(entity =>
            {
                entity.ToView("FacultiesList");
            });

            modelBuilder.Entity<Faculty_Information>(entity =>
            {
                entity.ToView("Faculty_Information");
            });

            modelBuilder.Entity<Faculty_JobType>(entity =>
            {
                entity.ToView("Faculty_JobType");
            });

            modelBuilder.Entity<Faculty_List>(entity =>
            {
                entity.ToView("Faculty_List");
            });

            modelBuilder.Entity<GENERATE_NOTIFICATION>(entity =>
            {
                entity.HasKey(e => new { e.NotificationId, e.EmployeeId });

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.GENERATE_NOTIFICATIONs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GENERATE_NOTIFICATION_FACULTY");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.GENERATE_NOTIFICATIONs)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GENERATE_NOTIFICATION_NOTIFICATION");
            });

            modelBuilder.Entity<HIRING_DOCUMENT>(entity =>
            {
                entity.Property(e => e.DocumentId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HIRING_DOCUMENTs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HIRING_DOCUMENTS_FACULTY");
            });

            modelBuilder.Entity<HR_USER>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.HR_USER)
                    .HasForeignKey<HR_USER>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HR_USER_EMPLOYEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HR_USERs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_HR_USER_SYSTEM_USERS");
            });

            modelBuilder.Entity<INFO_DESK_USER>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.INFO_DESK_USER)
                    .HasForeignKey<INFO_DESK_USER>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INFO_DESK_USER_EMPLOYEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.INFO_DESK_USERs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_INFO_DESK_USER_SYSTEM_USERS");
            });

            modelBuilder.Entity<IT_USER>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.IT_USER)
                    .HasForeignKey<IT_USER>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IT_USER_EMPLOYEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IT_USERs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_IT_USER_SYSTEM_USERS");
            });

            modelBuilder.Entity<MAINTENANCE_USER>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.MAINTENANCE_USER)
                    .HasForeignKey<MAINTENANCE_USER>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MAINTENANCE_USER_EMPLOYEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MAINTENANCE_USERs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_MAINTENANCE_USER_SYSTEM_USERS");
            });

            modelBuilder.Entity<NOTIFICATION>(entity =>
            {
                entity.Property(e => e.NotificationId).ValueGeneratedNever();

                entity.HasOne(d => d.NotificationType)
                    .WithMany(p => p.NOTIFICATIONs)
                    .HasForeignKey(d => d.NotificationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTIFICATION_NOTIFICATION_TYPE");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.NOTIFICATIONs)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTIFICATION_REQUEST");

                entity.HasOne(d => d.Workload)
                    .WithMany(p => p.NOTIFICATIONs)
                    .HasForeignKey(d => d.WorkloadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTIFICATION_WORKLOAD");
            });

            modelBuilder.Entity<NOTIFICATION_TYPE>(entity =>
            {
                entity.Property(e => e.NotificationTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<OFFICE>(entity =>
            {
                entity.Property(e => e.OfficeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Office_Information>(entity =>
            {
                entity.ToView("Office_Information");
            });

            modelBuilder.Entity<OfficesList>(entity =>
            {
                entity.ToView("OfficesList");
            });

            modelBuilder.Entity<POSITION>(entity =>
            {
                entity.Property(e => e.PositionId).ValueGeneratedNever();
            });

            modelBuilder.Entity<RECEIVE_NOTIFICATION>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.NotificationId });

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RECEIVE_NOTIFICATIONs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECEIVE_NOTIFICATION_EMPLOYEE");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.RECEIVE_NOTIFICATIONs)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECEIVE_NOTIFICATION_NOTIFICATION");
            });

            modelBuilder.Entity<REQUEST>(entity =>
            {
                entity.Property(e => e.RequestId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.REQUESTs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_SYSTEM_ADMIN");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.REQUESTs)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_OFFICE");
            });

            modelBuilder.Entity<REQUEST_RESOURCE>(entity =>
            {
                entity.HasKey(e => new { e.RequestId, e.ResourceId });

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.REQUEST_RESOURCEs)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_RESOURCE_REQUEST");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.REQUEST_RESOURCEs)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_RESOURCE_RESOURCE");
            });

            modelBuilder.Entity<RESOURCE>(entity =>
            {
                entity.Property(e => e.ResourceId).ValueGeneratedNever();

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.RESOURCEs)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESOURCE_OFFICE");
            });

            modelBuilder.Entity<Requests_List>(entity =>
            {
                entity.ToView("Requests_List");
            });

            modelBuilder.Entity<SCHOOL>(entity =>
            {
                entity.Property(e => e.SchoolId).ValueGeneratedNever();
            });

            modelBuilder.Entity<SECTION>(entity =>
            {
                entity.Property(e => e.SectionId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SECTIONs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SECTION_TEACHER_ASSISTANT");

                entity.HasOne(d => d.FacultyCourse)
                    .WithMany(p => p.SECTIONs)
                    .HasForeignKey(d => d.FacultyCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SECTION_FACULTY_COURSE1");
            });

            modelBuilder.Entity<SYSTEM_ADMIN>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.SYSTEM_ADMIN)
                    .HasForeignKey<SYSTEM_ADMIN>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SYSTEM_ADMIN_EMPLOYEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SYSTEM_ADMINs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SYSTEM_ADMIN_SYSTEM_USERS");
            });

            modelBuilder.Entity<SYSTEM_ADMIN_ASSISTANT>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.SYSTEM_ADMIN_ASSISTANT)
                    .HasForeignKey<SYSTEM_ADMIN_ASSISTANT>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SYSTEM_ADMIN_ASSISTANT_EMPLOYEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SYSTEM_ADMIN_ASSISTANTs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SYSTEM_ADMIN_ASSISTANT_SYSTEM_USERS");
            });

            modelBuilder.Entity<SYSTEM_SUPERVISOR>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.SYSTEM_SUPERVISOR)
                    .HasForeignKey<SYSTEM_SUPERVISOR>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SYSTEM_SUPERVISOR_EMPLOYEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SYSTEM_SUPERVISORs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SYSTEM_SUPERVISOR_SYSTEM_USERS");
            });

            modelBuilder.Entity<SYSTEM_USER>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TAList>(entity =>
            {
                entity.ToView("TAList");
            });

            modelBuilder.Entity<TA_Information>(entity =>
            {
                entity.ToView("TA_Information");
            });

            modelBuilder.Entity<TEACHER_ASSISTANT>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.TEACHER_ASSISTANT)
                    .HasForeignKey<TEACHER_ASSISTANT>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEACHER_ASSISTANT_EMPLOYEE");
            });

            modelBuilder.Entity<WORKLOAD>(entity =>
            {
                entity.Property(e => e.WorkloadId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.WORKLOADs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WORKLOAD_FACULTY");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.WORKLOADs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WORKLOAD_SYSTEM_SUPERVISOR");

                entity.HasOne(d => d.Employee1)
                    .WithMany(p => p.WORKLOADs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WORKLOAD_TEACHER_ASSISTANT");
            });

            modelBuilder.Entity<WorkloadList>(entity =>
            {
                entity.ToView("WorkloadList");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
