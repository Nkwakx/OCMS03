using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS03.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblDepartment",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDepartment", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "tblDiagnosis",
                columns: table => new
                {
                    DiagnosisCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosisDescription = table.Column<string>(maxLength: 50, nullable: false),
                    DiagnosisComment = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDiagnosis", x => x.DiagnosisCode);
                });

            migrationBuilder.CreateTable(
                name: "tblProvince",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProvince", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDistrict",
                columns: table => new
                {
                    DistrictId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(maxLength: 50, nullable: false),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRegion", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_tblDistrict_tblProvince",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCity",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(maxLength: 50, nullable: false),
                    DistrictId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCity", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_tblCity_tblDistrict",
                        column: x => x.DistrictId,
                        principalTable: "tblDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblClinic",
                columns: table => new
                {
                    ClinicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicName = table.Column<string>(maxLength: 50, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClinic", x => x.ClinicId);
                    table.ForeignKey(
                        name: "FK_tblClinic_tblCity",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblHospital",
                columns: table => new
                {
                    HospitalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(maxLength: 50, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHospital", x => x.HospitalId);
                    table.ForeignKey(
                        name: "FK_tblHospital_tblCity",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblSuburb",
                columns: table => new
                {
                    SuburbId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuburbName = table.Column<string>(maxLength: 50, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSuburb", x => x.SuburbId);
                    table.ForeignKey(
                        name: "FK_tblSuburb_tblCity",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblDoctor",
                columns: table => new
                {
                    StaffNumber = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    IPAddress = table.Column<string>(maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    IDNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(fixedLength: true, maxLength: 10, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 500, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 500, nullable: true),
                    SuburbId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    NextOfName = table.Column<string>(maxLength: 250, nullable: false),
                    NextOfKinSurname = table.Column<string>(maxLength: 250, nullable: false),
                    NextOfKinNumber = table.Column<string>(maxLength: 250, nullable: false),
                    HospitalId = table.Column<int>(nullable: false),
                    ClinicId = table.Column<int>(nullable: false),
                    Specialization = table.Column<string>(maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDoctor_1", x => x.StaffNumber);
                    table.ForeignKey(
                        name: "FK_tblDoctor_tblCity",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblDoctor_tblClinic",
                        column: x => x.ClinicId,
                        principalTable: "tblClinic",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblDoctor_tblDepartment",
                        column: x => x.DepartmentId,
                        principalTable: "tblDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblDoctor_tblDistrict",
                        column: x => x.DistrictId,
                        principalTable: "tblDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDoctor_tblHospital",
                        column: x => x.HospitalId,
                        principalTable: "tblHospital",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblDoctor_tblProvince",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDoctor_tblSuburb",
                        column: x => x.SuburbId,
                        principalTable: "tblSuburb",
                        principalColumn: "SuburbId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblLaboratorist",
                columns: table => new
                {
                    StaffNumber = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    IPAddress = table.Column<string>(maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    IDNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(fixedLength: true, maxLength: 10, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 500, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 500, nullable: true),
                    SuburbId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    NextOfName = table.Column<string>(maxLength: 50, nullable: false),
                    NextOfKinSurname = table.Column<string>(maxLength: 50, nullable: false),
                    NextOfKinNumber = table.Column<string>(maxLength: 13, nullable: false),
                    HospitalId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLaboratorist_1", x => x.StaffNumber);
                    table.ForeignKey(
                        name: "FK_tblLaboratorist_tblCity",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblLaboratorist_tblDepartment",
                        column: x => x.DepartmentId,
                        principalTable: "tblDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblLaboratorist_tblDistrict",
                        column: x => x.DistrictId,
                        principalTable: "tblDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblLaboratorist_tblHospital",
                        column: x => x.HospitalId,
                        principalTable: "tblHospital",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblLaboratorist_tblProvince",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblLaboratorist_tblSuburb",
                        column: x => x.SuburbId,
                        principalTable: "tblSuburb",
                        principalColumn: "SuburbId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblNurse",
                columns: table => new
                {
                    StaffNumber = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    IPAddress = table.Column<string>(maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    IDNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(fixedLength: true, maxLength: 10, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 500, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 500, nullable: true),
                    SuburbId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    NextOfName = table.Column<string>(maxLength: 50, nullable: false),
                    NextOfKinSurname = table.Column<string>(maxLength: 50, nullable: false),
                    NextOfKinNumber = table.Column<string>(maxLength: 13, nullable: false),
                    NurseType = table.Column<string>(maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false),
                    ClinicId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNurse_1", x => x.StaffNumber);
                    table.ForeignKey(
                        name: "FK_tblNurse_tblCity",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblNurse_tblClinic",
                        column: x => x.ClinicId,
                        principalTable: "tblClinic",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblNurse_tblDepartment",
                        column: x => x.DepartmentId,
                        principalTable: "tblDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblNurse_tblDistrict",
                        column: x => x.DistrictId,
                        principalTable: "tblDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblNurse_tblHospital",
                        column: x => x.HospitalId,
                        principalTable: "tblHospital",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblNurse_tblProvince",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblNurse_tblSuburb",
                        column: x => x.SuburbId,
                        principalTable: "tblSuburb",
                        principalColumn: "SuburbId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPharmacist",
                columns: table => new
                {
                    StaffNumber = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    IPAddress = table.Column<string>(maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    IDNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(fixedLength: true, maxLength: 10, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 500, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 500, nullable: true),
                    SuburbId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    NextOfName = table.Column<string>(maxLength: 50, nullable: false),
                    NextOfKinSurname = table.Column<string>(maxLength: 50, nullable: false),
                    NextOfKinNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPharmasist_1", x => x.StaffNumber);
                    table.ForeignKey(
                        name: "FK_tblPharmasist_tblCity",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPharmasist_tblDepartment",
                        column: x => x.DepartmentId,
                        principalTable: "tblDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPharmasist_tblDistrict",
                        column: x => x.DistrictId,
                        principalTable: "tblDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPharmasist_tblProvince",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPharmasist_tblSuburb",
                        column: x => x.SuburbId,
                        principalTable: "tblSuburb",
                        principalColumn: "SuburbId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblReceptionist",
                columns: table => new
                {
                    StaffNumber = table.Column<long>(nullable: false),
                    AddedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    IPAddress = table.Column<string>(maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    IDNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(fixedLength: true, maxLength: 10, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 500, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 500, nullable: false),
                    SuburbId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    NextOfName = table.Column<string>(maxLength: 50, nullable: false),
                    NextOfKinSurname = table.Column<string>(maxLength: 50, nullable: false),
                    NextOfKinNumber = table.Column<string>(fixedLength: true, maxLength: 13, nullable: false),
                    ReceptionistType = table.Column<string>(maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReceptionist_1", x => x.StaffNumber);
                    table.ForeignKey(
                        name: "FK_tblReceptionist_tblCity",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblReceptionist_tblDepartment",
                        column: x => x.DepartmentId,
                        principalTable: "tblDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblReceptionist_tblDistrict",
                        column: x => x.DistrictId,
                        principalTable: "tblDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblReceptionist_tblProvince",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblReceptionist_tblSuburb",
                        column: x => x.SuburbId,
                        principalTable: "tblSuburb",
                        principalColumn: "SuburbId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblAppointment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    IPAddress = table.Column<string>(maxLength: 100, nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    Arrived = table.Column<bool>(nullable: false),
                    AppointmentDescription = table.Column<string>(maxLength: 250, nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false),
                    ClinicId = table.Column<int>(nullable: false),
                    StaffNumber = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAppointment_tblClinic",
                        column: x => x.ClinicId,
                        principalTable: "tblClinic",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAppointment_tblHospital",
                        column: x => x.HospitalId,
                        principalTable: "tblHospital",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAppointment_tblDoctor",
                        column: x => x.StaffNumber,
                        principalTable: "tblDoctor",
                        principalColumn: "StaffNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAppointment_tblNurse",
                        column: x => x.StaffNumber,
                        principalTable: "tblNurse",
                        principalColumn: "StaffNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAppointment_tblReceptionist",
                        column: x => x.StaffNumber,
                        principalTable: "tblReceptionist",
                        principalColumn: "StaffNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPatient",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    IPAddress = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    IDNumber = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false),
                    Gender = table.Column<int>(fixedLength: true, maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false),
                    EmailAddress = table.Column<string>(fixedLength: true, maxLength: 20, nullable: false),
                    Username = table.Column<string>(fixedLength: true, maxLength: 20, nullable: false),
                    Password = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false),
                    ConfirmPassword = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 250, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 250, nullable: false),
                    SuburbId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    NextOfKinName = table.Column<string>(maxLength: 50, nullable: false),
                    NextOfKinSurname = table.Column<string>(maxLength: 50, nullable: false),
                    NextOfKinNumber = table.Column<string>(maxLength: 15, nullable: false),
                    StaffNumber = table.Column<long>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPatient_tblCity",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPatient_tblDistrict",
                        column: x => x.DistrictId,
                        principalTable: "tblDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPatient_tblProvince",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPatient_tblDoctor",
                        column: x => x.StaffNumber,
                        principalTable: "tblDoctor",
                        principalColumn: "StaffNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPatient_tblReceptionist",
                        column: x => x.StaffNumber,
                        principalTable: "tblReceptionist",
                        principalColumn: "StaffNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPatient_tblSuburb",
                        column: x => x.SuburbId,
                        principalTable: "tblSuburb",
                        principalColumn: "SuburbId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblAppointmentNotes",
                columns: table => new
                {
                    AppointmentNotesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(nullable: false),
                    PatientId = table.Column<long>(nullable: false),
                    StaffNumber = table.Column<long>(nullable: true),
                    DiagnosisCode = table.Column<int>(nullable: false),
                    NotesComment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAppointmentNotes", x => x.AppointmentNotesId);
                    table.ForeignKey(
                        name: "FK_tblAppointmentNotes_tblDiagnosis",
                        column: x => x.DiagnosisCode,
                        principalTable: "tblDiagnosis",
                        principalColumn: "DiagnosisCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAppointmentNotes_tblPatient",
                        column: x => x.PatientId,
                        principalTable: "tblPatient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAppointmentNotes_tblDoctor1",
                        column: x => x.StaffNumber,
                        principalTable: "tblDoctor",
                        principalColumn: "StaffNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAppointmentNotes_tblNurse",
                        column: x => x.StaffNumber,
                        principalTable: "tblNurse",
                        principalColumn: "StaffNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPrescription",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(nullable: false),
                    StaffNumber = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    PrescriptionStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPrescription", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_tblPrescription_tblPatient",
                        column: x => x.PatientId,
                        principalTable: "tblPatient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPrescription_tblDoctor",
                        column: x => x.StaffNumber,
                        principalTable: "tblDoctor",
                        principalColumn: "StaffNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPrescription_tblNurse",
                        column: x => x.StaffNumber,
                        principalTable: "tblNurse",
                        principalColumn: "StaffNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPrescription_tblPharmasist",
                        column: x => x.StaffNumber,
                        principalTable: "tblPharmacist",
                        principalColumn: "StaffNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_ClinicId",
                table: "tblAppointment",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_HospitalId",
                table: "tblAppointment",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_StaffNumber",
                table: "tblAppointment",
                column: "StaffNumber");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointmentNotes_DiagnosisCode",
                table: "tblAppointmentNotes",
                column: "DiagnosisCode");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointmentNotes_PatientId",
                table: "tblAppointmentNotes",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointmentNotes_StaffNumber",
                table: "tblAppointmentNotes",
                column: "StaffNumber");

            migrationBuilder.CreateIndex(
                name: "IX_tblCity_DistrictId",
                table: "tblCity",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tblClinic_CityId",
                table: "tblClinic",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDistrict_ProvinceId",
                table: "tblDistrict",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctor_CityId",
                table: "tblDoctor",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctor_ClinicId",
                table: "tblDoctor",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctor_DepartmentId",
                table: "tblDoctor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctor_DistrictId",
                table: "tblDoctor",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctor_HospitalId",
                table: "tblDoctor",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctor_ProvinceId",
                table: "tblDoctor",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctor_SuburbId",
                table: "tblDoctor",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_tblHospital_CityId",
                table: "tblHospital",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLaboratorist_CityId",
                table: "tblLaboratorist",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLaboratorist_DepartmentId",
                table: "tblLaboratorist",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLaboratorist_DistrictId",
                table: "tblLaboratorist",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLaboratorist_HospitalId",
                table: "tblLaboratorist",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLaboratorist_ProvinceId",
                table: "tblLaboratorist",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLaboratorist_SuburbId",
                table: "tblLaboratorist",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNurse_CityId",
                table: "tblNurse",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNurse_ClinicId",
                table: "tblNurse",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNurse_DepartmentId",
                table: "tblNurse",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNurse_DistrictId",
                table: "tblNurse",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNurse_HospitalId",
                table: "tblNurse",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNurse_ProvinceId",
                table: "tblNurse",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNurse_SuburbId",
                table: "tblNurse",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatient_CityId",
                table: "tblPatient",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatient_DistrictId",
                table: "tblPatient",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatient_ProvinceId",
                table: "tblPatient",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatient_StaffNumber",
                table: "tblPatient",
                column: "StaffNumber");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatient_SuburbId",
                table: "tblPatient",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPharmacist_CityId",
                table: "tblPharmacist",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPharmacist_DepartmentId",
                table: "tblPharmacist",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPharmacist_DistrictId",
                table: "tblPharmacist",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPharmacist_ProvinceId",
                table: "tblPharmacist",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPharmacist_SuburbId",
                table: "tblPharmacist",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPrescription_PatientId",
                table: "tblPrescription",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPrescription_StaffNumber",
                table: "tblPrescription",
                column: "StaffNumber");

            migrationBuilder.CreateIndex(
                name: "IX_tblReceptionist_CityId",
                table: "tblReceptionist",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReceptionist_DepartmentId",
                table: "tblReceptionist",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReceptionist_DistrictId",
                table: "tblReceptionist",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReceptionist_ProvinceId",
                table: "tblReceptionist",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReceptionist_SuburbId",
                table: "tblReceptionist",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSuburb_CityId",
                table: "tblSuburb",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tblAppointment");

            migrationBuilder.DropTable(
                name: "tblAppointmentNotes");

            migrationBuilder.DropTable(
                name: "tblLaboratorist");

            migrationBuilder.DropTable(
                name: "tblPrescription");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tblDiagnosis");

            migrationBuilder.DropTable(
                name: "tblPatient");

            migrationBuilder.DropTable(
                name: "tblNurse");

            migrationBuilder.DropTable(
                name: "tblPharmacist");

            migrationBuilder.DropTable(
                name: "tblDoctor");

            migrationBuilder.DropTable(
                name: "tblReceptionist");

            migrationBuilder.DropTable(
                name: "tblClinic");

            migrationBuilder.DropTable(
                name: "tblHospital");

            migrationBuilder.DropTable(
                name: "tblDepartment");

            migrationBuilder.DropTable(
                name: "tblSuburb");

            migrationBuilder.DropTable(
                name: "tblCity");

            migrationBuilder.DropTable(
                name: "tblDistrict");

            migrationBuilder.DropTable(
                name: "tblProvince");
        }
    }
}
