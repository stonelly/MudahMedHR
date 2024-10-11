using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudahMed.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RefTable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblBanks",
                columns: table => new
                {
                    Bank_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bank_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDisplay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBanks", x => x.Bank_id);
                });

            migrationBuilder.CreateTable(
                name: "tblDiagnosis",
                columns: table => new
                {
                    Diag_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Diag_cat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Diag_desc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsRemarksReq = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsLTM = table.Column<bool>(type: "bit", nullable: false),
                    IsGP = table.Column<bool>(type: "bit", nullable: true),
                    DiagGrp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDiagnosis", x => x.Diag_id);
                });

            migrationBuilder.CreateTable(
                name: "tblDrugs",
                columns: table => new
                {
                    DrugID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DrugType_CodeFK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugCatFFS_CodeFK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ATCClass = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DrugMIMSClass_CodeFK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenericName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DrugRoute_CodeFK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugUnit_CodeFK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICDCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifyBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DrugChrgField_CodeFK = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: true),
                    IsChronic = table.Column<bool>(type: "bit", nullable: true),
                    MaxQty = table.Column<int>(type: "int", nullable: true),
                    MaxPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DrugPoisonFFS_CodeFK = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CeilingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsExclusion = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDrugs", x => x.DrugID);
                });

            migrationBuilder.CreateTable(
                name: "tblIndustryField",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryFieldName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIndustryField", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleClaims_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaims_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblClinic",
                columns: table => new
                {
                    ClinicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clinic_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Clinic_addr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Clinic_addr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Clinic_addr3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Corp_ContactNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Corp_fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Corp_RegNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Corp_TIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankID = table.Column<int>(type: "int", nullable: true),
                    BankAccNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    rendered_svc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    panel_type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PayeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Handphone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RecruitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClinicGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Is24Hour = table.Column<bool>(type: "bit", nullable: true),
                    Clinic_cont_MMC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PermenantDoc1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PermenantDoc1MMC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PermenantDoc2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PermenantDoc2MMC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocumDoc1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LocumDoc1MMC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocumDoc2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LocumDoc2MMC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Clinic_cont_OHD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PermenantDoc1OHD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PermenantDoc2OHD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LocumDoc1OHD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LocumDoc2OHD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SSMNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsPCD = table.Column<bool>(type: "bit", nullable: true),
                    IsIVD = table.Column<bool>(type: "bit", nullable: true),
                    IsOT = table.Column<bool>(type: "bit", nullable: true),
                    IsCPR = table.Column<bool>(type: "bit", nullable: true),
                    IsENT = table.Column<bool>(type: "bit", nullable: true),
                    IsUFEME = table.Column<bool>(type: "bit", nullable: true),
                    IsAvailAN = table.Column<bool>(type: "bit", nullable: true),
                    IsAvailMS = table.Column<bool>(type: "bit", nullable: true),
                    IsAvailMC = table.Column<bool>(type: "bit", nullable: true),
                    IsSpiro = table.Column<bool>(type: "bit", nullable: true),
                    IsAudF = table.Column<bool>(type: "bit", nullable: true),
                    IsLocDoc = table.Column<bool>(type: "bit", nullable: true),
                    IsOHDDoc = table.Column<bool>(type: "bit", nullable: true),
                    IsECG = table.Column<bool>(type: "bit", nullable: true),
                    IsFBHAM = table.Column<bool>(type: "bit", nullable: true),
                    IsAvailFMDoc = table.Column<bool>(type: "bit", nullable: true),
                    IsNebulizer = table.Column<bool>(type: "bit", nullable: true),
                    IsUltraSound = table.Column<bool>(type: "bit", nullable: true),
                    IsPapSme = table.Column<bool>(type: "bit", nullable: true),
                    IsXrayReader = table.Column<bool>(type: "bit", nullable: true),
                    IsXray = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClinic", x => x.ClinicID);
                    table.ForeignKey(
                        name: "FK_tblClinic_tblBanks_BankID",
                        column: x => x.BankID,
                        principalTable: "tblBanks",
                        principalColumn: "Bank_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCorpGroup",
                columns: table => new
                {
                    CorpGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Addr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Addr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Addr3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankID = table.Column<int>(type: "int", nullable: false),
                    BankAccNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCorpGroup", x => x.CorpGroupID);
                    table.ForeignKey(
                        name: "FK_tblCorpGroup_tblBanks_BankID",
                        column: x => x.BankID,
                        principalTable: "tblBanks",
                        principalColumn: "Bank_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployees",
                columns: table => new
                {
                    Emp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_ic = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Emp_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CorpID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Suboffice_fk = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Dept_fk = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BenefitID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Emp_gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Emp_dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Emp_race = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Emp_nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Addr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Addr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Addr3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cont_no = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Join_dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ent_dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BankID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BankAccNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Resign_dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CostCentre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Bank_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployees", x => x.Emp_id);
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblBanks_Bank_id",
                        column: x => x.Bank_id,
                        principalTable: "tblBanks",
                        principalColumn: "Bank_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCorp",
                columns: table => new
                {
                    CorpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Corp_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Corp_addr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Corp_addr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Corp_addr3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Corp_ContactNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Corp_fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Corp_RegNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Corp_TIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankID = table.Column<int>(type: "int", nullable: false),
                    BankAccNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CorpGroupID = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    FinanceEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsSuspend = table.Column<bool>(type: "bit", nullable: false),
                    IndustryField = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCorp", x => x.CorpID);
                    table.ForeignKey(
                        name: "FK_tblCorp_tblBanks_BankID",
                        column: x => x.BankID,
                        principalTable: "tblBanks",
                        principalColumn: "Bank_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCorp_tblCorpGroup_CorpGroupID",
                        column: x => x.CorpGroupID,
                        principalTable: "tblCorpGroup",
                        principalColumn: "CorpGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDependents",
                columns: table => new
                {
                    Dep_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_id = table.Column<int>(type: "int", nullable: false),
                    Dep_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dep_ic = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BenefitID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Dep_gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Dep_dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dep_race = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Dep_nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Join_dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ent_dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepResignDT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDependents", x => x.Dep_id);
                    table.ForeignKey(
                        name: "FK_tblDependents_tblEmployees_Emp_id",
                        column: x => x.Emp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "Emp_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"), "58cac793-36e0-4d9e-88e5-d5af2ba6a1c2", "Clinic User", "Clinic", "CLINIC" },
                    { new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"), "ae808944-13f5-4909-aa73-82a1a2a2cb4c", "Corporate HR", "Corporate", "CORPORATE" },
                    { new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"), "9813a41e-55a0-454b-8e47-3b3b39b65527", "Administrator role", "Admin", "ADMIN" },
                    { new Guid("b448a7dc-54c6-4060-90f0-86965c07e8f0"), "ee1a11a0-d39b-4907-9f68-ddeffe2ff191", "Employee User", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "ModifiedBy", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefId", "RefTable", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("31986efe-9171-44e7-8503-1b4c8f9c1d1b"), 0, "bdfe1f0e-99e3-4a61-9a26-1aa8c901c997", null, null, "corporate@gmail.com", true, "HR Adminitrator", false, null, null, null, "corporate@GMAIL.COM", "corporate@GMAIL.COM", "AQAAAAEAACcQAAAAEGziLUejJiTruwTrW+L1MWUfxBweTtiV765PRs4Yeur/dNhbI5AJ/OvmVS/bUMch6Q==", null, false, 1, "tblCorp", "", -1, false, "corporate@gmail.com" },
                    { new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"), 0, "ca5bcd90-cea6-4b8c-b3a7-2911c0d6bdca", null, new DateTime(2024, 10, 12, 1, 34, 2, 281, DateTimeKind.Local).AddTicks(3422), "admin@gmail.com", true, "System Adminitrator", false, null, null, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEJllC7hr4wwQHtFp0UwxRjbbyoWOOZ/wneHiQUu7uHT5mmuQvyWN+tQ+cdKbbOYABg==", null, false, 1, "tblCorp", "", -1, false, "admin@gmail.com" },
                    { new Guid("faed90a2-9f7d-411a-8119-0fa3a668e660"), 0, "6dd2a859-8906-4190-9e8b-44ad689f90db", null, null, "clinic@gmail.com", true, "Clinic Adminitrator", false, null, null, null, "clinic@GMAIL.COM", "clinic@GMAIL.COM", "AQAAAAEAACcQAAAAEIEJbh1qh0Bsi6/9r4DAS6W8v6qrEWoJt2ee5SlXenHtR9OIF2xeGhFwzDrV4WZbzA==", null, false, 1, "tblClinic", "", -1, false, "clinic@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "tblBanks",
                columns: new[] { "Bank_id", "Bank_name", "IsDisplay" },
                values: new object[] { 1, "Malayan Banking Berhad", true });

            migrationBuilder.InsertData(
                table: "tblClinic",
                columns: new[] { "ClinicID", "BankAccNo", "BankID", "ClinicGroup", "Clinic_addr1", "Clinic_addr2", "Clinic_addr3", "Clinic_cont_MMC", "Clinic_cont_OHD", "Clinic_name", "ContactPerson", "Corp_ContactNo", "Corp_RegNo", "Corp_TIN", "Corp_fax", "Email", "Handphone", "Is24Hour", "IsActive", "IsAudF", "IsAvailAN", "IsAvailFMDoc", "IsAvailMC", "IsAvailMS", "IsCPR", "IsECG", "IsENT", "IsFBHAM", "IsIVD", "IsLocDoc", "IsNebulizer", "IsOHDDoc", "IsOT", "IsPCD", "IsPapSme", "IsSpiro", "IsUFEME", "IsUltraSound", "IsXray", "IsXrayReader", "LastModifiedBy", "LastModifiedDate", "Latitude", "LocumDoc1", "LocumDoc1MMC", "LocumDoc1OHD", "LocumDoc2", "LocumDoc2MMC", "LocumDoc2OHD", "Longitude", "PayeeName", "PermenantDoc1", "PermenantDoc1MMC", "PermenantDoc1OHD", "PermenantDoc2", "PermenantDoc2MMC", "PermenantDoc2OHD", "RecruitDate", "RemovedDate", "SSMNo", "city", "country", "panel_type", "postcode", "rendered_svc", "state" },
                values: new object[] { 1, null, null, null, null, null, null, null, null, "Clinic Test 1", null, null, null, null, null, null, null, null, false, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0m, null, null, null, null, null, null, 0m, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "tblIndustryField",
                columns: new[] { "ItemID", "IndustryFieldName" },
                values: new object[,]
                {
                    { 1, "TPA" },
                    { 2, "Corporate" },
                    { 3, "HealthCare" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"), new Guid("31986efe-9171-44e7-8503-1b4c8f9c1d1b") },
                    { new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"), new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3") },
                    { new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"), new Guid("faed90a2-9f7d-411a-8119-0fa3a668e660") }
                });

            migrationBuilder.InsertData(
                table: "tblCorpGroup",
                columns: new[] { "CorpGroupID", "Addr1", "Addr2", "Addr3", "BankAccNo", "BankID", "ContactNo", "ContactPerson", "Email", "Fax", "LastModifiedBy", "LastModifiedDate", "Name", "RegNo", "TIN", "city", "country", "createdDate", "postcode", "state" },
                values: new object[] { 1, null, null, null, null, 1, null, null, null, null, null, new DateTime(2024, 10, 12, 1, 34, 2, 271, DateTimeKind.Local).AddTicks(739), "MudahMed Group", null, null, null, null, new DateTime(2024, 10, 12, 1, 34, 2, 271, DateTimeKind.Local).AddTicks(726), null, null });

            migrationBuilder.InsertData(
                table: "tblCorp",
                columns: new[] { "CorpID", "BankAccNo", "BankID", "ContactPerson", "CorpGroupID", "Corp_ContactNo", "Corp_RegNo", "Corp_TIN", "Corp_addr1", "Corp_addr2", "Corp_addr3", "Corp_fax", "Corp_name", "Email", "FinanceEmail", "IndustryField", "IsSuspend", "LastModifiedBy", "LastModifiedDate", "city", "country", "createdDate", "postcode", "state" },
                values: new object[] { 1, null, 1, null, 1, null, null, null, null, null, null, null, "MudahMed Sdb Bhd", null, null, 1, false, null, new DateTime(2024, 10, 12, 1, 34, 2, 271, DateTimeKind.Local).AddTicks(761), null, null, new DateTime(2024, 10, 12, 1, 34, 2, 271, DateTimeKind.Local).AddTicks(759), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_RoleId",
                table: "AppRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AppRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_UserId",
                table: "AppUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_RoleId",
                table: "AppUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblClinic_BankID",
                table: "tblClinic",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCorp_BankID",
                table: "tblCorp",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCorp_CorpGroupID",
                table: "tblCorp",
                column: "CorpGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCorpGroup_BankID",
                table: "tblCorpGroup",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDependents_Emp_id",
                table: "tblDependents",
                column: "Emp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_Bank_id",
                table: "tblEmployees",
                column: "Bank_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "tblClinic");

            migrationBuilder.DropTable(
                name: "tblCorp");

            migrationBuilder.DropTable(
                name: "tblDependents");

            migrationBuilder.DropTable(
                name: "tblDiagnosis");

            migrationBuilder.DropTable(
                name: "tblDrugs");

            migrationBuilder.DropTable(
                name: "tblIndustryField");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "tblCorpGroup");

            migrationBuilder.DropTable(
                name: "tblEmployees");

            migrationBuilder.DropTable(
                name: "tblBanks");
        }
    }
}
