USE [master]
GO
/****** Object:  Database [TaxiAppzDB]    Script Date: 09-08-2020 00:24:37 ******/
CREATE DATABASE [TaxiAppzDB]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaxiAppzDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaxiAppzDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TaxiAppzDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaxiAppzDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaxiAppzDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TaxiAppzDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [TaxiAppzDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaxiAppzDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TaxiAppzDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaxiAppzDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TaxiAppzDB] SET  MULTI_USER 
GO
ALTER DATABASE [TaxiAppzDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaxiAppzDB] SET DB_CHAINING OFF 
GO
USE [TaxiAppzDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAdminDetails]    Script Date: 09-08-2020 00:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAdminDetails]
as 
begin
 select firstname,lastname,password,role from tab_admin
 end


GO
/****** Object:  Table [dbo].[tab_admin]    Script Date: 09-08-2020 00:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_admin](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[admin_key] [nvarchar](200) NULL,
	[admin_reference] [int] NULL,
	[area_name] [bigint] NULL,
	[language] [int] NULL,
	[firstname] [nvarchar](200) NULL,
	[lastname] [nvarchar](200) NULL,
	[registration_code] [nvarchar](255) NULL,
	[email] [nvarchar](191) NULL,
	[password] [nvarchar](50) NULL,
	[phone_number] [nvarchar](20) NULL,
	[emergency_number] [nvarchar](20) NULL,
	[remember_token] [nvarchar](2000) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
	[is_active] [int] NULL,
	[role] [bigint] NULL,
	[profile_pic] [nvarchar](100) NULL,
	[zone_access] [bigint] NULL,
	[created_by] [varchar](200) NULL,
	[updated_by] [varchar](200) NULL,
	[IsDeleted] [int] NULL,
	[deleted_by] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_admin_details]    Script Date: 09-08-2020 00:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_admin_details](
	[admindtlsid] [bigint] IDENTITY(1,1) NOT NULL,
	[admin_id] [bigint] NULL,
	[address] [nvarchar](300) NULL,
	[city] [nvarchar](200) NULL,
	[Country_id] [bigint] NULL,
	[postalCode] [bigint] NULL,
	[timezone] [nvarchar](200) NULL,
	[document_name] [nvarchar](100) NULL,
	[document] [nvarchar](200) NULL,
	[driver_document_count] [int] NULL,
	[last_login_ip_address] [nvarchar](100) NULL,
	[block] [int] NULL,
	[login_attempt] [bigint] NULL,
	[isActive] [int] NULL,
	[created_by] [varchar](100) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
	[updated_by] [varchar](200) NULL,
	[IsDeleted] [int] NULL,
	[deleted_by] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[admindtlsid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_common_currency]    Script Date: 09-08-2020 00:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_common_currency](
	[currencyid] [bigint] IDENTITY(1,1) NOT NULL,
	[currencyname] [nvarchar](200) NOT NULL,
	[currency_symbol] [varchar](100) NOT NULL,
	[currenciesid] [bigint] NULL,
	[isActive] [int] NULL,
	[isDeleted] [int] NULL,
	[Created_by] [nvarchar](100) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [nvarchar](100) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [nvarchar](100) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[currencyid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_Common_Languages]    Script Date: 09-08-2020 00:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_Common_Languages](
	[Languageid] [int] IDENTITY(1,1) NOT NULL,
	[Short_Lang] [nvarchar](50) NULL,
	[Name] [nvarchar](30) NULL,
	[Created_By] [nvarchar](100) NULL,
	[Created_At] [datetime] NULL,
	[Updated_At] [datetime] NULL,
	[Deleted_At] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Languageid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tab_countries]    Script Date: 09-08-2020 00:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_countries](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[full_name] [nvarchar](255) NULL,
	[capital] [nvarchar](255) NULL,
	[citizenship] [nvarchar](255) NULL,
	[currency] [nvarchar](255) NULL,
	[currency_code] [nvarchar](255) NULL,
	[currency_sub_unit] [nvarchar](255) NULL,
	[currency_symbol] [nvarchar](3) NULL,
	[country_code] [nvarchar](3) NOT NULL,
	[region_code] [nvarchar](3) NOT NULL,
	[sub_region_code] [nvarchar](3) NOT NULL,
	[eea] [int] NOT NULL,
	[calling_code] [nvarchar](3) NULL,
	[iso_3166_2] [nvarchar](2) NOT NULL,
	[iso_3166_3] [nvarchar](3) NOT NULL,
	[currency_decimals] [decimal](18, 0) NOT NULL,
	[flag] [nvarchar](191) NULL,
	[active] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tab_Country]    Script Date: 09-08-2020 00:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_Country](
	[CountryId] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](20) NULL,
	[Name] [nvarchar](200) NULL,
	[Currency] [varchar](100) NULL,
	[d_code] [varchar](20) NULL,
	[Created_By] [nvarchar](100) NULL,
	[Created_At] [datetime] NULL,
	[Updated_At] [datetime] NULL,
	[Deleted_At] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_currencies]    Script Date: 09-08-2020 00:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_currencies](
	[currenciesid] [bigint] IDENTITY(1,1) NOT NULL,
	[countryid] [bigint] NULL,
	[currency] [varchar](100) NULL,
	[code] [varchar](25) NULL,
	[symbol] [varchar](25) NULL,
	[thousand_separator] [varchar](10) NULL,
	[decimal_separator] [varchar](10) NULL,
	[IsActive] [int] NULL,
	[isDelete] [int] NULL,
	[created_By] [nvarchar](200) NULL,
	[Created_at] [datetime] NULL,
	[updated_by] [nvarchar](200) NULL,
	[updated_at] [datetime] NULL,
	[deleted_by] [nvarchar](200) NULL,
	[deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[currenciesid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_driver_bonus]    Script Date: 09-08-2020 00:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_driver_bonus](
	[driverbonusid] [bigint] IDENTITY(1,1) NOT NULL,
	[Driverid] [bigint] NULL,
	[bonusamount] [float] NULL,
	[bonus_reason] [nvarchar](600) NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[createdby] [varchar](300) NULL,
	[createdat] [datetime] NULL,
	[updatedby] [varchar](300) NULL,
	[updatedat] [datetime] NULL,
	[deletedby] [varchar](300) NULL,
	[deletedat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[driverbonusid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_driver_cancellation]    Script Date: 09-08-2020 00:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_driver_cancellation](
	[Driver_CancelId] [bigint] IDENTITY(1,1) NOT NULL,
	[zonetypeid] [bigint] NULL,
	[paymentstatus] [varchar](50) NULL,
	[arrivalstatus] [varchar](100) NULL,
	[Cancellation_Reason_English] [nvarchar](400) NULL,
	[Cancellation_Reason_Arabic] [nvarchar](400) NULL,
	[Cancellation_Reason_Spanish] [nvarchar](400) NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[Created_by] [varchar](200) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [varchar](200) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [varchar](200) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Driver_CancelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_Driver_Complaint]    Script Date: 09-08-2020 00:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_Driver_Complaint](
	[Driver_ComplaintID] [bigint] IDENTITY(1,1) NOT NULL,
	[zoneid] [bigint] NULL,
	[DriverComplaint_type] [nvarchar](100) NULL,
	[DriverComplaint_title] [nvarchar](400) NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[Created_by] [varchar](200) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [varchar](200) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [varchar](200) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Driver_ComplaintID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_Driver_Documents]    Script Date: 09-08-2020 00:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_Driver_Documents](
	[DriverDoc_id] [bigint] IDENTITY(1,1) NOT NULL,
	[Driverid] [bigint] NULL,
	[Documentid] [bigint] NULL,
	[ExpireDate] [datetime] NULL,
	[Uploaded_FileName] [varchar](300) NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[Created_by] [varchar](200) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [varchar](200) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [varchar](200) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DriverDoc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_driver_fine]    Script Date: 09-08-2020 00:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_driver_fine](
	[driverfineid] [bigint] IDENTITY(1,1) NOT NULL,
	[Driverid] [bigint] NULL,
	[fineamount] [float] NULL,
	[fine_reason] [nvarchar](600) NULL,
	[finepaid_status] [bit] NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[createdby] [varchar](300) NULL,
	[createdat] [datetime] NULL,
	[updatedby] [varchar](300) NULL,
	[updatedat] [datetime] NULL,
	[deletedby] [varchar](300) NULL,
	[deletedat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[driverfineid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_driver_wallet]    Script Date: 09-08-2020 00:24:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_driver_wallet](
	[driverwalletid] [bigint] IDENTITY(1,1) NOT NULL,
	[Driverid] [bigint] NULL,
	[Transactionid] [bigint] NULL,
	[currencyid] [bigint] NULL,
	[walletamount] [float] NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[createdby] [varchar](300) NULL,
	[createdat] [datetime] NULL,
	[updatedby] [varchar](300) NULL,
	[updatedat] [datetime] NULL,
	[deletedby] [varchar](300) NULL,
	[deletedat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[driverwalletid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_Drivers]    Script Date: 09-08-2020 00:24:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_Drivers](
	[Driverid] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](300) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[ContactNo] [nvarchar](15) NULL,
	[Gender] [varchar](10) NULL,
	[Driverregno] [nvarchar](500) NULL,
	[Address] [nvarchar](1000) NULL,
	[City] [varchar](200) NULL,
	[State] [varchar](200) NULL,
	[countryid] [bigint] NULL,
	[NationalID] [varchar](100) NULL,
	[servicelocid] [bigint] NULL,
	[company] [varchar](100) NULL,
	[password] [varchar](50) NULL,
	[typeid] [bigint] NULL,
	[carmodel] [varchar](100) NULL,
	[carcolor] [varchar](50) NULL,
	[carnumber] [varchar](20) NULL,
	[carmanufacturer] [varchar](100) NULL,
	[caryear] [int] NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[created_by] [varchar](200) NULL,
	[created_at] [datetime] NULL,
	[updated_by] [varchar](200) NULL,
	[updated_at] [datetime] NULL,
	[deleted_by] [varchar](200) NULL,
	[deleted_at] [datetime] NULL,
	[Reward_point] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Driverid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_Manage_Email]    Script Date: 09-08-2020 00:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_Manage_Email](
	[ManageEmailid] [bigint] IDENTITY(1,1) NOT NULL,
	[Emailtitle] [varchar](200) NOT NULL,
	[Description] [nvarchar](600) NULL,
	[isActive] [bit] NULL,
	[Created_by] [varchar](300) NULL,
	[Created_at] [datetime] NULL,
	[Updated_By] [varchar](300) NULL,
	[Updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ManageEmailid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_manage_Email_Hints]    Script Date: 09-08-2020 00:24:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_manage_Email_Hints](
	[ManageEmailHint] [bigint] IDENTITY(1,1) NOT NULL,
	[ManageEmailid] [bigint] NULL,
	[Hint_Keyword] [varchar](200) NULL,
	[Hint_Description] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[ManageEmailHint] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_Manage_Referral]    Script Date: 09-08-2020 00:24:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_Manage_Referral](
	[Managereferral] [bigint] IDENTITY(1,1) NOT NULL,
	[ReferralWorth_Amount] [decimal](8, 2) NULL,
	[ReferralGain_Amount_PerPerson] [decimal](8, 2) NULL,
	[Trip_to_completed_torefer] [int] NULL,
	[Trip_to_completed_toearn_refferalAmount] [decimal](8, 2) NULL,
	[Created_by] [varchar](200) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [varchar](200) NULL,
	[Updated_at] [datetime] NULL,
	[isActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Managereferral] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_Manage_SMS]    Script Date: 09-08-2020 00:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_Manage_SMS](
	[ManageSMSid] [bigint] IDENTITY(1,1) NOT NULL,
	[SMStitle] [varchar](200) NOT NULL,
	[Description] [nvarchar](600) NULL,
	[isActive] [bit] NULL,
	[Created_by] [varchar](300) NULL,
	[Created_at] [datetime] NULL,
	[Updated_By] [varchar](300) NULL,
	[Updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ManageSMSid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_manage_SMS_Hints]    Script Date: 09-08-2020 00:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_manage_SMS_Hints](
	[ManageSMSHint] [bigint] IDENTITY(1,1) NOT NULL,
	[ManageSMSid] [bigint] NULL,
	[Hint_Keyword] [varchar](200) NULL,
	[Hint_Description] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[ManageSMSHint] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_ManageDocument]    Script Date: 09-08-2020 00:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_ManageDocument](
	[DocumentID] [bigint] IDENTITY(1,1) NOT NULL,
	[Document_Name] [varchar](100) NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[Created_by] [varchar](200) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [varchar](200) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [varchar](200) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_menu]    Script Date: 09-08-2020 00:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_menu](
	[Menuid] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[parentID] [bigint] NULL,
	[IsActive] [bit] NULL,
	[menukey] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Menuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tab_MenuAccess]    Script Date: 09-08-2020 00:24:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_MenuAccess](
	[Accessid] [bigint] IDENTITY(1,1) NOT NULL,
	[Menuid] [bigint] NULL,
	[Roleid] [bigint] NULL,
	[viewstatus] [bit] NULL,
	[createdby] [datetime] NULL,
	[updatedby] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Accessid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tab_menucode]    Script Date: 09-08-2020 00:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_menucode](
	[menuid] [bigint] IDENTITY(1,1) NOT NULL,
	[menuname] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[menuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_OTP_users]    Script Date: 09-08-2020 00:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_OTP_users](
	[Userotpid] [bigint] IDENTITY(1,1) NOT NULL,
	[User_Contact_no] [bigint] NOT NULL,
	[User_OTP] [int] NOT NULL,
	[User_OTP_CreatedDate] [datetime] NULL,
	[User_OTP_ExpireDate] [datetime] NULL,
	[User_Device_name] [varchar](200) NULL,
	[User_Device_IPAddress] [varchar](200) NULL,
	[isActive] [bit] NULL,
	[Created_by] [varchar](200) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [varchar](200) NULL,
	[Updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Userotpid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_promo]    Script Date: 09-08-2020 00:24:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_promo](
	[promoid] [bigint] IDENTITY(1,1) NOT NULL,
	[Coupon_code] [nvarchar](300) NOT NULL,
	[promo_estimate_amount] [float] NULL,
	[promo_value] [bigint] NULL,
	[zoneid] [bigint] NULL,
	[promo_type] [varchar](100) NULL,
	[promo_uses] [bigint] NULL,
	[promo_users_repeateduse] [bigint] NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[created_by] [varchar](300) NULL,
	[created_at] [datetime] NULL,
	[updated_by] [varchar](300) NULL,
	[updated_at] [datetime] NULL,
	[deleted_by] [varchar](300) NULL,
	[deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[promoid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_push_notification]    Script Date: 09-08-2020 00:24:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_push_notification](
	[pushnotificationid] [bigint] IDENTITY(1,1) NOT NULL,
	[messagetitle] [nvarchar](200) NOT NULL,
	[messagesubtitle] [nvarchar](200) NOT NULL,
	[HasRedirectURL] [bit] NULL,
	[MessageDescription] [nvarchar](600) NULL,
	[Upload_FileName] [varchar](300) NULL,
	[isDeleted] [bit] NULL,
	[Created_by] [varchar](300) NULL,
	[Created_at] [datetime] NULL,
	[Deleted_By] [varchar](300) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[pushnotificationid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_refreshtoken]    Script Date: 09-08-2020 00:24:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_refreshtoken](
	[reftokenid] [bigint] IDENTITY(1,1) NOT NULL,
	[userid] [bigint] NULL,
	[refreshtoken] [nvarchar](500) NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[reftokenid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tab_roles]    Script Date: 09-08-2020 00:24:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_roles](
	[Roleid] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](30) NULL,
	[Display_Name] [nvarchar](30) NULL,
	[Description] [nvarchar](200) NULL,
	[ALL_Rights] [int] NULL,
	[Locked] [int] NULL,
	[Created_By] [nvarchar](100) NULL,
	[Created_At] [datetime] NULL,
	[Updated_At] [datetime] NULL,
	[IsActive] [int] NULL,
	[updated_by] [varchar](150) NULL,
	[Deleted_at] [datetime] NULL,
	[deleted_by] [varchar](150) NULL,
	[isDelete] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Roleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_servicelocation]    Script Date: 09-08-2020 00:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_servicelocation](
	[servicelocid] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NULL,
	[countryid] [bigint] NULL,
	[currencyid] [bigint] NULL,
	[timezoneid] [bigint] NULL,
	[isActive] [int] NULL,
	[isDeleted] [int] NULL,
	[Created_by] [nvarchar](100) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [nvarchar](100) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [nvarchar](100) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[servicelocid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tab_setprice_zonetype]    Script Date: 09-08-2020 00:24:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_setprice_zonetype](
	[setpriceid] [bigint] IDENTITY(1,1) NOT NULL,
	[zonetypeid] [bigint] NULL,
	[Baseprice] [decimal](8, 2) NULL,
	[pricepertime] [decimal](8, 2) NULL,
	[basedistance] [bigint] NOT NULL,
	[priceperdistance] [decimal](8, 2) NULL,
	[freewaitingtime] [bigint] NOT NULL,
	[waitingcharges] [decimal](8, 2) NULL,
	[cancellationfee] [decimal](8, 2) NULL,
	[dropfee] [decimal](8, 2) NULL,
	[admincommtype] [nvarchar](100) NULL,
	[admincommission] [decimal](8, 2) NULL,
	[Driversavingper] [decimal](8, 2) NULL,
	[customseldrifee] [decimal](8, 2) NULL,
	[RideType] [varchar](50) NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[Created_by] [varchar](200) NULL,
	[created_at] [datetime] NULL,
	[updated_by] [varchar](200) NULL,
	[updated_at] [datetime] NULL,
	[deleted_by] [varchar](200) NULL,
	[deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[setpriceid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_SOS]    Script Date: 09-08-2020 00:24:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_SOS](
	[SOSid] [bigint] IDENTITY(1,1) NOT NULL,
	[SOSName] [nvarchar](100) NOT NULL,
	[contact_number] [nvarchar](20) NOT NULL,
	[isActive] [int] NULL,
	[isDeleted] [int] NULL,
	[Created_by] [nvarchar](100) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [nvarchar](100) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [nvarchar](100) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SOSid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tab_timezone]    Script Date: 09-08-2020 00:24:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_timezone](
	[timezoneid] [bigint] IDENTITY(1,1) NOT NULL,
	[countryid] [bigint] NULL,
	[zonedescription] [nvarchar](200) NULL,
	[IsActive] [int] NULL,
	[isDelete] [int] NULL,
	[created_By] [nvarchar](200) NULL,
	[Created_at] [datetime] NULL,
	[updated_by] [nvarchar](200) NULL,
	[updated_at] [datetime] NULL,
	[deleted_by] [nvarchar](200) NULL,
	[deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[timezoneid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tab_types]    Script Date: 09-08-2020 00:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_types](
	[typeid] [bigint] IDENTITY(1,1) NOT NULL,
	[typename] [nvarchar](100) NOT NULL,
	[imagename] [nvarchar](150) NOT NULL,
	[isActive] [int] NULL,
	[isDeleted] [int] NULL,
	[Created_by] [nvarchar](100) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [nvarchar](100) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [nvarchar](100) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[typeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tab_uploadfiledetails]    Script Date: 09-08-2020 00:25:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_uploadfiledetails](
	[fileid] [bigint] IDENTITY(1,1) NOT NULL,
	[filename] [varchar](300) NOT NULL,
	[mimetype] [varchar](100) NOT NULL,
	[size] [bigint] NULL,
	[extention] [varchar](200) NOT NULL,
	[Created_By] [nvarchar](200) NULL,
	[Created_at] [datetime] NULL,
	[Updated_By] [nvarchar](200) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_By] [nvarchar](200) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[fileid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_user]    Script Date: 09-08-2020 00:25:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_user](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[firstname] [nvarchar](250) NULL,
	[lastname] [varchar](191) NULL,
	[email] [varchar](191) NULL,
	[phone_number] [varchar](191) NULL,
	[password] [varchar](191) NULL,
	[gender] [varchar](10) NULL,
	[address] [nvarchar](500) NULL,
	[city] [varchar](150) NULL,
	[state] [varchar](150) NULL,
	[countryid] [bigint] NULL,
	[timezoneid] [bigint] NULL,
	[currencyid] [bigint] NULL,
	[profile_pic] [varchar](191) NULL,
	[token] [varchar](191) NULL,
	[token_expiry] [datetime] NULL,
	[device_token] [varchar](191) NULL,
	[login_by] [varchar](191) NULL,
	[login_method] [varchar](191) NULL,
	[is_ios_production] [int] NULL,
	[social_unique_id] [varchar](191) NULL,
	[if_dispatch] [int] NULL,
	[corporate_admin_id] [int] NULL,
	[if_corporate_user] [int] NULL,
	[corporate_admin_reference] [int] NULL,
	[otp_verification_code] [varchar](191) NULL,
	[otp_verification_validation_time] [datetime] NULL,
	[cancellation_continuous_skip] [int] NULL,
	[cancellation_continuous_skip_notified] [int] NULL,
	[continuous_cancellation_block] [int] NULL,
	[IsActive] [int] NULL,
	[isDelete] [int] NULL,
	[created_By] [nvarchar](200) NULL,
	[Created_at] [datetime] NULL,
	[updated_by] [nvarchar](200) NULL,
	[updated_at] [datetime] NULL,
	[deleted_by] [nvarchar](200) NULL,
	[deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_User_cancellation]    Script Date: 09-08-2020 00:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_User_cancellation](
	[User_CancelId] [bigint] IDENTITY(1,1) NOT NULL,
	[zonetypeid] [bigint] NULL,
	[paymentstatus] [varchar](50) NULL,
	[arrivalstatus] [varchar](100) NULL,
	[Cancellation_Reason_English] [nvarchar](400) NULL,
	[Cancellation_Reason_Arabic] [nvarchar](400) NULL,
	[Cancellation_Reason_Spanish] [nvarchar](400) NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[Created_by] [varchar](200) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [varchar](200) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [varchar](200) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[User_CancelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_User_Complaint]    Script Date: 09-08-2020 00:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_User_Complaint](
	[User_ComplaintID] [bigint] IDENTITY(1,1) NOT NULL,
	[zoneid] [bigint] NULL,
	[UserComplaint_type] [nvarchar](100) NULL,
	[UserComplaint_title] [nvarchar](400) NULL,
	[isActive] [bit] NULL,
	[isDelete] [bit] NULL,
	[Created_by] [varchar](200) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [varchar](200) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [varchar](200) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[User_ComplaintID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_zone]    Script Date: 09-08-2020 00:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_zone](
	[zoneid] [bigint] IDENTITY(1,1) NOT NULL,
	[zonename] [nvarchar](200) NOT NULL,
	[servicelocid] [bigint] NULL,
	[unit] [varchar](50) NULL,
	[isActive] [int] NULL,
	[isDeleted] [int] NULL,
	[Created_by] [nvarchar](100) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [nvarchar](100) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [nvarchar](100) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[zoneid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_zonepolygon]    Script Date: 09-08-2020 00:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_zonepolygon](
	[zonepolygonid] [bigint] IDENTITY(1,1) NOT NULL,
	[zoneid] [bigint] NULL,
	[latitudes] [decimal](8, 6) NULL,
	[longitudes] [decimal](9, 6) NULL,
	[isActive] [int] NULL,
	[isDeleted] [int] NULL,
	[Created_by] [nvarchar](100) NULL,
	[Created_at] [datetime] NULL,
	[Updated_by] [nvarchar](100) NULL,
	[Updated_at] [datetime] NULL,
	[Deleted_by] [nvarchar](100) NULL,
	[Deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[zonepolygonid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tab_zonetype_relationship]    Script Date: 09-08-2020 00:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_zonetype_relationship](
	[zonetypeid] [bigint] IDENTITY(1,1) NOT NULL,
	[zoneid] [bigint] NULL,
	[typeid] [bigint] NULL,
	[paymentmode] [varchar](200) NOT NULL,
	[showbill] [bit] NULL,
	[isDefault] [int] NULL,
	[created_by] [varchar](100) NULL,
	[created_at] [datetime] NULL,
	[isActive] [int] NULL,
	[isDelete] [int] NULL,
	[updated_by] [varchar](100) NULL,
	[updated_at] [datetime] NULL,
	[deleted_by] [varchar](100) NULL,
	[deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[zonetypeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_errorlog]    Script Date: 09-08-2020 00:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_errorlog](
	[int] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[created_at] [datetime] NULL,
	[created_by] [nvarchar](100) NULL,
	[FunctionName] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[int] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tab_admin] ADD  CONSTRAINT [DF_tab_admin_Inserted]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tab_admin] ADD  DEFAULT ((0)) FOR [is_active]
GO
ALTER TABLE [dbo].[tab_admin] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tab_admin_details] ADD  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_admin_details] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tab_admin_details] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tab_common_currency] ADD  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_common_currency] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[tab_common_currency] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_Common_Languages] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT ('') FOR [name]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT (NULL) FOR [full_name]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT (NULL) FOR [capital]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT (NULL) FOR [citizenship]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT (NULL) FOR [currency]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT (NULL) FOR [currency_code]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT (NULL) FOR [currency_sub_unit]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT (NULL) FOR [currency_symbol]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT ('') FOR [country_code]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT ('') FOR [region_code]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT ('') FOR [sub_region_code]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT (NULL) FOR [calling_code]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT ('') FOR [iso_3166_2]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT ('') FOR [iso_3166_3]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT ('0') FOR [currency_decimals]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT (NULL) FOR [flag]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT ('1') FOR [active]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tab_countries] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[tab_Country] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[tab_currencies] ADD  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tab_currencies] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_currencies] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_driver_bonus] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_driver_bonus] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_driver_bonus] ADD  DEFAULT (getdate()) FOR [createdat]
GO
ALTER TABLE [dbo].[tab_driver_cancellation] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_driver_cancellation] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_driver_cancellation] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_Driver_Complaint] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_Driver_Complaint] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_Driver_Complaint] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_Driver_Documents] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_Driver_Documents] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_Driver_Documents] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_driver_fine] ADD  DEFAULT ((0)) FOR [finepaid_status]
GO
ALTER TABLE [dbo].[tab_driver_fine] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_driver_fine] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_driver_fine] ADD  DEFAULT (getdate()) FOR [createdat]
GO
ALTER TABLE [dbo].[tab_driver_wallet] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_driver_wallet] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_driver_wallet] ADD  DEFAULT (getdate()) FOR [createdat]
GO
ALTER TABLE [dbo].[tab_Drivers] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_Drivers] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_Drivers] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tab_Manage_Email] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_Manage_Email] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_Manage_Referral] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_Manage_Referral] ADD  CONSTRAINT [tab_Manage_Ref_Isactive]  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_Manage_SMS] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_Manage_SMS] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_ManageDocument] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_ManageDocument] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_ManageDocument] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_MenuAccess] ADD  DEFAULT ((0)) FOR [viewstatus]
GO
ALTER TABLE [dbo].[tab_MenuAccess] ADD  DEFAULT (getdate()) FOR [createdby]
GO
ALTER TABLE [dbo].[tab_OTP_users] ADD  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_OTP_users] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_promo] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_promo] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_promo] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tab_push_notification] ADD  DEFAULT ((0)) FOR [HasRedirectURL]
GO
ALTER TABLE [dbo].[tab_push_notification] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[tab_push_notification] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_roles] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[tab_roles] ADD  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tab_roles] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_servicelocation] ADD  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_servicelocation] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[tab_servicelocation] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_servicelocation] ADD  DEFAULT (getdate()) FOR [Updated_at]
GO
ALTER TABLE [dbo].[tab_servicelocation] ADD  DEFAULT (getdate()) FOR [Deleted_at]
GO
ALTER TABLE [dbo].[tab_setprice_zonetype] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_setprice_zonetype] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_setprice_zonetype] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tab_SOS] ADD  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_SOS] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[tab_SOS] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_timezone] ADD  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tab_timezone] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_timezone] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_types] ADD  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_types] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[tab_types] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_uploadfiledetails] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_user] ADD  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tab_user] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_user] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_User_cancellation] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_User_cancellation] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_User_cancellation] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_User_Complaint] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_User_Complaint] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tab_User_Complaint] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_zone] ADD  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_zone] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[tab_zone] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_zonepolygon] ADD  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_zonepolygon] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[tab_zonepolygon] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[tab_zonetype_relationship] ADD  DEFAULT ((0)) FOR [showbill]
GO
ALTER TABLE [dbo].[tab_zonetype_relationship] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tab_zonetype_relationship] ADD  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[tab_zonetype_relationship] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tbl_errorlog] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tab_admin]  WITH CHECK ADD FOREIGN KEY([area_name])
REFERENCES [dbo].[tab_servicelocation] ([servicelocid])
GO
ALTER TABLE [dbo].[tab_admin]  WITH CHECK ADD  CONSTRAINT [fk_tab_Country_id] FOREIGN KEY([zone_access])
REFERENCES [dbo].[tab_Country] ([CountryId])
GO
ALTER TABLE [dbo].[tab_admin] CHECK CONSTRAINT [fk_tab_Country_id]
GO
ALTER TABLE [dbo].[tab_admin]  WITH CHECK ADD  CONSTRAINT [fk_tab_language_id] FOREIGN KEY([language])
REFERENCES [dbo].[tab_Common_Languages] ([Languageid])
GO
ALTER TABLE [dbo].[tab_admin] CHECK CONSTRAINT [fk_tab_language_id]
GO
ALTER TABLE [dbo].[tab_admin]  WITH CHECK ADD  CONSTRAINT [fk_tab_role_id] FOREIGN KEY([role])
REFERENCES [dbo].[tab_roles] ([Roleid])
GO
ALTER TABLE [dbo].[tab_admin] CHECK CONSTRAINT [fk_tab_role_id]
GO
ALTER TABLE [dbo].[tab_admin]  WITH CHECK ADD  CONSTRAINT [fk_tab_timezone_id] FOREIGN KEY([zone_access])
REFERENCES [dbo].[tab_timezone] ([timezoneid])
GO
ALTER TABLE [dbo].[tab_admin] CHECK CONSTRAINT [fk_tab_timezone_id]
GO
ALTER TABLE [dbo].[tab_admin_details]  WITH CHECK ADD FOREIGN KEY([admin_id])
REFERENCES [dbo].[tab_admin] ([id])
GO
ALTER TABLE [dbo].[tab_admin_details]  WITH CHECK ADD FOREIGN KEY([Country_id])
REFERENCES [dbo].[tab_Country] ([CountryId])
GO
ALTER TABLE [dbo].[tab_common_currency]  WITH CHECK ADD FOREIGN KEY([currenciesid])
REFERENCES [dbo].[tab_currencies] ([currenciesid])
GO
ALTER TABLE [dbo].[tab_currencies]  WITH CHECK ADD FOREIGN KEY([countryid])
REFERENCES [dbo].[tab_Country] ([CountryId])
GO
ALTER TABLE [dbo].[tab_driver_bonus]  WITH CHECK ADD FOREIGN KEY([Driverid])
REFERENCES [dbo].[tab_Drivers] ([Driverid])
GO
ALTER TABLE [dbo].[tab_driver_cancellation]  WITH CHECK ADD FOREIGN KEY([zonetypeid])
REFERENCES [dbo].[tab_zonetype_relationship] ([zonetypeid])
GO
ALTER TABLE [dbo].[tab_Driver_Complaint]  WITH CHECK ADD FOREIGN KEY([zoneid])
REFERENCES [dbo].[tab_zone] ([zoneid])
GO
ALTER TABLE [dbo].[tab_Driver_Documents]  WITH CHECK ADD FOREIGN KEY([Documentid])
REFERENCES [dbo].[tab_ManageDocument] ([DocumentID])
GO
ALTER TABLE [dbo].[tab_Driver_Documents]  WITH CHECK ADD FOREIGN KEY([Driverid])
REFERENCES [dbo].[tab_Drivers] ([Driverid])
GO
ALTER TABLE [dbo].[tab_driver_fine]  WITH CHECK ADD FOREIGN KEY([Driverid])
REFERENCES [dbo].[tab_Drivers] ([Driverid])
GO
ALTER TABLE [dbo].[tab_driver_wallet]  WITH CHECK ADD FOREIGN KEY([currencyid])
REFERENCES [dbo].[tab_common_currency] ([currencyid])
GO
ALTER TABLE [dbo].[tab_driver_wallet]  WITH CHECK ADD FOREIGN KEY([Driverid])
REFERENCES [dbo].[tab_Drivers] ([Driverid])
GO
ALTER TABLE [dbo].[tab_Drivers]  WITH CHECK ADD FOREIGN KEY([countryid])
REFERENCES [dbo].[tab_Country] ([CountryId])
GO
ALTER TABLE [dbo].[tab_Drivers]  WITH CHECK ADD FOREIGN KEY([servicelocid])
REFERENCES [dbo].[tab_servicelocation] ([servicelocid])
GO
ALTER TABLE [dbo].[tab_Drivers]  WITH CHECK ADD FOREIGN KEY([typeid])
REFERENCES [dbo].[tab_types] ([typeid])
GO
ALTER TABLE [dbo].[tab_manage_Email_Hints]  WITH CHECK ADD FOREIGN KEY([ManageEmailid])
REFERENCES [dbo].[tab_Manage_Email] ([ManageEmailid])
GO
ALTER TABLE [dbo].[tab_manage_SMS_Hints]  WITH CHECK ADD FOREIGN KEY([ManageSMSid])
REFERENCES [dbo].[tab_Manage_SMS] ([ManageSMSid])
GO
ALTER TABLE [dbo].[tab_MenuAccess]  WITH CHECK ADD FOREIGN KEY([Menuid])
REFERENCES [dbo].[tab_menu] ([Menuid])
GO
ALTER TABLE [dbo].[tab_MenuAccess]  WITH CHECK ADD FOREIGN KEY([Roleid])
REFERENCES [dbo].[tab_roles] ([Roleid])
GO
ALTER TABLE [dbo].[tab_promo]  WITH CHECK ADD FOREIGN KEY([zoneid])
REFERENCES [dbo].[tab_zone] ([zoneid])
GO
ALTER TABLE [dbo].[tab_refreshtoken]  WITH CHECK ADD  CONSTRAINT [fk_userrefreshtoken] FOREIGN KEY([userid])
REFERENCES [dbo].[tab_admin] ([id])
GO
ALTER TABLE [dbo].[tab_refreshtoken] CHECK CONSTRAINT [fk_userrefreshtoken]
GO
ALTER TABLE [dbo].[tab_servicelocation]  WITH CHECK ADD FOREIGN KEY([countryid])
REFERENCES [dbo].[tab_Country] ([CountryId])
GO
ALTER TABLE [dbo].[tab_servicelocation]  WITH CHECK ADD FOREIGN KEY([currencyid])
REFERENCES [dbo].[tab_common_currency] ([currencyid])
GO
ALTER TABLE [dbo].[tab_servicelocation]  WITH CHECK ADD FOREIGN KEY([timezoneid])
REFERENCES [dbo].[tab_timezone] ([timezoneid])
GO
ALTER TABLE [dbo].[tab_setprice_zonetype]  WITH CHECK ADD FOREIGN KEY([zonetypeid])
REFERENCES [dbo].[tab_zonetype_relationship] ([zonetypeid])
GO
ALTER TABLE [dbo].[tab_timezone]  WITH CHECK ADD FOREIGN KEY([countryid])
REFERENCES [dbo].[tab_Country] ([CountryId])
GO
ALTER TABLE [dbo].[tab_user]  WITH CHECK ADD FOREIGN KEY([countryid])
REFERENCES [dbo].[tab_Country] ([CountryId])
GO
ALTER TABLE [dbo].[tab_user]  WITH CHECK ADD FOREIGN KEY([currencyid])
REFERENCES [dbo].[tab_currencies] ([currenciesid])
GO
ALTER TABLE [dbo].[tab_user]  WITH CHECK ADD FOREIGN KEY([timezoneid])
REFERENCES [dbo].[tab_timezone] ([timezoneid])
GO
ALTER TABLE [dbo].[tab_User_cancellation]  WITH CHECK ADD FOREIGN KEY([zonetypeid])
REFERENCES [dbo].[tab_zonetype_relationship] ([zonetypeid])
GO
ALTER TABLE [dbo].[tab_User_Complaint]  WITH CHECK ADD FOREIGN KEY([zoneid])
REFERENCES [dbo].[tab_zone] ([zoneid])
GO
ALTER TABLE [dbo].[tab_zone]  WITH CHECK ADD FOREIGN KEY([servicelocid])
REFERENCES [dbo].[tab_servicelocation] ([servicelocid])
GO
ALTER TABLE [dbo].[tab_zonepolygon]  WITH CHECK ADD FOREIGN KEY([zoneid])
REFERENCES [dbo].[tab_zone] ([zoneid])
GO
ALTER TABLE [dbo].[tab_zonetype_relationship]  WITH CHECK ADD FOREIGN KEY([typeid])
REFERENCES [dbo].[tab_types] ([typeid])
GO
ALTER TABLE [dbo].[tab_zonetype_relationship]  WITH CHECK ADD FOREIGN KEY([zoneid])
REFERENCES [dbo].[tab_zone] ([zoneid])
GO
USE [master]
GO
ALTER DATABASE [TaxiAppzDB] SET  READ_WRITE 
GO
