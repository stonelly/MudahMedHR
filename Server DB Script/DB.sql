USE [master]
GO
/****** Object:  Database [MM]    Script Date: 11/2/2024 12:56:15 PM ******/
CREATE DATABASE [MM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MM] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MM] SET ARITHABORT OFF 
GO
ALTER DATABASE [MM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MM] SET RECOVERY FULL 
GO
ALTER DATABASE [MM] SET  MULTI_USER 
GO
ALTER DATABASE [MM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MM] SET QUERY_STORE = ON
GO
ALTER DATABASE [MM] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MM]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetBankName]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetBankName]
(
	@intBankID int 
)
RETURNS varchar(100)
AS
BEGIN

DECLARE @strBankName varchar(100)

select @strBankName = bank_name 
from tblBanks with (nolock) 
where bank_id = @intBankID

set @strBankName = isnull(@strBankName,'')

RETURN @strBankName

END
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRoleClaims]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRoles]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](256) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserClaims]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserLogins]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserLogins](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserRoles]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[RefTable] [nvarchar](100) NULL,
	[RefId] [int] NULL,
	[Status] [int] NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserTokens]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBanks]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBanks](
	[Bank_id] [int] IDENTITY(1,1) NOT NULL,
	[Bank_name] [nvarchar](100) NULL,
	[IsDisplay] [bit] NOT NULL,
 CONSTRAINT [PK_tblBanks] PRIMARY KEY CLUSTERED 
(
	[Bank_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBenefits]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBenefits](
	[BenefitID] [varchar](10) NOT NULL,
	[CorpID] [varchar](20) NOT NULL,
	[BenefitName] [varchar](100) NULL,
	[annual_cap] [decimal](18, 2) NULL,
	[month_cap] [decimal](18, 2) NULL,
	[day_cap] [decimal](18, 2) NULL,
	[annual_visit] [int] NULL,
	[month_visit] [int] NULL,
	[day_visit] [int] NULL,
	[copay_type] [varchar](1) NULL,
	[copay_value] [decimal](18, 2) NULL,
	[max_mcdays] [int] NULL,
	[IsDep] [bit] NULL,
	[exclusion] [varchar](4000) NULL,
	[remarks] [nvarchar](2000) NULL,
	[EmpDepCov] [varchar](5) NULL,
	[ProRateType] [varchar](1) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_tblBenefits] PRIMARY KEY CLUSTERED 
(
	[BenefitID] ASC,
	[CorpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblClaim]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblClaim](
	[ClaimID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClinicID] [varchar](20) NULL,
	[emp_id] [int] NULL,
	[dep_id] [int] NULL,
	[benefitid] [varchar](10) NULL,
	[ConsultDate] [datetime] NULL,
	[consult_fee] [decimal](18, 2) NULL,
	[med_fee] [decimal](18, 2) NULL,
	[xray_fee] [decimal](18, 2) NULL,
	[lab_fee] [decimal](18, 2) NULL,
	[inject_fee] [decimal](18, 2) NULL,
	[surg_fee] [decimal](18, 2) NULL,
	[screen_fee] [decimal](18, 2) NULL,
	[dressing_fee] [decimal](18, 2) NULL,
	[others_fee] [decimal](18, 2) NULL,
	[referral_fee] [decimal](18, 2) NULL,
	[referral_to] [varchar](100) NULL,
	[other_cost_rmks] [nvarchar](200) NULL,
	[total_charge] [decimal](18, 2) NULL,
	[company_pay] [decimal](18, 2) NULL,
	[emp_pay] [decimal](18, 2) NULL,
	[MC_type] [varchar](10) NULL,
	[MC_DayGiven] [decimal](10, 1) NULL,
	[MC_StartDate] [datetime] NULL,
	[MC_Remarks] [nvarchar](100) NULL,
	[claim_status] [varchar](20) NULL,
	[DRName] [varchar](100) NULL,
	[MarkupAmt] [decimal](18, 2) NULL,
	[InvoiceID] [varchar](20) NULL,
	[BillDate] [datetime] NULL,
	[AuditRemarks] [varchar](400) NULL,
	[IsAudit] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClaimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblClaimReim]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblClaimReim](
	[ClaimID] [bigint] IDENTITY(1,1) NOT NULL,
	[emp_id] [int] NULL,
	[dep_id] [int] NULL,
	[ReceiptNo] [varchar](100) NULL,
	[IsPanel] [bit] NOT NULL,
	[ClinicName] [varchar](100) NOT NULL,
	[ConsultDate] [datetime] NOT NULL,
	[DiagnosisOthers] [varchar](1000) NULL,
	[total_charge] [decimal](18, 2) NOT NULL,
	[company_pay] [decimal](18, 2) NULL,
	[emp_pay] [decimal](18, 2) NULL,
	[MC_DayGiven] [decimal](10, 1) NULL,
	[MC_StartDate] [datetime] NULL,
	[MC_Filename] [varchar](100) NULL,
	[BatchNo] [varchar](20) NULL,
	[SubmissionType] [varchar](10) NULL,
	[SubmitBy] [varchar](50) NULL,
	[Diag_ID] [varchar](10) NULL,
	[FileName] [varchar](100) NULL,
	[Email1stReminderSent] [datetime] NULL,
	[Email2ndReminder] [datetime] NULL,
	[Status] [varchar](20) NOT NULL,
	[RejectCode] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClaimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblClinic]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblClinic](
	[ClinicID] [varchar](20) NOT NULL,
	[Clinic_name] [nvarchar](100) NULL,
	[Clinic_addr1] [varchar](150) NULL,
	[Clinic_addr2] [varchar](150) NULL,
	[Clinic_addr3] [varchar](150) NULL,
	[postcode] [varchar](10) NULL,
	[city] [varchar](100) NULL,
	[state] [varchar](50) NULL,
	[country] [varchar](100) NULL,
	[ContactPerson] [varchar](100) NULL,
	[ContactNo] [varchar](50) NULL,
	[Corp_fax] [varchar](20) NULL,
	[Corp_RegNo] [varchar](50) NULL,
	[Corp_TIN] [varchar](50) NULL,
	[BankID] [int] NULL,
	[BankAccNo] [varchar](30) NULL,
	[rendered_svc] [varchar](10) NULL,
	[panel_type] [varchar](10) NULL,
	[PayeeName] [varchar](100) NULL,
	[Handphone] [varchar](20) NULL,
	[Email] [varchar](200) NULL,
	[IsActive] [bit] NOT NULL,
	[RecruitDate] [datetime] NULL,
	[RemovedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
	[ClinicGroup] [varchar](100) NULL,
	[Latitude] [decimal](12, 9) NOT NULL,
	[Longitude] [decimal](12, 9) NOT NULL,
	[Is24Hour] [bit] NULL,
	[Clinic_cont_MMC] [varchar](50) NULL,
	[PermenantDoc1] [varchar](200) NULL,
	[PermenantDoc1MMC] [varchar](50) NULL,
	[PermenantDoc2] [varchar](200) NULL,
	[PermenantDoc2MMC] [varchar](50) NULL,
	[LocumDoc1] [varchar](200) NULL,
	[LocumDoc1MMC] [varchar](50) NULL,
	[LocumDoc2] [varchar](200) NULL,
	[LocumDoc2MMC] [varchar](50) NULL,
	[Clinic_cont_OHD] [varchar](20) NULL,
	[PermenantDoc1OHD] [varchar](20) NULL,
	[PermenantDoc2OHD] [varchar](20) NULL,
	[LocumDoc1OHD] [varchar](20) NULL,
	[LocumDoc2OHD] [varchar](20) NULL,
	[SSMNo] [varchar](100) NULL,
	[IsPCD] [bit] NULL,
	[IsIVD] [bit] NULL,
	[IsOT] [bit] NULL,
	[IsCPR] [bit] NULL,
	[IsENT] [bit] NULL,
	[IsUFEME] [bit] NULL,
	[IsAvailAN] [bit] NULL,
	[IsAvailMS] [bit] NULL,
	[IsAvailMC] [bit] NULL,
	[IsSpiro] [bit] NULL,
	[IsAudF] [bit] NULL,
	[IsLocDoc] [bit] NULL,
	[IsOHDDoc] [bit] NULL,
	[IsECG] [bit] NULL,
	[IsFBHAM] [bit] NULL,
	[IsAvailFMDoc] [bit] NULL,
	[IsNebulizer] [bit] NULL,
	[IsUltraSound] [bit] NULL,
	[IsPapSme] [bit] NULL,
	[IsXrayReader] [bit] NULL,
	[IsXray] [bit] NULL,
	[MonOH] [varchar](50) NULL,
	[TueOH] [varchar](50) NULL,
	[WedOH] [varchar](50) NULL,
	[ThuOH] [varchar](50) NULL,
	[FriOH] [varchar](50) NULL,
	[SatOH] [varchar](50) NULL,
	[SunOH] [varchar](50) NULL,
 CONSTRAINT [PK__tblClinic__4CA06362] PRIMARY KEY CLUSTERED 
(
	[ClinicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblClinicExclude]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblClinicExclude](
	[CorpID] [int] NULL,
	[ClinicID] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCorp]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCorp](
	[CorpID] [int] IDENTITY(1,1) NOT NULL,
	[Corp_name] [varchar](4000) NULL,
	[Corp_addr1] [varchar](150) NULL,
	[Corp_addr2] [varchar](150) NULL,
	[Corp_addr3] [varchar](150) NULL,
	[postcode] [varchar](10) NULL,
	[city] [varchar](100) NULL,
	[state] [varchar](50) NULL,
	[country] [varchar](100) NULL,
	[ContactPerson] [varchar](100) NULL,
	[Corp_ContactNo] [varchar](50) NULL,
	[Corp_fax] [varchar](20) NULL,
	[Corp_RegNo] [varchar](50) NULL,
	[Corp_TIN] [varchar](50) NULL,
	[BankID] [nvarchar](20) NULL,
	[BankAccNo] [varchar](30) NULL,
	[CorpGroupID] [int] NULL,
	[Email] [varchar](400) NULL,
	[FinanceEmail] [varchar](200) NULL,
	[is2FAlogin] [varchar](5) NULL,
	[IsSuspend] [bit] NOT NULL,
	[IndustryField] [int] NULL,
	[createdDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CorpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCorpDept]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCorpDept](
	[de_id] [varchar](20) NOT NULL,
	[de_CorpID] [int] NOT NULL,
	[de_so_id] [varchar](20) NOT NULL,
	[de_name] [nvarchar](100) NULL,
	[de_addr1] [nvarchar](150) NULL,
	[de_addr2] [nvarchar](150) NULL,
	[de_addr3] [nvarchar](150) NULL,
	[de_postcode] [nvarchar](10) NULL,
	[de_city] [nvarchar](100) NULL,
	[de_state] [nvarchar](50) NULL,
	[de_country] [nvarchar](50) NULL,
	[de_contactPerson] [nvarchar](100) NULL,
	[de_contactNo] [nvarchar](20) NULL,
	[de_fax] [nvarchar](20) NULL,
	[de_RegNo] [nvarchar](50) NULL,
	[de_TIN] [varchar](50) NULL,
	[de_email] [nvarchar](50) NULL,
	[de_remark] [nvarchar](100) NULL,
	[de_BankID] [nvarchar](20) NULL,
	[de_BankAcctNo] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[de_CorpID] ASC,
	[de_so_id] ASC,
	[de_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCorpGroup]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCorpGroup](
	[CorpGroupID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Addr1] [varchar](150) NULL,
	[Addr2] [varchar](150) NULL,
	[Addr3] [varchar](150) NULL,
	[postcode] [varchar](10) NULL,
	[city] [varchar](100) NULL,
	[state] [varchar](50) NULL,
	[country] [varchar](100) NULL,
	[ContactPerson] [varchar](100) NULL,
	[ContactNo] [varchar](50) NULL,
	[Fax] [varchar](20) NULL,
	[RegNo] [varchar](50) NULL,
	[TIN] [varchar](50) NULL,
	[BankID] [nvarchar](20) NULL,
	[BankAccNo] [varchar](30) NULL,
	[Email] [varchar](500) NULL,
	[createdDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CorpGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCorpSuboffice]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCorpSuboffice](
	[so_id] [varchar](20) NOT NULL,
	[so_CorpID] [int] NOT NULL,
	[so_name] [nvarchar](100) NULL,
	[so_addr1] [nvarchar](150) NULL,
	[so_addr2] [nvarchar](150) NULL,
	[so_addr3] [nvarchar](150) NULL,
	[so_postcode] [nvarchar](10) NULL,
	[so_city] [nvarchar](100) NULL,
	[so_state] [nvarchar](50) NULL,
	[so_country] [nvarchar](50) NULL,
	[so_contactPerson] [nvarchar](100) NULL,
	[so_contactNo] [nvarchar](20) NULL,
	[so_fax] [nvarchar](20) NULL,
	[so_RegNo] [nvarchar](50) NULL,
	[so_TIN] [varchar](50) NULL,
	[so_email] [nvarchar](50) NULL,
	[so_remark] [nvarchar](100) NULL,
	[so_BankID] [nvarchar](20) NULL,
	[so_BankAcctNo] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[so_CorpID] ASC,
	[so_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDependents]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDependents](
	[dep_id] [int] IDENTITY(1,1) NOT NULL,
	[emp_id] [int] NOT NULL,
	[dep_name] [nvarchar](100) NULL,
	[dep_ic] [varchar](30) NULL,
	[benefitID] [varchar](10) NULL,
	[relationship] [varchar](2) NULL,
	[dep_gender] [char](1) NULL,
	[dep_dob] [datetime] NULL,
	[dep_race] [nvarchar](20) NULL,
	[dep_nationality] [varchar](50) NULL,
	[join_dt] [datetime] NULL,
	[ent_dt] [datetime] NULL,
	[ClientNumber] [varchar](50) NULL,
	[remarks] [nvarchar](100) NULL,
	[isActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
	[DepResignDT] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[dep_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDiagnosisDropDown]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDiagnosisDropDown](
	[Diag_ID] [varchar](10) NULL,
	[Diag_desc] [varchar](400) NULL,
	[Diag_desc_BM] [varchar](400) NULL,
	[ItemID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDrugs]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDrugs](
	[DrugID] [varchar](20) NOT NULL,
	[DrugType_CodeFK] [varchar](20) NOT NULL,
	[DrugCatFFS_CodeFK] [varchar](20) NOT NULL,
	[DrugDesc] [varchar](500) NOT NULL,
	[ATCClass] [varchar](20) NULL,
	[DrugMIMSClass_CodeFK] [varchar](20) NOT NULL,
	[GenericName] [varchar](500) NULL,
	[DrugRoute_CodeFK] [varchar](20) NOT NULL,
	[DrugUnit_CodeFK] [varchar](20) NOT NULL,
	[ICDCode] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [varchar](50) NULL,
	[DrugChrgField_CodeFK] [varchar](20) NULL,
	[unit_price] [money] NULL,
	[IsChronic] [bit] NULL,
	[MaxQty] [int] NULL,
	[MaxPrice] [decimal](18, 2) NULL,
	[DrugPoisonFFS_CodeFK] [varchar](20) NULL,
	[CeilingPrice] [decimal](18, 2) NULL,
	[IsExclusion] [bit] NULL,
 CONSTRAINT [PK_tblDrugs] PRIMARY KEY CLUSTERED 
(
	[DrugID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmployees]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployees](
	[emp_id] [int] IDENTITY(1,1) NOT NULL,
	[emp_ic] [varchar](30) NULL,
	[emp_name] [nvarchar](100) NULL,
	[CorpID] [varchar](20) NULL,
	[suboffice_fk] [varchar](20) NULL,
	[dept_fk] [varchar](20) NULL,
	[BenefitID] [varchar](10) NULL,
	[emp_gender] [char](1) NULL,
	[emp_dob] [datetime] NULL,
	[emp_race] [nvarchar](20) NULL,
	[emp_nationality] [varchar](50) NULL,
	[addr1] [varchar](150) NULL,
	[addr2] [varchar](150) NULL,
	[addr3] [varchar](150) NULL,
	[postcode] [varchar](10) NULL,
	[city] [varchar](100) NULL,
	[state] [varchar](50) NULL,
	[country] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[cont_no] [varchar](30) NULL,
	[designation] [varchar](100) NULL,
	[remarks] [varchar](100) NULL,
	[join_dt] [datetime] NULL,
	[ent_dt] [datetime] NULL,
	[BankID] [varchar](100) NULL,
	[BankAccNo] [nvarchar](30) NULL,
	[resign_dt] [datetime] NULL,
	[ClientNumber] [varchar](50) NULL,
	[CostCentre] [varchar](100) NULL,
	[isActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblError]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblError](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[sp_name] [varchar](100) NULL,
	[Remarks] [varchar](500) NULL,
	[CreatedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblIndustryField]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblIndustryField](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[IndustryFieldName] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblIndustryField] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVisit]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVisit](
	[VisitID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClinicID] [varchar](20) NULL,
	[emp_id] [int] NULL,
	[dep_id] [int] NULL,
	[benefitid] [varchar](10) NULL,
	[ConsultDate] [datetime] NULL,
	[Status] [varchar](20) NULL,
	[ClaimID] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241011173403_InitialCreate', N'6.0.3')
GO
INSERT [dbo].[AppRoles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b448a7dc-54c6-4060-90f0-86965c07e8f0', N'Employee User', N'Employee', N'EMPLOYEE', N'ee1a11a0-d39b-4907-9f68-ddeffe2ff191')
GO
INSERT [dbo].[AppRoles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4e233be7-c199-4567-9c07-9271a9de4c64', N'Corporate HR', N'Corporate', N'CORPORATE', N'ae808944-13f5-4909-aa73-82a1a2a2cb4c')
GO
INSERT [dbo].[AppRoles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'376c1d1e-0b04-47da-9657-a2a87faf0a59', N'Clinic User', N'Clinic', N'CLINIC', N'58cac793-36e0-4d9e-88e5-d5af2ba6a1c2')
GO
INSERT [dbo].[AppRoles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9f685d0f-bd6f-44dd-ab60-c606952eb2a8', N'Administrator role', N'Admin', N'ADMIN', N'9813a41e-55a0-454b-8e47-3b3b39b65527')
GO
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'faed90a2-9f7d-411a-8119-0fa3a668e660', N'376c1d1e-0b04-47da-9657-a2a87faf0a59')
GO
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'31986efe-9171-44e7-8503-1b4c8f9c1d1b', N'4e233be7-c199-4567-9c07-9271a9de4c64')
GO
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'769f41bd-ccd4-45ba-abbd-550ccd0b62e3', N'9f685d0f-bd6f-44dd-ab60-c606952eb2a8')
GO
INSERT [dbo].[AppUsers] ([Id], [FullName], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [RefTable], [RefId], [Status], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'faed90a2-9f7d-411a-8119-0fa3a668e660', N'Clinic Adminitrator', NULL, NULL, NULL, NULL, N'tblClinic', 1, -1, N'admin8888@gmail.com', N'admin8888@gmail.com', N'admin8888@gmail.com', N'admin8888@gmail.com', 1, N'AQAAAAEAACcQAAAAEIEJbh1qh0Bsi6/9r4DAS6W8v6qrEWoJt2ee5SlXenHtR9OIF2xeGhFwzDrV4WZbzA==', N'', N'6dd2a859-8906-4190-9e8b-44ad689f90db', NULL, 0, 0, NULL, 0, 0)
GO
INSERT [dbo].[AppUsers] ([Id], [FullName], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [RefTable], [RefId], [Status], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'31986efe-9171-44e7-8503-1b4c8f9c1d1b', N'HR Adminitrator', NULL, NULL, NULL, NULL, N'tblCorp', 1, -1, N'corporate@gmail.com', N'corporate@GMAIL.COM', N'corporate@gmail.com', N'corporate@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEGziLUejJiTruwTrW+L1MWUfxBweTtiV765PRs4Yeur/dNhbI5AJ/OvmVS/bUMch6Q==', N'', N'bdfe1f0e-99e3-4a61-9a26-1aa8c901c997', NULL, 0, 0, NULL, 0, 0)
GO
INSERT [dbo].[AppUsers] ([Id], [FullName], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [RefTable], [RefId], [Status], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'769f41bd-ccd4-45ba-abbd-550ccd0b62e3', N'System Adminitrator', CAST(N'2024-10-12T01:34:02.2813422' AS DateTime2), NULL, NULL, NULL, N'tblCorp', 1, -1, N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEJllC7hr4wwQHtFp0UwxRjbbyoWOOZ/wneHiQUu7uHT5mmuQvyWN+tQ+cdKbbOYABg==', N'', N'ca5bcd90-cea6-4b8c-b3a7-2911c0d6bdca', NULL, 0, 0, NULL, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[tblBanks] ON 
GO
INSERT [dbo].[tblBanks] ([Bank_id], [Bank_name], [IsDisplay]) VALUES (1, N'Malayan Banking Berhad', 1)
GO
INSERT [dbo].[tblBanks] ([Bank_id], [Bank_name], [IsDisplay]) VALUES (2, N'Public Bank Berhad', 1)
GO
INSERT [dbo].[tblBanks] ([Bank_id], [Bank_name], [IsDisplay]) VALUES (8, N'Argo Bank', 1)
GO
SET IDENTITY_INSERT [dbo].[tblBanks] OFF
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R10.4', N'Abdominal/Stomach pain', N'( Sakit perut )', 1)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L70', N'Acne ', N'( Jerawat )', 2)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B22', N'Acquired immunodeficiency syndrom ( AIDS )', N'( Sindrom Kurang Daya Tahan Melawan Penyakit )', 3)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K52.9', N'Acute gastroenteritis', N'( Gastroenteritis akut )', 4)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'W00', N'Alleged fall', N'( Terjatuh )', 5)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L63', N'Alopecia areata ', N'( Botak bertompok )', 6)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G30', N'Alzheimer''s disease', N'( Penyakit Alzheimer )', 7)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H53.0', N'Amblyopia/Lazy eye ', N'( Mata malas )', 8)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N91.2', N'Amenorrhea', N'( Tiada haid )', 9)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K61.0', N'Anal abscess', N'( Dubur bernanah )', 10)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K60.2', N'Anal fissure', N'( Luka di dubur )', 11)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K60.3', N'Anal fistula', N'( Fistula dubur )', 12)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'D64', N'Anemia ', N'( Anemia )', 13)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'W57', N'Animal/Insect bites or stings', N'( Gigitan atau sengatan haiwan/serangga )', 14)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S99', N'Ankle and foot injury', N'( Kecederaan buku lali dan kaki )', 15)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Q38.1', N'Ankyloglossia/Tongue tie', N'( Tali lidah )', 16)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'F41', N'Anxiety disorders', N'( Penyakit cemas )', 17)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K36', N'Appendicitis ', N'( Apendiks )', 18)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S49', N'Arm injury', N'( Kecederaan lengan )', 19)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J45', N'Asthma ', N'( Asma )', 20)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I48', N'Atrial Fibrillation', N'( Gangguan degupan jantung )', 21)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M54.5', N'Back pain ', N'( Sakit belakang )', 22)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'F31', N'Bipolar affective disorder', N'( Penyakit gangguan bipolar )', 23)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H54', N'Blindness', N'( Buta )', 24)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L08', N'Blister', N'( Lepuh )', 25)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R09 / J34', N'Blocked nose/Nasal congestion', N'( Hidung tersumbat )', 26)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M25.5', N'Body ache / Joint / Muscle pain ', N'( Sakit badan / Sendi / Otot )', 27)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G93', N'Brain disorder', N'( Penyakit otak )', 28)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S06', N'Brain injury', N'( Kecederaan otak )', 29)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'C50', N'Breast cancer', N'( Kanser payudara )', 30)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N64.9', N'Breast disorder ', N'( Penyakit payudara )', 31)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N63', N'Breast lump ', N'( Ketulan payudara )', 32)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J20', N'Bronchitis ', N'( Keradangan saluran pernafasan ) ', 33)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M71.5', N'Bursitis', N'( Keradangan bursa )', 34)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L02', N'Carbuncle ', N'( Bisul )', 35)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I42', N'Cardiomyopathy ', N'( Penyakit otot jantung )', 36)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G56.0', N'Carpal tunnel syndrome', N'( Sindrom lorong karpal )', 37)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M94', N'Cartilage disease', N'( Penyakit rawan )', 38)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H26', N'Cataract ', N'( Katarak )', 39)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G80', N'Cerebral palsy', N'( Lumpuh otak )', 40)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'C53', N'Cervical cancer', N'( Kanser serviks )', 41)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N87', N'Cervical dysplasia', N'( Displasia serviks )', 42)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M47', N'Cervical spondylosis', N'( Keradangan tulang leher )', 43)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H00.1', N'Chalazion ', N'( Ketumbit )', 44)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R07.4', N'Chest pain', N'( Sakit dada )', 45)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B01', N'Chickenpox', N'( Cacar air )', 46)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K81', N'Cholecystitis', N'( Keradangan hempedu )', 47)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Z41.2', N'Circumcision ', N'( Berkhatan )', 48)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Q35', N'Cleft lip and palate', N'( Sumbing bibir dan lelangit )', 49)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K63.5', N'Colon polyp', N'( Kolon polip )', 50)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'C18', N'Colorectal cancer', N'( Kanser usus )', 51)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Q89.9', N'Congenital condition - please specify', N'( Keadaan kongenital - sila jelaskan )', 52)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H10', N'Conjunctivitis ', N'( Mata merah )', 53)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K59.0', N'Constipation ', N'( Sembelit )', 54)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H16.0', N'Corneal ulcer', N'( Ulser korneal )', 55)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I20', N'Coronary artery disease', N'( Penyakit arteri koronari )', 56)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'U07.1', N'COVID-19 / Coronavirus', N'( COVID-19 / Penyakit Coronavirus )', 57)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R05', N'Cough', N'( Batuk )', 58)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N30.9', N'Cyst - please specify', N'( Ketumbuhan - sila jelaskan ) ', 59)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H91.9', N'Deafness ', N'( Pekak )', 60)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'E86', N'Dehydration', N'( Dehidrasi )', 61)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'A90', N'Dengue fever', N'( Demam denggi )', 62)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K08.9', N'Dental problems', N'( Masalah gigi )', 63)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'F32', N'Depression ', N'( Kemurungan )', 64)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L20', N'Dermatitis/Cellulitis', N'( Keradangan kulit )', 65)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'F81', N'Developmental disorder, behavioural disorders, learning difficulties', N'', 66)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'E14', N'Diabetes mellitus', N'( Kencing manis )', 67)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'E13', N'Diabetic Retinopathy', N'( Retinopati diabetik )', 68)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R19', N'Diarrhea ', N'( Cirit-birit )', 69)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'T03', N'Dislocation, sprain or strain of joints and ligaments - please specify', N'', 70)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R42', N'Dizziness and giddiness ', N'( Pening dan pusing )', 71)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H57.9', N'Dry eyes', N'( Mata kering )', 72)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R68.2', N'Dry mouth', N'( Mulut kering )', 73)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L85.3', N'Dry skin/Xerosis cutis', N'( Kulit kering )', 74)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K26', N'Duodenal ulcer', N'( Ulser duodenal )', 75)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N94.6', N'Dysmenorrhea/Menstrual cramps', N'( Dismenorea/Gangguan senggugut )', 76)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H93.9', N'Ear disorder', N'( Penyakit telinga )', 77)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H93.9', N'Ear infection', N'( Jangkitan telinga )', 78)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L20.8', N'Eczema ', N'( Ekzema )', 79)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S53', N'Elbow injury', N'( Kecederaan siku )', 80)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S53', N'Elbow pain', N'( Sakit siku )', 81)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G04.9', N'Encephalitis ', N'( Keradangan otak )', 82)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N80', N'Endometriosis ', N'( Endometriosis )', 83)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G40', N'Epilepsy', N'( Ayan/Sawan babi )', 84)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R04.0', N'Epistaxis ', N'( Hidung berdarah )', 85)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H57.9', N'Eye disorder', N'( Penyakit mata )', 86)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H43.3', N'Eye floaters ', N'( Pelampung Mata )', 87)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S05', N'Eye injury', N'( Kecederaan mata )', 88)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H02', N'Eyelid disorder', N'( Penyakit kelopak mata )', 89)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H01', N'Eyelid inflammation ', N'( Keradangan kelopak mata )', 90)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R53', N'Fatigue', N'( Kelelahan )', 91)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R56.0', N'Febrile seizure', N'( Sawan demam )', 92)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R50.9', N'Fever ', N'( Demam )', 93)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R63.8', N'Food allergy', N'( Alahan makanan )', 94)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'T62', N'Food poisoning ', N'( Keracunan makanan )', 95)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S99', N'Foot injury', N'( Penyakit kaki )', 96)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'W45', N'Foreign body', N'( Bendasing ) ', 97)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S62.6', N'Fracture of finger', N'( Patah jari )', 98)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S02.2', N'Fracture of nasal bones', N'( Patah tulang hidung )', 99)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K29.7', N'Gastritis ', N'( Gastrik )', 100)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K31.7', N'Gastric polyp', N'( Polip gastrik )', 101)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K25', N'Gastric ulcer', N'( Ulser gastrik )', 102)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K21.9', N'Gastroesophageal reflux disease ( GERD )', N'( Penyakit refluks gastroesofageal )', 103)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Z00', N'General Health Screening', N'( Pemeriksaan kesihatan am )', 104)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'A60.0', N'Genital herpes', N'( Herpes kemaluan )', 105)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K05', N'Gingivitis / Periodontal disease', N'( Keradangan / Penyakit gusi )', 106)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H40', N'Glaucoma ', N'( Glaukoma )', 107)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L65', N'Hair loss', N'( Rambut gugur )', 108)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S69', N'Hand and wrist injury', N'( Kecederaan tangan dan pergelangan tangan )', 109)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B08.4', N'Hand, foot, and mouth disease / Coxsackie', N'( Penyakit tangan, kaki dan mulut )', 110)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S09', N'Head injury', N'( Kecederaan kepala )', 111)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R51', N'Headache', N'( Sakit kepala )', 112)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H91.9', N'Hearing loss', N'( Hilang pendengaran )', 113)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I21', N'Heart attack', N'( Serangan jantung )', 114)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I519', N'Heart disease ', N'( Penyakit jantung )', 115)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I50', N'Heart failure', N'( Kegagalan jantung )', 116)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R12', N'Heartburn', N'( Pedih ulu hati )', 117)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R31', N'Hematuria', N'( Air kencing berdarah )', 118)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I84', N'Hemorrhoids/Piles ', N'( Buasir )', 119)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B15', N'Hepatitis A', N'( Hepatitis A )', 120)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B16', N'Hepatitis B', N'( Hepatitis B )', 121)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B17.1', N'Hepatitis C', N'( Hepatitis C )', 122)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K45', N'Hernia - please specify', N'( Angin pasang - sila jelaskan )', 123)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B00.9', N'Herpes labialis/Oral', N'( Cacar mulut )', 124)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B02', N'Herpes zoster', N'Cacar ular', 125)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S79', N'Hip pain', N'( Sakit pinggul )', 126)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L50.9', N'Hives/Urticaria', N'( Gatal/Gegata )', 127)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B20', N'Human Immunodeficiency Virus ( HIV )', N'( Virus kurang imun manusia )', 128)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R61.9', N'HyperhidrosisÂ ', N'( Peluh berlebihan )', 129)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'E78.5', N'Hyperlipidemia', N'( Kolestrol tinggi )', 130)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I10', N'Hypertension ', N'( Darah tinggi )', 131)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'E05.9', N'Hyperthyroidism', N'( Hipertiroid )', 132)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'E03.9', N'Hypothyroidism ', N'( Hipotiroid )', 133)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H61.2', N'Impacted cerumen/Ear wax', N'( Terkena impak serumen/kotoran telinga )', 134)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N97', N'Infertility', N'( Ketidaksuburan )', 135)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G47', N'Insomnia', N'( Sukar tidur )', 136)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Z00', N'Investigation purposes â€“ Audiometry/Refraction//Vision/Visual/Tonometry/Topography test', N'', 137)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Z00', N'Investigation purposes â€“ Diagnostic test/Imaging/X-Ray/Radiology/Ultrasound/ECG/EEG/MRI/CT-Scan/HPE', N'', 138)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Z00', N'Investigation purposes â€“ Mammogram', N'( Tujuan penyiasatan â€“ Mamogram )', 139)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Z01.4', N'Investigation purposes â€“ Pap smear', N'( Tujuan penyiasatan â€“ Pap smear )', 140)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K58', N'Irritable bowel syndrome', N'( Sindrom iritasi usus )', 141)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I25', N'Ischaemic heart disease', N'( Penyakit jantung iskemik )', 142)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R17', N'Jaundice', N'( Jaundis )', 143)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L91', N'Keloid', N'( Ketumbuhan parut luka )', 144)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L57.0', N'Keratosis', N'( Keratosis )', 145)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N28.9', N'Kidney disease', N'( Penyakit buah pinggang )', 146)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N18', N'Kidney failure', N'( Kegagalan buah pinggang )', 147)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N19', N'Kidney infection', N'( Jangkitan buah pinggang )', 148)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N20.0', N'Kidney stones', N'( Batu karang )', 149)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J04.0', N'Laryngitis', N'( Keradangan pita suara )', 150)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S89', N'Leg injury', N'( Kecederaan kaki )', 151)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'C95.9', N'Leukemia', N'( Kanser darah )', 152)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K76.9', N'Liver disease', N'( Penyakit hati )', 153)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'F50.8', N'Loss appetite', N'( Hilang selera makan )', 154)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'C34', N'Lung cancer', N'( Kanser paru-paru )', 155)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J98.4', N'Lung Disease', N'( Penyakit paru-paru )', 156)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R22', N'Lymphoma ', N'( Limfoma )', 157)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N61', N'Mastitis ', N'( Jangkitan payudara )', 158)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B05', N'Measles', N'( Campak )', 159)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'C43', N'Melanoma', N'( Kanser kulit )', 160)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G00.9', N'Meningitis', N'( Jangkitan selaput otak )', 161)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S83.2', N'Meniscus tears', N'( Kecederaan meniskus )', 162)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N95.1', N'Menopause', N'( Putus haid )', 163)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N92.0', N'Menorrhagia', N'( Haid berlebihan )', 164)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'F89', N'Mental, behavioral and neurodevelopmental disorders ', N'', 165)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G43', N'Migraine ', N'( Migrain )', 166)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'D23', N'Moles ', N'( Tahi lalat )', 167)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'V89.2', N'Motor-vehicle accident', N'( Kemalangan kenderaan bermotor )', 168)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G35', N'Multiple sclerosis ', N'( Sklerosis ganda )', 169)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B26', N'Mumps', N'( Beguk )', 170)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M62.8', N'Muscle Cramps', N'( Kekejangan otot )', 171)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M79.1', N'Myalgia', N'( Gangguan muskokeletal )', 172)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H52.1', N'Myopia ', N'( Rabun )', 173)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M60', N'Myositis', N'( Keradangan otot )', 174)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L60.9', N'Nail deformities', N'( Kecacatan kuku )', 175)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L60.9', N'Nail infection', N'( Jangkitan kuku )', 176)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L60.8', N'Nail injury', N'( Kecederaan kuku )', 177)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J33', N'Nasal polyp', N'( Polip hidung )', 178)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S19', N'Neck injury', N'( Kecederaan leher )', 179)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M54.2', N'Neck/Shoulder pain ', N'( Sakit leher/Bahu ) ', 180)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G73', N'Neuromuscular disorders', N'Gangguan neuromuskular ', 181)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R20.2', N'NumbnessÂ and tingling', N'Kebas dan kesemutan', 182)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N45', N'Orchitis ', N'( Keradangan testis )', 183)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M17', N'Osteoarthritis/Knee Pain', N'( Radang sendi/Sakit lutut )', 184)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H60', N'Otitis externa ', N'( Keradangan saluran luar telinga )', 185)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H66', N'Otitis media', N'( Jangkitan telinga tengah )', 186)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N83.2', N'Ovarian cyst', N'( Sista ovari )', 187)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'C25.9', N'Pancreatic cancer', N'( Kanser pankreas )', 188)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G83.9', N'Paralysis ', N'( Lumpuh )', 189)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G20', N'Parkinson''s disease', N'( Penyakit Parkinson )', 190)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R10', N'Pelvic pain', N'( Sakit pelvis )', 191)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K27', N'Peptic ulcer', N'( Ulser peptik )', 192)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N94', N'Period pain ', N'( Sakit period )', 193)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L81.9', N'Pigmentation ', N'( Jeragat )', 194)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J18.9', N'Pneumonia ', N'( Keradangan paru-paru )', 195)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'E28.2', N'Polycystic ovarian syndrome ( PCOS )', N'( Sindrom polisistik ovari )', 196)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'O72', N'Postpartum hemorrhage', N'( Pendarahan selepas bersalin )', 197)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'O26.9', N'Pregnancy related ', N'( Berkaitan kehamilan )', 198)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'C61', N'Prostate cancer', N'( Kanser prostat )', 199)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N42', N'Prostate disease ', N'( Penyakit prostat )', 200)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N40', N'Prostate Hyperplasia', N'( Pembesaran prostat )', 201)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N41', N'Prostatitis ', N'( Keradangan prostat )', 202)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L40', N'Psoriasis ', N'( Psoriasis )', 203)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H02.4', N'Ptosis', N'( Kelopak mata jatuh )', 204)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R21', N'Rashes ', N'( Ruam )', 205)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K62', N'Rectal bleeding/Hematochezia', N'( Pendarahan rektal/Najis berdarah )', 206)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K62', N'Rectal disease', N'( Penyakit rektum )', 207)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N23', N'Renal colic', N'( Kolik buah pinggang )', 208)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M06', N'Rheumatoid arthritis', N'( Keradangan sendi )', 209)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J30.3', N'Rhinitis ', N'( Keradangan saluran hidung )', 210)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J30.4', N'Rhinitis allergic', N'( Alahan hidung ) ', 211)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L71', N'Rosacea', N'( Radang kulit wajah )', 212)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B86', N'Scabies', N'( Kudis )', 213)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L90.5', N'Scar ', N'( Parut )', 214)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'F20.9', N'Schizophrenia', N'( Skizofrenia )', 215)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M41', N'Scoliosis', N'( Kelengkungan tulang belakang )', 216)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G40.9', N'Seizures/Fits', N'( Sawan )', 217)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'A41.9', N'Sepsis', N'( Jangkitan kuman dalam darah )', 218)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'A64', N'Sexually transmitted disease ', N'( Penyakit kelamin )', 219)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B01.8', N'Shingles', N'( Kayap )', 220)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S49', N'Shoulder injury', N'( Kecederaan bahu )', 221)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S43', N'Shoulder pain', N'( Sakit bahu )', 222)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J01', N'Sinusitis ', N'( Resdung )', 223)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'T78.4', N'Skin Allergy', N'( Alahan kulit )', 224)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'T30.0', N'Skin burn', N'( Kulit terbakar )', 225)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L08', N'Skin infection', N'( Jangkitan kulit )', 226)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L91.8', N'Skin tag ', N'( Daging tumbuh )', 227)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G47.3', N'Sleep apnea', N'( Apnea tidur )', 228)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M51.2', N'Slipped disc / Prolapsed intervertebral disc ( PID )', N'', 229)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R06.8', N'Snoring disorder', N'( Gangguan berdengkur )', 230)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M79.9', N'Soft tissue injury', N'( Kecederaan tisu lembut )', 231)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J02.9', N'Sore throat/Pharyngitis', N'( Sakit/Keradangan tekak )', 232)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'G95.9', N'Spinal disease', N'( Penyakit tulang belakang )', 233)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M48.0', N'Spinal stenosis', N'( Stenosis tulang belakang )', 234)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'T09.3', N'Spine Injury', N'( Kecederaan tulang belakang )', 235)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M47', N'Spondylosis ', N'( Degenerasi tulang belakang )', 236)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H50.8', N'Squint / Strabismus', N'( Juling )', 237)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K12.1', N'Stomatitis', N'( Keradangan mulut )', 238)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'F43.0', N'Stress ', N'( Tekanan )', 239)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I63', N'Stroke', N'( Strok/Angin ahmar )', 240)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M67', N'Tendonitis', N'( Keradangan tendon )', 241)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N50', N'Testis disorder', N'( Penyakit testis )', 242)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S79', N'Thigh injury', N'( Kecederaan paha )', 243)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'E07', N'Thyroid', N'( Tiroid )', 244)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'A49.8', N'Tinea ', N'( Kurap )', 245)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K14.8', N'Tongue disease', N'( Penyakit lidah )', 246)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J03', N'Tonsillitis ', N'( Keradangan tonsil )', 247)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'K08.8', N'Tooth infection', N'( Jangkitan gigi )', 248)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'S83.3', N'Torn ligament', N'( Ligamen koyak )', 249)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'T63', N'Toxic effect of venomous animals', N'( Kesan toksik haiwan berbisa )', 250)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J04.1', N'Tracheitis ', N'( Keradangan trakea )', 251)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'M65.3', N'Trigger finger', N'( Jari terkaku )', 252)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'A15', N'Tuberculosis ', N'( Batuk kering )', 253)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'P83.6', N'Umbilical polyp', N'( Polip pusat )', 254)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'J06.9', N'Upper respiratory tract infection ', N'( Jangkitan saluran pernafasan atas )', 255)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N34', N'Urethritis', N'( Keradangan uretra )', 256)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N39.0', N'Urinary Tract Infection ', N'( Jangkitan saluran kencing )', 257)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'D25', N'Uterine Fibroid ', N'( Fibroid Rahim )', 258)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N84.0', N'Uterine polyp', N'( Polip rahim )', 259)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N81', N'Uterine prolapse', N'( Rahim jatuh )', 260)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Z23', N'Vaccination - Mandatory ( MOH )', N'( Vaksinasi - Wajib ( KKM ) )', 261)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Z23', N'Vaccination - Optional', N'( Vaksinasi - Pilihan )', 262)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'N76.0', N'Vaginitis', N'( Keradangan vagina )', 263)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I86.1', N'Varicoceles', N'( Pembengkakan skrotum )', 264)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'I86', N'Varicose Vein', N'( Urat bengkak )', 265)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'H81.2', N'Vestibular neuronitis', N'( Jangkitan dalam telinga )', 266)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'L80', N'Vitiligo', N'( Sopak )', 267)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'R11', N'Vomit ', N'( Muntah )', 268)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'B07', N'Warts', N'( Ketuat )', 269)
GO
INSERT [dbo].[tblDiagnosisDropDown] ([Diag_ID], [Diag_desc], [Diag_desc_BM], [ItemID]) VALUES (N'Z51', N'Others', N'( Lain-lain )', 999)
GO
SET IDENTITY_INSERT [dbo].[tblIndustryField] ON 
GO
INSERT [dbo].[tblIndustryField] ([ItemID], [IndustryFieldName]) VALUES (1, N'TPA')
GO
INSERT [dbo].[tblIndustryField] ([ItemID], [IndustryFieldName]) VALUES (2, N'Corporate')
GO
INSERT [dbo].[tblIndustryField] ([ItemID], [IndustryFieldName]) VALUES (3, N'HealthCare')
GO
INSERT [dbo].[tblIndustryField] ([ItemID], [IndustryFieldName]) VALUES (4, N'Medical Supplies')
GO
SET IDENTITY_INSERT [dbo].[tblIndustryField] OFF
GO
ALTER TABLE [dbo].[tblBenefits] ADD  DEFAULT ('') FOR [BenefitName]
GO
ALTER TABLE [dbo].[tblBenefits] ADD  DEFAULT ((0)) FOR [annual_cap]
GO
ALTER TABLE [dbo].[tblBenefits] ADD  DEFAULT ((0)) FOR [month_cap]
GO
ALTER TABLE [dbo].[tblBenefits] ADD  DEFAULT ((0)) FOR [day_cap]
GO
ALTER TABLE [dbo].[tblBenefits] ADD  DEFAULT ((0)) FOR [annual_visit]
GO
ALTER TABLE [dbo].[tblBenefits] ADD  DEFAULT ((0)) FOR [month_visit]
GO
ALTER TABLE [dbo].[tblBenefits] ADD  DEFAULT ((0)) FOR [day_visit]
GO
ALTER TABLE [dbo].[tblBenefits] ADD  DEFAULT ((0)) FOR [copay_value]
GO
ALTER TABLE [dbo].[tblBenefits] ADD  DEFAULT ((0)) FOR [max_mcdays]
GO
ALTER TABLE [dbo].[tblBenefits] ADD  DEFAULT ((0)) FOR [IsDep]
GO
ALTER TABLE [dbo].[tblBenefits] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblClaim] ADD  DEFAULT ((0)) FOR [company_pay]
GO
ALTER TABLE [dbo].[tblClaim] ADD  DEFAULT ((0)) FOR [emp_pay]
GO
ALTER TABLE [dbo].[tblClaim] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblCorp] ADD  DEFAULT ('N') FOR [is2FAlogin]
GO
ALTER TABLE [dbo].[AppRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AppRoleClaims_AppRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AppRoles] ([Id])
GO
ALTER TABLE [dbo].[AppRoleClaims] CHECK CONSTRAINT [FK_AppRoleClaims_AppRoles_RoleId]
GO
ALTER TABLE [dbo].[AppUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AppUserClaims_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[AppUserClaims] CHECK CONSTRAINT [FK_AppUserClaims_AppUsers_UserId]
GO
ALTER TABLE [dbo].[AppUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AppUserLogins_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[AppUserLogins] CHECK CONSTRAINT [FK_AppUserLogins_AppUsers_UserId]
GO
ALTER TABLE [dbo].[AppUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AppUserRoles_AppRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AppRoles] ([Id])
GO
ALTER TABLE [dbo].[AppUserRoles] CHECK CONSTRAINT [FK_AppUserRoles_AppRoles_RoleId]
GO
ALTER TABLE [dbo].[AppUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AppUserRoles_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[AppUserRoles] CHECK CONSTRAINT [FK_AppUserRoles_AppUsers_UserId]
GO
ALTER TABLE [dbo].[AppUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AppUserTokens_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[AppUserTokens] CHECK CONSTRAINT [FK_AppUserTokens_AppUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[APP_GetClinicInfo]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[APP_GetClinicInfo]
	@UserId varchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;
	--declare @intCorpID int

	--select @intCorpID = CorpID from tblUser with (nolock) where user_id = @UserId

	select ClinicID, Clinic_name, Clinic_addr1, Clinic_addr2, Clinic_addr3, 
		postcode, city, state, country, ContactNo, Longitude, Latitude,
		MonOH, TueOH, WedOH, ThuOH, FriOH, SatOH, SunOH
	From tblClinic with (nolock)

END

GO
/****** Object:  StoredProcedure [dbo].[APP_GetDiagnosisList]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[APP_GetDiagnosisList]
	@UserId varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @intCorpID int

	select @intCorpID = CorpID from tblUser with (nolock) where user_id = @UserId

	select diag_desc + ' ' + Diag_desc_BM from [dbo].[tblDiagnosisDropDown] order by ItemID
		
END

GO
/****** Object:  StoredProcedure [dbo].[APP_GetMemberBenefit]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[APP_GetMemberBenefit]
	@EmpId int, 
	@DepId int
AS
BEGIN
	SET NOCOUNT ON;
	declare @dblClaimAmt decimal(18,2)
	declare @dblClaimReimAmt decimal(18,2)
	declare @dblTotalUsedAmt decimal(18,2)
	declare @strBenefitID varchar(10)
	declare @strCorpID varchar(20)
	declare @strEmpDepCov varchar(5)
	declare @dblAnnualLimit decimal(18,2)
	declare @dblMonthLimit decimal(18,2)
	declare @dblDayLimit decimal(18,2)
	declare @dtStartDate datetime
	declare @dtEndDate datetime
	declare @intAnnualVisit int
	declare @intMonthVisit int
	declare @intDayVisit int
	declare @strVisitRemark varchar(50)
	declare @intVisit int
	declare @dblTotalVisit int

	SET @dblTotalVisit = 0
	SET @intVisit = 0
	
	IF @DepId is null
	BEGIN
		SELECT @strBenefitID = BenefitID, @strCorpID = CorpID 
		from tblEmployees with (nolock)
		where emp_id = @EmpId
	END
	ELSE
	BEGIN
		SELECT @strBenefitID = isnull(tblDependents.benefitID,tblEmployees.BenefitID), @strCorpID = CorpID 
		from tblDependents with (nolock)
			inner join tblEmployees with (nolock) on tblDependents.emp_id = tblEmployees.emp_id
		where dep_id = @DepId
	END

	select @strEmpDepCov = EmpDepCov, 
			@dblAnnualLimit = annual_cap,
			@dblMonthLimit = month_cap,
			@dblDayLimit = day_cap,
			@intAnnualVisit = annual_visit,
			@intMonthVisit = month_visit,
			@intDayVisit = day_visit
	From tblBenefits with (nolock)
	where corpid = @strCorpID
	and BenefitID = @strBenefitID

--Limit
if (isnull(@dblAnnualLimit,0) + isnull(@dblMonthLimit,0) + isnull(@dblDayLimit,0)) > 0
BEGIN
	if isnull(@dblAnnualLimit,0) > 0
	BEGIN
		set @dtStartDate = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()) + 1, 0)
	END
	Else if isnull(@dblMonthLimit,0) > 0
	BEGIN
		set @dtStartDate = DATEADD(MM, DATEDIFF(MM, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(MM, DATEDIFF(MM, 0, GETDATE()) + 1, 0)
	END
	Else if isnull(@dblDayLimit,0) > 0
	BEGIN
		set @dtStartDate = DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 1)
	END
	
	if @strEmpDepCov in ('E','F')
	BEGIN
		select @dblClaimAmt = sum(company_pay) 
		From tblClaim with (nolock) 
		where emp_id = @EmpId
		and tblClaim.ConsultDate >= @dtStartDate
		and tblClaim.ConsultDate < @dtEndDate

		select @dblClaimReimAmt = sum(company_pay) 
		From tblClaimReim  with (nolock) 
		where emp_id = @EmpId
		and tblClaimReim.ConsultDate >= @dtStartDate
		and tblClaimReim.ConsultDate < @dtEndDate
	END
	else if @strEmpDepCov = 'EF'
	BEGIN
		if @DepId is null
		BEGIN
			select @dblClaimAmt = sum(company_pay) 
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate

			select @dblClaimReimAmt = sum(company_pay) 
			From tblClaimReim  with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaimReim.ConsultDate >= @dtStartDate
			and tblClaimReim.ConsultDate < @dtEndDate
		END
		else
		BEGIN
			select @dblClaimAmt = sum(company_pay) 
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is not null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate

			select @dblClaimReimAmt = sum(company_pay) 
			From tblClaimReim  with (nolock) 
			where emp_id = @EmpId and dep_id is not null
			and tblClaimReim.ConsultDate >= @dtStartDate
			and tblClaimReim.ConsultDate < @dtEndDate
		END
	END
	else if @strEmpDepCov = 'D'
	BEGIN
		if @DepId is null
		BEGIN
			select @dblClaimAmt = sum(company_pay) 
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate

			select @dblClaimReimAmt = sum(company_pay) 
			From tblClaimReim  with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaimReim.ConsultDate >= @dtStartDate
			and tblClaimReim.ConsultDate < @dtEndDate
		END
		else
		BEGIN
			select @dblClaimAmt = sum(company_pay) 
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id = @DepId
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate

			select @dblClaimReimAmt = sum(company_pay) 
			From tblClaimReim  with (nolock) 
			where emp_id = @EmpId and dep_id = @DepId
			and tblClaimReim.ConsultDate >= @dtStartDate
			and tblClaimReim.ConsultDate < @dtEndDate
		END
	END
END

--Visit 
if (isnull(@intAnnualVisit,0) + isnull(@intMonthVisit,0) + isnull(@intDayVisit,0)) > 0
BEGIN
	if isnull(@intAnnualVisit,0) > 0
	BEGIN
		SET @strVisitRemark = 'Total Annual GP Visit'
		SET @intVisit = @intAnnualVisit
		set @dtStartDate = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()) + 1, 0)
	END
	Else if isnull(@intMonthVisit,0) > 0
	BEGIN
		SET @strVisitRemark = 'Total Monthly GP Visit'
		SET @intVisit = @intMonthVisit
		set @dtStartDate = DATEADD(MM, DATEDIFF(MM, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(MM, DATEDIFF(MM, 0, GETDATE()) + 1, 0)
	END
	Else if isnull(@intDayVisit,0) > 0
	BEGIN
		SET @strVisitRemark = 'Total Daily GP Visit'
		SET @intVisit = @intDayVisit
		set @dtStartDate = DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 1)
	END
	
	if @strEmpDepCov in ('E','F')
	BEGIN
		select @dblTotalVisit = count(1)
		From tblClaim with (nolock) 
		where emp_id = @EmpId
		and tblClaim.ConsultDate >= @dtStartDate
		and tblClaim.ConsultDate < @dtEndDate
	END
	else if @strEmpDepCov = 'EF'
	BEGIN
		if @DepId is null
		BEGIN
			select @dblTotalVisit = count(1)
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate
		END
		else
		BEGIN
			select @dblTotalVisit = count(1)
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is not null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate
		END
	END
	else if @strEmpDepCov = 'D'
	BEGIN
		if @DepId is null
		BEGIN
			select @dblTotalVisit = count(1)
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate
		END
		else
		BEGIN
			select @dblTotalVisit = count(1)
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id = @DepId
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate
		END
	END
END
	

	SELECT @dblTotalUsedAmt = isnull(@dblClaimAmt,0) + isnull(@dblClaimReimAmt,0)

	if isnull(@dblAnnualLimit,0) > 0
	BEGIN
		SELECT 'GP Annual Limit', @dblAnnualLimit, @dblTotalUsedAmt, @dblAnnualLimit - @dblTotalUsedAmt , 'GP'
		Union
		SELECT @strVisitRemark, @intVisit,  @dblTotalVisit, @intVisit -  @dblTotalVisit, 'GPVisit'
	END
	Else if isnull(@dblMonthLimit,0) > 0
	BEGIN
		SELECT 'GP Monthly Limit', @dblMonthLimit, @dblTotalUsedAmt, @dblMonthLimit - @dblTotalUsedAmt , 'GP'
		Union
		SELECT @strVisitRemark, @intVisit,  @dblTotalVisit, @intVisit -  @dblTotalVisit, 'GPVisit'
	END
	Else if isnull(@dblDayLimit,0) > 0
	BEGIN
		SELECT 'GP Daily Limit', @dblDayLimit, @dblTotalUsedAmt, @dblDayLimit - @dblTotalUsedAmt , 'GP'
		Union
		SELECT @strVisitRemark, @intVisit,  @dblTotalVisit, @intVisit -  @dblTotalVisit, 'GPVisit'
	END
		
END

GO
/****** Object:  StoredProcedure [dbo].[APP_GetMemberClaimHistory]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[APP_GetMemberClaimHistory]
	@UserId varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	declare @intEmpID int

	select @intEmpID = EmpID from tblUser with (nolock) where user_id = @UserId

	select isnull(tblDependents.dep_name,tblEmployees.emp_name),
			convert(varchar,tblClaim.CreatedDate,106),
			convert(varchar,tblClaim.consultdate,106),
			'Cashless',
			tblClaim.company_pay,
			tblClaim.claim_status
	from tblClaim with (nolock)
		inner join tblEmployees with (nolock) on tblClaim.emp_id = tblEmployees.emp_id
		left outer join tblDependents with (nolock) on tblClaim.dep_id = tblDependents.dep_id
	where tblClaim.emp_id = @intEmpID
	union
	select isnull(tblDependents.dep_name,tblEmployees.emp_name),
			convert(varchar,tblClaimReim.CreatedDate,106),
			convert(varchar,tblClaimReim.ConsultDate,106),
			'Reimbursement',
			tblClaimReim.company_pay,
			tblClaimReim.Status
	from tblClaimReim with (nolock)
		inner join tblEmployees with (nolock) on tblClaimReim.emp_id = tblEmployees.emp_id
		left outer join tblDependents with (nolock) on tblClaimReim.dep_id = tblDependents.dep_id
	where tblClaimReim.emp_id = @intEmpID
		
END

GO
/****** Object:  StoredProcedure [dbo].[APP_GetMemberInfo]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[APP_GetMemberInfo]
	@UserId varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @intEmpID int

	select @intEmpID = EmpID from tblUser with (nolock) where user_id = @UserId

	select 1 as seq, emp_id, emp_name, emp_ic, emp_gender, convert(varchar,emp_dob,106), ClientNumber,'E', tblEmployees.email, cont_no, tblCorp.Corp_name 
	From tblEmployees with (nolock)
		inner join tblCorp with (nolock) on tblEmployees.CorpID = tblCorp.CorpID
	where emp_id = @intEmpID
	union
	select 2 as seq, emp_id, dep_name, dep_ic, dep_gender, convert(varchar,dep_dob,106), ClientNumber,relationship, '' , '', '' 
	from tblDependents with (nolock)
	where emp_id = @intEmpID
	order by emp_id, seq
		
END

GO
/****** Object:  StoredProcedure [dbo].[APP_ScanQR]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[APP_ScanQR]
	@ClinicID varchar(20),
	@EmpId int,
	@DepId int
AS
BEGIN
	CREATE TABLE #tblMemberTemp
	(
		emp_id int,
		emp_name varchar(200),
		emp_ic varchar(30),
		resign_dt datetime,
		ent_dt datetime,
		annual_cap decimal(18, 2),
		month_cap decimal(18, 2),
		day_cap decimal(18, 2),
		annual_visit int,
		month_visit int,
		day_visit int,
		copay_type varchar(1),
		copay_value decimal(18, 2),
		max_mcdays int,
		DisplayMsg varchar(1000),
		corp_id varchar(100),
		corp_name varchar(4000),
		corpgroupID int,
		Relationship varchar(10),
		BenefitID varchar(30),
		dep_id int,
		dep_name varchar(200),
		dep_ic varchar(30),
		dep_resign_dt datetime,
		dep_ent_dt datetime,
		BalanceAmt decimal(18,2),
		BalanceMCDay decimal(18,1)
	)

	declare @dtVisitDate datetime
	set @dtVisitDate = convert(varchar,getdate(),106)

	INSERT INTO #tblMemberTemp  
			EXECUTE CLC_SearchMember @ClinicID, '','', @EmpId, @DepId

	if exists (select 1 from #tblMemberTemp)
	BEGIN
		insert into tblVisit
			select @ClinicID, emp_id, dep_id, BenefitID, @dtVisitDate, 'PENDING', NULL, getdate(),'MobileScanQR',getdate() from #tblMemberTemp

		select 'Successful'
	END
	ELSE
	BEGIN
		insert into tblError values ('APP_ScanQR','failed to scan QR',getdate())
		
		select 'Failure'
	END
END

GO
/****** Object:  StoredProcedure [dbo].[APP_SubmitClaim]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[APP_SubmitClaim]
	@UserId varchar(50),
	@emp_id int,
	@dep_id int,
	@ReceiptNo varchar(100),
	@IsPanel bit,
	@ClinicName varchar(100),
	@ConsultDate datetime,
	@Diag_ID varchar(10),
	@DiagnosisOthers varchar(1000),
	@TotalCharge decimal(18,2),
	@MC_DayGiven decimal(10,1),
	@MC_StartDate datetime,
	@MC_filename varchar(100),
	@FileName varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	insert into tblClaimReim values 
		(@emp_id,@dep_id,@ReceiptNo,@IsPanel,@ClinicName,
		 @ConsultDate,@DiagnosisOthers,@TotalCharge,0,0,
		 @MC_DayGiven, @MC_StartDate, @MC_filename, '','Mobile',
		 @UserId,@Diag_ID,@FileName, NULL,NULL,'PENDING',NULL,getdate(),@UserId,getdate())
		
END

GO
/****** Object:  StoredProcedure [dbo].[CLC_GetClinicInfo]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CLC_GetClinicInfo]
	@strClinicID varchar(100) 
AS
BEGIN
	
	SET NOCOUNT ON;
	--declare @intCorpID int

	--select @intCorpID = CorpID from tblUser with (nolock) where user_id = @UserId

	select ClinicID, Clinic_name, Clinic_addr1, Clinic_addr2, Clinic_addr3, 
		postcode, city, state, country, ContactPerson, ContactNo, Corp_fax, Corp_RegNo, Corp_TIN, dbo.fn_GetBankName(BankID), BankAccNo, PayeeName,
		Handphone, email, Is24Hour, Longitude, Latitude, SSMNo, ispcd, IsIVD, isot, iscpr, IsENT, IsUFEME, IsAvailAN, IsAvailMS, IsAvailMC, IsSpiro, 
		IsAudF, IsLocDoc, IsOHDDoc, IsECG, IsFBHAM, IsAvailFMDoc, IsNebulizer, IsUltraSound, IsPapSme, IsXrayReader, IsXray,
		MonOH, TueOH, WedOH, ThuOH, FriOH, SatOH, SunOH
	From tblClinic with (nolock)
	where ClinicID = @strClinicID

END

GO
/****** Object:  StoredProcedure [dbo].[CLC_GetRecordScanQR]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CLC_GetRecordScanQR]
	@intVisitID bigint 
AS
BEGIN
	
	SET NOCOUNT ON;
	--declare @intCorpID int

	--select @intCorpID = CorpID from tblUser with (nolock) where user_id = @UserId

	select ClinicID, Emp_Id, Dep_id, benefitid, status, convert(varchar,consultdate,106) as VisitDate, convert(varchar,createddate,106) as ScanDate
	From tblVisit with (nolock)
	where VisitID = @intVisitID

END

GO
/****** Object:  StoredProcedure [dbo].[CLC_Rpt_Claim]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CLC_Rpt_Claim]
	@strClinicID varchar(100), 
	@dtStartDate datetime,
	@dtEndDate datetime
AS
BEGIN
	
	SET NOCOUNT ON;

	If @dtStartDate is null
	BEGIN
		select top 1000 *
		From tblClaim with (nolock)
		where ClinicID = @strClinicID
		order by ClaimID desc
	END
	ELSE
	BEGIN
		select *
		From tblClaim with (nolock)
		where ClinicID = @strClinicID
		and ConsultDate >= @dtStartDate
		and ConsultDate <= @dtEndDate
		order by ClaimID desc
	END
	

END

GO
/****** Object:  StoredProcedure [dbo].[CLC_SearchMember]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CLC_SearchMember]
	@ClinicID varchar(20),
	@strIC varchar(20),
	@strName varchar(60),
	@intQREmpID int,
	@intQRDepID int
AS
BEGIN
	CREATE TABLE #tblEmp
	(
		emp_id int,
		resign_dt datetime,
	)

	CREATE TABLE #tblDep
	(
		emp_id int,
		dep_id int,
		DepResignDT datetime,

	)

	CREATE TABLE #tblMemberTemp
	(
		emp_id int,
		emp_name varchar(200),
		emp_ic varchar(30),
		resign_dt datetime,
		ent_dt datetime,
		annual_cap decimal(18, 2),
		month_cap decimal(18, 2),
		day_cap decimal(18, 2),
		annual_visit int,
		month_visit int,
		day_visit int,
		copay_type varchar(1),
		copay_value decimal(18, 2),
		max_mcdays int,
		DisplayMsg varchar(1000),
		corp_id varchar(100),
		corp_name varchar(4000),
		corpgroupID int,
		Relationship varchar(10),
		BenefitID varchar(30),
		dep_id int,
		dep_name varchar(200),
		dep_ic varchar(30),
		dep_resign_dt datetime,
		dep_ent_dt datetime,
		BalanceAmt decimal(18,2),
		BalanceMCDay decimal(18,1)
	)

	CREATE TABLE #tblMemberBenefit                   
	(                                  
		BenDesc varchar(500),                    
		Limit decimal(18, 2),        
		AmountUsed decimal(18, 2),                    
		Balance decimal(18, 2),   
		BenType varchar(10)             
	) 


	DECLARE @dtConsultDate7day datetime
	DECLARE @intEmpID int
	DECLARE @intDepID int
	 
	SET @dtConsultDate7day = dateadd(d,-7,getdate())
	SET @strIC = replace(isnull(@strIC,''),'-','')
	SET @strName = isnull(@strName,'')

	IF LEN(@strIC) > 0
	BEGIN
		insert into #tblEmp
			select emp_id, resign_dt from tblEmployees with (nolock) where emp_ic = @strIC
		
		insert into #tblDep
			select dep_id, emp_id, DepResignDT from tblDependents with (nolock) where dep_ic = @strIC
	END
	ELSE IF LEN(@strName) > 0
	BEGIN
		insert into #tblEmp
			select emp_id, resign_dt from tblEmployees with (nolock) where emp_name like '%' + @strName + '%'
		
		insert into #tblDep
			select dep_id, emp_id, DepResignDT from tblDependents with (nolock) where dep_name like '%' + @strName + '%'
	END
	ELSE IF isnull(@intQRDepID,0) > 0
	BEGIN
		insert into #tblDep
			select dep_id, emp_id, DepResignDT from tblDependents with (nolock) where dep_id = @intQRDepID
	END
	ELSE IF isnull(@intQREmpID,0) > 0
	BEGIN
		insert into #tblEmp
			select emp_id, resign_dt from tblEmployees with (nolock) where emp_id = @intQREmpID
	END

	DELETE FROM #tblEmp where resign_dt < @dtConsultDate7day 
	DELETE FROM #tblDep where DepResignDT < @dtConsultDate7day 


	if exists (select 1 from #tblEmp)
	BEGIN
		INSERT INTO #tblMemberTemp
			SELECT tblEmployees.emp_id, tblEmployees.emp_name, tblEmployees.emp_ic, tblEmployees.resign_dt, tblEmployees.ent_dt, 
					tblBenefits.annual_cap, tblBenefits.month_cap, tblBenefits.day_cap, 
					tblBenefits.annual_visit, tblBenefits.month_visit, tblBenefits.day_visit,
					tblBenefits.copay_type, tblBenefits.copay_value, tblBenefits.max_mcdays,
					'',tblEmployees.CorpID, tblCorp.Corp_name, tblCorp.CorpGroupID, 'Employee', tblEmployees.BenefitID,
					NULL,NULL,NULL,NULL,NULL,0,0
			FROM tblEmployees with (nolock)
				inner join tblBenefits with (nolock) on tblEmployees.CorpID = tblBenefits.CorpID and tblEmployees.BenefitID = tblBenefits.BenefitID
				inner join tblCorp with (nolock) on tblEmployees.CorpID = tblCorp.CorpID
				inner join #tblEmp with (nolock) on tblEmployees.emp_id = #tblEmp.emp_id
	END
	
	if exists (select 1 from #tblDep)
	BEGIN
		INSERT INTO #tblMemberTemp
			SELECT tblEmployees.emp_id, tblEmployees.emp_name, tblEmployees.emp_ic, tblEmployees.resign_dt, tblEmployees.ent_dt, 
					tblBenefits.annual_cap, tblBenefits.month_cap, tblBenefits.day_cap, 
					tblBenefits.annual_visit, tblBenefits.month_visit, tblBenefits.day_visit,
					tblBenefits.copay_type, tblBenefits.copay_value, tblBenefits.max_mcdays,
					'',tblEmployees.CorpID, tblCorp.Corp_name, tblCorp.CorpGroupID, case when tblDependents.relationship = 'S' then 'Spouse' when tblDependents.relationship = 'C' then 'Child' else '' end  ,isnull(tblDependents.benefitID,tblEmployees.BenefitID),
					tblDependents.dep_id, tblDependents.dep_name, tblDependents.dep_ic, tblDependents.DepResignDT, tblDependents.ent_dt,0,0
			FROM tblDependents with (nolock)
				inner join tblEmployees with (nolock) on tblEmployees.emp_id = tblDependents.emp_id 
				inner join tblBenefits with (nolock) on tblEmployees.CorpID = tblBenefits.CorpID and tblBenefits.BenefitID = isnull(tblDependents.benefitID,tblEmployees.BenefitID)
				inner join tblCorp with (nolock) on tblEmployees.CorpID = tblCorp.CorpID
				inner join #tblDep with (nolock) on tblDependents.dep_id = #tblDep.dep_id and tblDependents.emp_id = #tblDep.emp_id
	END		

	--search clinic
	if not exists (select 1 from tblClinic with (nolock) where ClinicID = @ClinicID and IsActive = 1 )
	BEgin
		delete from #tblMemberTemp
	End
	
	--exclude clinic
	delete from #tblMemberTemp where corp_id in (select CorpID from tblClinicExclude with (nolock) where ClinicID = @ClinicID)

	DECLARE @f_fetch numeric(12,0)
	DECLARE my_cursor CURSOR FOR   
			 select emp_id, dep_id  from #tblMemberTemp

	OPEN my_cursor      
  
	SELECT @f_fetch = 0                       
	WHILE (@f_fetch  <> -1)       
	BEGIN      
		FETCH NEXT FROM my_cursor INTO @intEmpID, @intDepID  
  
		SELECT @f_fetch = @@FETCH_STATUS      
  
		IF (@f_fetch <> -1)       
		BEGIN   
			INSERT INTO #tblMemberBenefit  
					EXECUTE APP_GetMemberBenefit @intEmpID, @intDepID

			if @intDepID is null
			BEGIN
				update #tblMemberTemp 
				set BalanceAmt = (select Balance from #tblMemberBenefit where BenType = 'GP')
				where emp_id = @intEmpID and dep_id is null
			END
			ELSE
			BEGIN
				update #tblMemberTemp 
				set BalanceAmt = (select Balance from #tblMemberBenefit where BenType = 'GP')
				where emp_id = @intEmpID and dep_id = @intDepID
			END
		END
	END
	DEALLOCATE my_cursor  
	 
	
	select * from #tblMemberTemp


	 
	DROP TABLE #tblEmp
	DROP TABLE #tblDep
	DROP TABLE #tblMemberTemp

END

GO
/****** Object:  StoredProcedure [dbo].[CLC_SubmitClaim]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CLC_SubmitClaim]
	@UserId varchar(50),
	@ClinicID varchar(20),
	@emp_id int,
	@dep_id int,
	@BenefitID varchar(10),
	@ConsultDate datetime,
	@consult_fee decimal(18, 2),
	@med_fee decimal(18, 2),
	@xray_fee decimal(18, 2),
	@lab_fee decimal(18, 2),
	@inject_fee decimal(18, 2),
	@surg_fee decimal(18, 2),
	@screen_fee decimal(18, 2),
	@dressing_fee decimal(18, 2),
	@others_fee decimal(18, 2),
	@referral_fee decimal(18, 2),
	@referral_to varchar(100),
	@other_cost_rmks nvarchar(200),
	@total_charge decimal(18, 2),
	@company_pay decimal(18, 2),
	@emp_pay decimal(18, 2),
	@MC_type varchar(10) ,
	@MC_DayGiven decimal(10, 1) ,
	@MC_StartDate datetime ,
	@MC_Remarks nvarchar(100) ,
	@DRName varchar(100) 
AS
BEGIN
	SET NOCOUNT ON;

	insert into tblClaim values 
		(@ClinicID,@emp_id,@dep_id,@BenefitID,@ConsultDate,
		 @consult_fee,@med_fee,@xray_fee,@lab_fee,@inject_fee,@surg_fee,@screen_fee,
		 @dressing_fee,@others_fee,@referral_fee, @referral_to,@other_cost_rmks,
		 @total_charge,@company_pay,@emp_pay,@MC_type,@MC_DayGiven,@MC_StartDate,@MC_Remarks,'APPROVED',@DRName, 
		 0, NULL,NULL,'',0,getdate(),@UserId,getdate()   )
END

GO
/****** Object:  StoredProcedure [dbo].[HR_GetBenefitInfo]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[HR_GetBenefitInfo]
	@CorpID int
AS
BEGIN
	
	SET NOCOUNT ON;
	--declare @intCorpID int

	--select @intCorpID = CorpID from tblUser with (nolock) where user_id = @UserId

	select BenefitID,
		BenefitName,
		annual_cap,
		month_cap,
		day_cap,
		annual_visit,
		month_visit,
		day_visit,
		copay_type,
		copay_value,
		max_mcdays,
		isdep,
		exclusion,
		remarks,
		EmpDepCov,
		ProRateType
	From tblBenefits with (nolock)
	where corpid = @CorpID

END

GO
/****** Object:  StoredProcedure [dbo].[HR_GetClinicInfo]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[HR_GetClinicInfo]
	@CorpID int
AS
BEGIN
	
	SET NOCOUNT ON;
	--declare @intCorpID int

	--select @intCorpID = CorpID from tblUser with (nolock) where user_id = @UserId

	select ClinicID, Clinic_name, Clinic_addr1, Clinic_addr2, Clinic_addr3, 
		postcode, city, state, country, ContactNo, Longitude, Latitude,
		MonOH, TueOH, WedOH, ThuOH, FriOH, SatOH, SunOH
	From tblClinic with (nolock)

END

GO
/****** Object:  StoredProcedure [dbo].[HR_GetCorporateInfo]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[HR_GetCorporateInfo]
	@CorpID int
AS
BEGIN
	
	SET NOCOUNT ON;
	--declare @intCorpID int

	--select @intCorpID = CorpID from tblUser with (nolock) where user_id = @UserId

	select Corp_name,
		Corp_addr1,
		Corp_addr2,
		Corp_addr3,
		postcode,
		city,
		state,
		country,
		ContactPerson,
		Corp_ContactNo,
		Corp_fax,
		Corp_RegNo,
		Corp_TIN,
		dbo.fn_GetBankName(BankID) as bankname,
		BankAccNo,
		Email,
		FinanceEmail,
		is2FAlogin,
		IndustryField
	From tblCorp with (nolock)
	Where CorpID = @CorpID

END

GO
/****** Object:  StoredProcedure [dbo].[HR_GetMemberBenefit]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[HR_GetMemberBenefit]
	@EmpId int, 
	@DepId int
AS
BEGIN
	SET NOCOUNT ON;
	declare @dblClaimAmt decimal(18,2)
	declare @dblClaimReimAmt decimal(18,2)
	declare @dblTotalUsedAmt decimal(18,2)
	declare @strBenefitID varchar(10)
	declare @strCorpID varchar(20)
	declare @strEmpDepCov varchar(5)
	declare @dblAnnualLimit decimal(18,2)
	declare @dblMonthLimit decimal(18,2)
	declare @dblDayLimit decimal(18,2)
	declare @dtStartDate datetime
	declare @dtEndDate datetime
	declare @intAnnualVisit int
	declare @intMonthVisit int
	declare @intDayVisit int
	declare @strVisitRemark varchar(50)
	declare @intVisit int
	declare @dblTotalVisit int

	SET @dblTotalVisit = 0
	SET @intVisit = 0
	
	IF @DepId is null
	BEGIN
		SELECT @strBenefitID = BenefitID, @strCorpID = CorpID 
		from tblEmployees with (nolock)
		where emp_id = @EmpId
	END
	ELSE
	BEGIN
		SELECT @strBenefitID = isnull(tblDependents.benefitID,tblEmployees.BenefitID), @strCorpID = CorpID 
		from tblDependents with (nolock)
			inner join tblEmployees with (nolock) on tblDependents.emp_id = tblEmployees.emp_id
		where dep_id = @DepId
	END

	select @strEmpDepCov = EmpDepCov, 
			@dblAnnualLimit = annual_cap,
			@dblMonthLimit = month_cap,
			@dblDayLimit = day_cap,
			@intAnnualVisit = annual_visit,
			@intMonthVisit = month_visit,
			@intDayVisit = day_visit
	From tblBenefits with (nolock)
	where corpid = @strCorpID
	and BenefitID = @strBenefitID

--Limit
if (isnull(@dblAnnualLimit,0) + isnull(@dblMonthLimit,0) + isnull(@dblDayLimit,0)) > 0
BEGIN
	if isnull(@dblAnnualLimit,0) > 0
	BEGIN
		set @dtStartDate = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()) + 1, 0)
	END
	Else if isnull(@dblMonthLimit,0) > 0
	BEGIN
		set @dtStartDate = DATEADD(MM, DATEDIFF(MM, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(MM, DATEDIFF(MM, 0, GETDATE()) + 1, 0)
	END
	Else if isnull(@dblDayLimit,0) > 0
	BEGIN
		set @dtStartDate = DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 1)
	END
	
	if @strEmpDepCov in ('E','F')
	BEGIN
		select @dblClaimAmt = sum(company_pay) 
		From tblClaim with (nolock) 
		where emp_id = @EmpId
		and tblClaim.ConsultDate >= @dtStartDate
		and tblClaim.ConsultDate < @dtEndDate

		select @dblClaimReimAmt = sum(company_pay) 
		From tblClaimReim  with (nolock) 
		where emp_id = @EmpId
		and tblClaimReim.ConsultDate >= @dtStartDate
		and tblClaimReim.ConsultDate < @dtEndDate
	END
	else if @strEmpDepCov = 'EF'
	BEGIN
		if @DepId is null
		BEGIN
			select @dblClaimAmt = sum(company_pay) 
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate

			select @dblClaimReimAmt = sum(company_pay) 
			From tblClaimReim  with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaimReim.ConsultDate >= @dtStartDate
			and tblClaimReim.ConsultDate < @dtEndDate
		END
		else
		BEGIN
			select @dblClaimAmt = sum(company_pay) 
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is not null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate

			select @dblClaimReimAmt = sum(company_pay) 
			From tblClaimReim  with (nolock) 
			where emp_id = @EmpId and dep_id is not null
			and tblClaimReim.ConsultDate >= @dtStartDate
			and tblClaimReim.ConsultDate < @dtEndDate
		END
	END
	else if @strEmpDepCov = 'D'
	BEGIN
		if @DepId is null
		BEGIN
			select @dblClaimAmt = sum(company_pay) 
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate

			select @dblClaimReimAmt = sum(company_pay) 
			From tblClaimReim  with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaimReim.ConsultDate >= @dtStartDate
			and tblClaimReim.ConsultDate < @dtEndDate
		END
		else
		BEGIN
			select @dblClaimAmt = sum(company_pay) 
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id = @DepId
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate

			select @dblClaimReimAmt = sum(company_pay) 
			From tblClaimReim  with (nolock) 
			where emp_id = @EmpId and dep_id = @DepId
			and tblClaimReim.ConsultDate >= @dtStartDate
			and tblClaimReim.ConsultDate < @dtEndDate
		END
	END
END

--Visit 
if (isnull(@intAnnualVisit,0) + isnull(@intMonthVisit,0) + isnull(@intDayVisit,0)) > 0
BEGIN
	if isnull(@intAnnualVisit,0) > 0
	BEGIN
		SET @strVisitRemark = 'Total Annual GP Visit'
		SET @intVisit = @intAnnualVisit
		set @dtStartDate = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()) + 1, 0)
	END
	Else if isnull(@intMonthVisit,0) > 0
	BEGIN
		SET @strVisitRemark = 'Total Monthly GP Visit'
		SET @intVisit = @intMonthVisit
		set @dtStartDate = DATEADD(MM, DATEDIFF(MM, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(MM, DATEDIFF(MM, 0, GETDATE()) + 1, 0)
	END
	Else if isnull(@intDayVisit,0) > 0
	BEGIN
		SET @strVisitRemark = 'Total Daily GP Visit'
		SET @intVisit = @intDayVisit
		set @dtStartDate = DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0)
		set @dtEndDate = DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 1)
	END
	
	if @strEmpDepCov in ('E','F')
	BEGIN
		select @dblTotalVisit = count(1)
		From tblClaim with (nolock) 
		where emp_id = @EmpId
		and tblClaim.ConsultDate >= @dtStartDate
		and tblClaim.ConsultDate < @dtEndDate
	END
	else if @strEmpDepCov = 'EF'
	BEGIN
		if @DepId is null
		BEGIN
			select @dblTotalVisit = count(1)
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate
		END
		else
		BEGIN
			select @dblTotalVisit = count(1)
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is not null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate
		END
	END
	else if @strEmpDepCov = 'D'
	BEGIN
		if @DepId is null
		BEGIN
			select @dblTotalVisit = count(1)
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id is null
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate
		END
		else
		BEGIN
			select @dblTotalVisit = count(1)
			From tblClaim with (nolock) 
			where emp_id = @EmpId and dep_id = @DepId
			and tblClaim.ConsultDate >= @dtStartDate
			and tblClaim.ConsultDate < @dtEndDate
		END
	END
END
	

	SELECT @dblTotalUsedAmt = isnull(@dblClaimAmt,0) + isnull(@dblClaimReimAmt,0)

	if isnull(@dblAnnualLimit,0) > 0
	BEGIN
		SELECT 'GP Annual Limit', @dblAnnualLimit, @dblTotalUsedAmt, @dblAnnualLimit - @dblTotalUsedAmt , 'GP'
		Union
		SELECT @strVisitRemark, @intVisit,  @dblTotalVisit, @intVisit -  @dblTotalVisit, 'GPVisit'
	END
	Else if isnull(@dblMonthLimit,0) > 0
	BEGIN
		SELECT 'GP Monthly Limit', @dblMonthLimit, @dblTotalUsedAmt, @dblMonthLimit - @dblTotalUsedAmt , 'GP'
		Union
		SELECT @strVisitRemark, @intVisit,  @dblTotalVisit, @intVisit -  @dblTotalVisit, 'GPVisit'
	END
	Else if isnull(@dblDayLimit,0) > 0
	BEGIN
		SELECT 'GP Daily Limit', @dblDayLimit, @dblTotalUsedAmt, @dblDayLimit - @dblTotalUsedAmt , 'GP'
		Union
		SELECT @strVisitRemark, @intVisit,  @dblTotalVisit, @intVisit -  @dblTotalVisit, 'GPVisit'
	END
		
END

GO
/****** Object:  StoredProcedure [dbo].[HR_GetMemberClaimHistory]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[HR_GetMemberClaimHistory]
	@EmpID int,
	@DepID int
AS
BEGIN
	SET NOCOUNT ON;
	
	select isnull(tblDependents.dep_name,tblEmployees.emp_name),
			convert(varchar,tblClaim.CreatedDate,106),
			convert(varchar,tblClaim.consultdate,106),
			'Cashless',
			tblClaim.company_pay,
			tblClaim.claim_status
	from tblClaim with (nolock)
		inner join tblEmployees with (nolock) on tblClaim.emp_id = tblEmployees.emp_id
		left outer join tblDependents with (nolock) on tblClaim.dep_id = tblDependents.dep_id
	where tblClaim.emp_id = @EmpID
	union
	select isnull(tblDependents.dep_name,tblEmployees.emp_name),
			convert(varchar,tblClaimReim.CreatedDate,106),
			convert(varchar,tblClaimReim.ConsultDate,106),
			'Reimbursement',
			tblClaimReim.company_pay,
			tblClaimReim.Status
	from tblClaimReim with (nolock)
		inner join tblEmployees with (nolock) on tblClaimReim.emp_id = tblEmployees.emp_id
		left outer join tblDependents with (nolock) on tblClaimReim.dep_id = tblDependents.dep_id
	where tblClaimReim.emp_id = @EmpID
		
END

GO
/****** Object:  StoredProcedure [dbo].[HR_GetMemberInfo]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[HR_GetMemberInfo]
	@EmpId int,
	@DepId int
AS
BEGIN
	SET NOCOUNT ON;
	
	if @DepId is null
	BEGIN
		select emp_id, emp_name, emp_ic, suboffice_fk, dept_fk, BenefitID, emp_gender, convert(varchar,emp_dob,106), emp_race, emp_nationality, addr1, addr2, addr3, postcode, city, state, country, email, 
			ClientNumber,'E' as Relationship, tblEmployees.email, cont_no, designation, remarks, join_dt, ent_dt, dbo.fn_GetBankName(BankID), BankAccNo, resign_dt, ClientNumber, CostCentre, isActive, 
			NULL as dep_id, NULL as dep_name, NULL as dep_ic, NULL as dep_gender, NULL as dep_dob, NULL as dep_race, NULL as dep_join_dt, NULL as dep_ent_dt, 
			NULL as DepRemarks, NULL as DepIsActive
		From tblEmployees with (nolock)
		where emp_id = @EmpId
	END
	ELSE
	BEGIN
		select tblEmployees.emp_id, tblEmployees.emp_name, tblEmployees.emp_ic, suboffice_fk, dept_fk, isnull(tblDependents.benefitID,tblEmployees.BenefitID), emp_gender, convert(varchar,emp_dob,106), emp_race, emp_nationality, addr1, addr2, addr3, postcode, city, state, country, email, 
			tblEmployees.ClientNumber,tblDependents.relationship, tblEmployees.email, cont_no, designation, tblEmployees.remarks, tblEmployees.join_dt, tblEmployees.ent_dt, dbo.fn_GetBankName(BankID), BankAccNo, resign_dt, tblEmployees.ClientNumber, CostCentre, tblEmployees.isActive, 
			tblDependents.dep_id, tblDependents.dep_name, tblDependents.dep_ic,  tblDependents.dep_gender,tblDependents.dep_dob, tblDependents.dep_race, tblDependents.join_dt, tblDependents.ent_dt, 
			tblDependents.Remarks, tblDependents.IsActive
		from tblDependents with (nolock)
			inner join tblEmployees with (nolock) on tblEmployees.emp_id = tblDependents.emp_id
		where tblDependents.emp_id = @EmpId and tblDependents.dep_id = @DepId
	END
		
END

GO
/****** Object:  StoredProcedure [dbo].[HR_GetRawData]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[HR_GetRawData]
	@CorpID int,
	@StartDate datetime,
	@EndDate datetime
AS
BEGIN
	
	SET NOCOUNT ON;
	

END

GO
/****** Object:  StoredProcedure [dbo].[HR_SearchMember]    Script Date: 11/2/2024 12:56:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[HR_SearchMember]
	@CorpID int,
	@strIC varchar(20),
	@strName varchar(60)
AS
BEGIN
	CREATE TABLE #tblEmp
	(
		emp_id int,
		resign_dt datetime,
	)

	CREATE TABLE #tblDep
	(
		emp_id int,
		dep_id int,
		DepResignDT datetime,

	)

	CREATE TABLE #tblMemberTemp
	(
		emp_id int,
		emp_name varchar(200),
		emp_ic varchar(30),
		resign_dt datetime,
		ent_dt datetime,
		annual_cap decimal(18, 2),
		month_cap decimal(18, 2),
		day_cap decimal(18, 2),
		annual_visit int,
		month_visit int,
		day_visit int,
		copay_type varchar(1),
		copay_value decimal(18, 2),
		max_mcdays int,
		DisplayMsg varchar(1000),
		corp_id varchar(100),
		corp_name varchar(4000),
		corpgroupID int,
		Relationship varchar(10),
		BenefitID varchar(30),
		dep_id int,
		dep_name varchar(200),
		dep_ic varchar(30),
		dep_resign_dt datetime,
		dep_ent_dt datetime,
		BalanceAmt decimal(18,2),
		BalanceMCDay decimal(18,1)
	)

	CREATE TABLE #tblMemberBenefit                   
	(                                  
		BenDesc varchar(500),                    
		Limit decimal(18, 2),        
		AmountUsed decimal(18, 2),                    
		Balance decimal(18, 2),   
		BenType varchar(10)             
	) 

	DECLARE @intEmpID int
	DECLARE @intDepID int
	 
	SET @strIC = replace(isnull(@strIC,''),'-','')
	SET @strName = isnull(@strName,'')

	IF LEN(@strIC) > 0
	BEGIN
		insert into #tblEmp
			select emp_id, resign_dt from tblEmployees with (nolock) where CorpID = @CorpID and emp_ic = @strIC
		
		insert into #tblDep
			select tblDependents.dep_id, tblDependents.emp_id, tblDependents.DepResignDT 
			from tblDependents with (nolock) 
				inner join tblEmployees with (nolock) on tblEmployees.emp_id = tblDependents.emp_id
			where tblEmployees.CorpID = @CorpID and tblDependents.dep_ic = @strIC 
	END
	ELSE IF LEN(@strName) > 0
	BEGIN
		insert into #tblEmp
			select emp_id, resign_dt from tblEmployees with (nolock) where CorpID = @CorpID and emp_name like '%' + @strName + '%'
		
		insert into #tblDep
			select tblDependents.dep_id, tblDependents.emp_id, tblDependents.DepResignDT 
			from tblDependents with (nolock) 
				inner join tblEmployees with (nolock) on tblEmployees.emp_id = tblDependents.emp_id
			where tblEmployees.CorpID = @CorpID and dep_name like '%' + @strName + '%'
	END
	

	if exists (select 1 from #tblEmp)
	BEGIN
		INSERT INTO #tblMemberTemp
			SELECT tblEmployees.emp_id, tblEmployees.emp_name, tblEmployees.emp_ic, tblEmployees.resign_dt, tblEmployees.ent_dt, 
					tblBenefits.annual_cap, tblBenefits.month_cap, tblBenefits.day_cap, 
					tblBenefits.annual_visit, tblBenefits.month_visit, tblBenefits.day_visit,
					tblBenefits.copay_type, tblBenefits.copay_value, tblBenefits.max_mcdays,
					'',tblEmployees.CorpID, tblCorp.Corp_name, tblCorp.CorpGroupID, 'Employee', tblEmployees.BenefitID,
					NULL,NULL,NULL,NULL,NULL,0,0
			FROM tblEmployees with (nolock)
				inner join tblBenefits with (nolock) on tblEmployees.CorpID = tblBenefits.CorpID and tblEmployees.BenefitID = tblBenefits.BenefitID
				inner join tblCorp with (nolock) on tblEmployees.CorpID = tblCorp.CorpID
				inner join #tblEmp with (nolock) on tblEmployees.emp_id = #tblEmp.emp_id
	END
	
	if exists (select 1 from #tblDep)
	BEGIN
		INSERT INTO #tblMemberTemp
			SELECT tblEmployees.emp_id, tblEmployees.emp_name, tblEmployees.emp_ic, tblEmployees.resign_dt, tblEmployees.ent_dt, 
					tblBenefits.annual_cap, tblBenefits.month_cap, tblBenefits.day_cap, 
					tblBenefits.annual_visit, tblBenefits.month_visit, tblBenefits.day_visit,
					tblBenefits.copay_type, tblBenefits.copay_value, tblBenefits.max_mcdays,
					'',tblEmployees.CorpID, tblCorp.Corp_name, tblCorp.CorpGroupID, case when tblDependents.relationship = 'S' then 'Spouse' when tblDependents.relationship = 'C' then 'Child' else '' end  ,isnull(tblDependents.benefitID,tblEmployees.BenefitID),
					tblDependents.dep_id, tblDependents.dep_name, tblDependents.dep_ic, tblDependents.DepResignDT, tblDependents.ent_dt,0,0
			FROM tblDependents with (nolock)
				inner join tblEmployees with (nolock) on tblEmployees.emp_id = tblDependents.emp_id 
				inner join tblBenefits with (nolock) on tblEmployees.CorpID = tblBenefits.CorpID and tblBenefits.BenefitID = isnull(tblDependents.benefitID,tblEmployees.BenefitID)
				inner join tblCorp with (nolock) on tblEmployees.CorpID = tblCorp.CorpID
				inner join #tblDep with (nolock) on tblDependents.dep_id = #tblDep.dep_id and tblDependents.emp_id = #tblDep.emp_id
	END		

	
	DECLARE @f_fetch numeric(12,0)
	DECLARE my_cursor CURSOR FOR   
			 select emp_id, dep_id  from #tblMemberTemp

	OPEN my_cursor      
  
	SELECT @f_fetch = 0                       
	WHILE (@f_fetch  <> -1)       
	BEGIN      
		FETCH NEXT FROM my_cursor INTO @intEmpID, @intDepID  
  
		SELECT @f_fetch = @@FETCH_STATUS      
  
		IF (@f_fetch <> -1)       
		BEGIN   
			INSERT INTO #tblMemberBenefit  
					EXECUTE APP_GetMemberBenefit @intEmpID, @intDepID

			if @intDepID is null
			BEGIN
				update #tblMemberTemp 
				set BalanceAmt = (select Balance from #tblMemberBenefit where BenType = 'GP')
				where emp_id = @intEmpID and dep_id is null
			END
			ELSE
			BEGIN
				update #tblMemberTemp 
				set BalanceAmt = (select Balance from #tblMemberBenefit where BenType = 'GP')
				where emp_id = @intEmpID and dep_id = @intDepID
			END
		END
	END
	DEALLOCATE my_cursor  
	 
	
	select * from #tblMemberTemp

	DROP TABLE #tblEmp
	DROP TABLE #tblDep
	DROP TABLE #tblMemberTemp

END

GO
USE [master]
GO
ALTER DATABASE [MM] SET  READ_WRITE 
GO
