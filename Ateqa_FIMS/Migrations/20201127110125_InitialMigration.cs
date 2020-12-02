using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAH_FIMS.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NOTIFICATION_TYPE",
                columns: table => new
                {
                    NotificationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION_TYPE", x => x.NotificationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "OFFICE",
                columns: table => new
                {
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OfficeArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableResources = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFFICE", x => x.OfficeId);
                });

            migrationBuilder.CreateTable(
                name: "POSITION",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSITION", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_USERS",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_USERS", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "RESOURCE",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESOURCE", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_RESOURCE_OFFICE",
                        column: x => x.OfficeId,
                        principalTable: "OFFICE",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_DEPARTMENT_SCHOOL",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COURSE",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CourseTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CourseDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseCredits = table.Column<int>(type: "int", nullable: false),
                    RequiredContactHours = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSE", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_COURSE_DEPARTMENT",
                        column: x => x.DepartmentId,
                        principalTable: "DEPARTMENT",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneExtension = table.Column<int>(type: "int", nullable: false),
                    IsItPartTime = table.Column<bool>(type: "bit", nullable: false),
                    AcceptEmailNotification = table.Column<bool>(type: "bit", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_DEPARTMENT",
                        column: x => x.DepartmentId,
                        principalTable: "DEPARTMENT",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_OFFICE",
                        column: x => x.OfficeId,
                        principalTable: "OFFICE",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_POSITION",
                        column: x => x.PositionId,
                        principalTable: "POSITION",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_SYSTEM_USERS",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CAADU_USER",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAADU_USER", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_CAADU_USER_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CAADU_USER_SYSTEM_USERS",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FACULTY",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HighestEducation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Division = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeOfContract = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateNeeded = table.Column<DateTime>(type: "date", nullable: false),
                    RecruitmentStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "date", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "date", nullable: true),
                    Rank = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RequiredLoad = table.Column<int>(type: "int", nullable: true),
                    ConversionRate = table.Column<int>(type: "int", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACULTY", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_FACULTY_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_USER",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_USER", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_HR_USER_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_USER_SYSTEM_USERS",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INFO_DESK_USER",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INFO_DESK_USER", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_INFO_DESK_USER_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INFO_DESK_USER_SYSTEM_USERS",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IT_USER",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT_USER", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_IT_USER_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IT_USER_SYSTEM_USERS",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MAINTENANCE_USER",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAINTENANCE_USER", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_MAINTENANCE_USER_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MAINTENANCE_USER_SYSTEM_USERS",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_ADMIN",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_ADMIN", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_SYSTEM_ADMIN_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SYSTEM_ADMIN_SYSTEM_USERS",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_ADMIN_ASSISTANT",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_ADMIN_ASSISTANT", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_SYSTEM_ADMIN_ASSISTANT_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SYSTEM_ADMIN_ASSISTANT_SYSTEM_USERS",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_SUPERVISOR",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_SUPERVISOR", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_SYSTEM_SUPERVISOR_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SYSTEM_SUPERVISOR_SYSTEM_USERS",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TEACHER_ASSISTANT",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TotalCredit = table.Column<int>(type: "int", nullable: false),
                    TotalContactHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEACHER_ASSISTANT", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_TEACHER_ASSISTANT_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FACULTY_COURSE",
                columns: table => new
                {
                    FacultyCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYear = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CourseTeachingType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TotalContactHours = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACULTY_COURSE", x => x.FacultyCourseId);
                    table.ForeignKey(
                        name: "FK_FACULTY_COURSE_COURSE",
                        column: x => x.CourseId,
                        principalTable: "COURSE",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FACULTY_COURSE_FACULTY",
                        column: x => x.EmployeeId,
                        principalTable: "FACULTY",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HIRING_DOCUMENTS",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DocumentFile = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: false),
                    DocumentFormat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HIRING_DOCUMENTS", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_HIRING_DOCUMENTS_FACULTY",
                        column: x => x.EmployeeId,
                        principalTable: "FACULTY",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REQUEST",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourceQuantity = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUEST", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_REQUEST_OFFICE",
                        column: x => x.OfficeId,
                        principalTable: "OFFICE",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REQUEST_SYSTEM_ADMIN",
                        column: x => x.EmployeeId,
                        principalTable: "SYSTEM_ADMIN",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WORKLOAD",
                columns: table => new
                {
                    WorkloadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Semester = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Workload = table.Column<int>(type: "int", nullable: false),
                    LoadType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsItApproved = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKLOAD", x => x.WorkloadId);
                    table.ForeignKey(
                        name: "FK_WORKLOAD_FACULTY",
                        column: x => x.EmployeeId,
                        principalTable: "FACULTY",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WORKLOAD_SYSTEM_SUPERVISOR",
                        column: x => x.EmployeeId,
                        principalTable: "SYSTEM_SUPERVISOR",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WORKLOAD_TEACHER_ASSISTANT",
                        column: x => x.EmployeeId,
                        principalTable: "TEACHER_ASSISTANT",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SECTION",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SectionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicYear = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FacultyCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECTION", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_SECTION_FACULTY_COURSE1",
                        column: x => x.FacultyCourseId,
                        principalTable: "FACULTY_COURSE",
                        principalColumn: "FacultyCourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SECTION_TEACHER_ASSISTANT",
                        column: x => x.EmployeeId,
                        principalTable: "TEACHER_ASSISTANT",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REQUEST_RESOURCE",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUEST_RESOURCE", x => new { x.RequestId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_REQUEST_RESOURCE_REQUEST",
                        column: x => x.RequestId,
                        principalTable: "REQUEST",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REQUEST_RESOURCE_RESOURCE",
                        column: x => x.ResourceId,
                        principalTable: "RESOURCE",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICATION",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationTypeId = table.Column<int>(type: "int", nullable: false),
                    WorkloadId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_NOTIFICATION_TYPE",
                        column: x => x.NotificationTypeId,
                        principalTable: "NOTIFICATION_TYPE",
                        principalColumn: "NotificationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_REQUEST",
                        column: x => x.RequestId,
                        principalTable: "REQUEST",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_WORKLOAD",
                        column: x => x.WorkloadId,
                        principalTable: "WORKLOAD",
                        principalColumn: "WorkloadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GENERATE_NOTIFICATION",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GENERATE_NOTIFICATION", x => new { x.NotificationId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_GENERATE_NOTIFICATION_FACULTY",
                        column: x => x.EmployeeId,
                        principalTable: "FACULTY",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GENERATE_NOTIFICATION_NOTIFICATION",
                        column: x => x.NotificationId,
                        principalTable: "NOTIFICATION",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RECEIVE_NOTIFICATION",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECEIVE_NOTIFICATION", x => new { x.EmployeeId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_RECEIVE_NOTIFICATION_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECEIVE_NOTIFICATION_NOTIFICATION",
                        column: x => x.NotificationId,
                        principalTable: "NOTIFICATION",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CAADU_USER_UserId",
                table: "CAADU_USER",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_COURSE_DepartmentId",
                table: "COURSE",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IndexDepartmentName",
                table: "DEPARTMENT",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENT_SchoolId",
                table: "DEPARTMENT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IndexEmployeeDepartment",
                table: "EMPLOYEE",
                columns: new[] { "FirstName", "LastName", "DepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IndexEmployeeName",
                table: "EMPLOYEE",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_DepartmentId",
                table: "EMPLOYEE",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_OfficeId",
                table: "EMPLOYEE",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_PositionId",
                table: "EMPLOYEE",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_UserId",
                table: "EMPLOYEE",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FACULTY_COURSE_CourseId",
                table: "FACULTY_COURSE",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_FACULTY_COURSE_EmployeeId",
                table: "FACULTY_COURSE",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_GENERATE_NOTIFICATION_EmployeeId",
                table: "GENERATE_NOTIFICATION",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IndexHiringDocumentFacultyName",
                table: "HIRING_DOCUMENTS",
                columns: new[] { "DocumentFile", "EmployeeId" });

            migrationBuilder.CreateIndex(
                name: "IX_HIRING_DOCUMENTS_EmployeeId",
                table: "HIRING_DOCUMENTS",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_USER_UserId",
                table: "HR_USER",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_INFO_DESK_USER_UserId",
                table: "INFO_DESK_USER",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IT_USER_UserId",
                table: "IT_USER",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MAINTENANCE_USER_UserId",
                table: "MAINTENANCE_USER",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_NotificationTypeId",
                table: "NOTIFICATION",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_RequestId",
                table: "NOTIFICATION",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_WorkloadId",
                table: "NOTIFICATION",
                column: "WorkloadId");

            migrationBuilder.CreateIndex(
                name: "IX_RECEIVE_NOTIFICATION_NotificationId",
                table: "RECEIVE_NOTIFICATION",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IndexRequestDeliveryDateTime",
                table: "REQUEST",
                columns: new[] { "RequestId", "ResourceQuantity", "DeliveryDateTime" });

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_EmployeeId",
                table: "REQUEST",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_OfficeId",
                table: "REQUEST",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_RESOURCE_ResourceId",
                table: "REQUEST_RESOURCE",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_RESOURCE_OfficeId",
                table: "RESOURCE",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_SECTION_EmployeeId",
                table: "SECTION",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SECTION_FacultyCourseId",
                table: "SECTION",
                column: "FacultyCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_ADMIN_UserId",
                table: "SYSTEM_ADMIN",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_ADMIN_ASSISTANT_UserId",
                table: "SYSTEM_ADMIN_ASSISTANT",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_SUPERVISOR_UserId",
                table: "SYSTEM_SUPERVISOR",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IndexWorkload",
                table: "WORKLOAD",
                columns: new[] { "Workload", "LoadType", "EmployeeId" });

            migrationBuilder.CreateIndex(
                name: "IX_WORKLOAD_EmployeeId",
                table: "WORKLOAD",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAADU_USER");

            migrationBuilder.DropTable(
                name: "GENERATE_NOTIFICATION");

            migrationBuilder.DropTable(
                name: "HIRING_DOCUMENTS");

            migrationBuilder.DropTable(
                name: "HR_USER");

            migrationBuilder.DropTable(
                name: "INFO_DESK_USER");

            migrationBuilder.DropTable(
                name: "IT_USER");

            migrationBuilder.DropTable(
                name: "MAINTENANCE_USER");

            migrationBuilder.DropTable(
                name: "RECEIVE_NOTIFICATION");

            migrationBuilder.DropTable(
                name: "REQUEST_RESOURCE");

            migrationBuilder.DropTable(
                name: "SECTION");

            migrationBuilder.DropTable(
                name: "SYSTEM_ADMIN_ASSISTANT");

            migrationBuilder.DropTable(
                name: "NOTIFICATION");

            migrationBuilder.DropTable(
                name: "RESOURCE");

            migrationBuilder.DropTable(
                name: "FACULTY_COURSE");

            migrationBuilder.DropTable(
                name: "NOTIFICATION_TYPE");

            migrationBuilder.DropTable(
                name: "REQUEST");

            migrationBuilder.DropTable(
                name: "WORKLOAD");

            migrationBuilder.DropTable(
                name: "COURSE");

            migrationBuilder.DropTable(
                name: "SYSTEM_ADMIN");

            migrationBuilder.DropTable(
                name: "FACULTY");

            migrationBuilder.DropTable(
                name: "SYSTEM_SUPERVISOR");

            migrationBuilder.DropTable(
                name: "TEACHER_ASSISTANT");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "OFFICE");

            migrationBuilder.DropTable(
                name: "POSITION");

            migrationBuilder.DropTable(
                name: "SYSTEM_USERS");

            migrationBuilder.DropTable(
                name: "SCHOOL");
        }
    }
}
