USE [master]
GO
/****** Object:  Database [TaxiAppzDB]    Script Date: 18-07-2020 10:02:34 ******/
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
/****** Object:  StoredProcedure [dbo].[GetAdminDetails]    Script Date: 18-07-2020 10:02:34 ******/
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
/****** Object:  Table [dbo].[tab_admin]    Script Date: 18-07-2020 10:02:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_admin](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[admin_key] [nvarchar](200) NULL,
	[admin_reference] [int] NULL,
	[area_name] [nvarchar](150) NULL,
	[language] [int] NULL,
	[firstname] [nvarchar](200) NULL,
	[lastname] [nvarchar](200) NULL,
	[registration_code] [nvarchar](255) NULL,
	[email] [nvarchar](191) NULL,
	[password] [nvarchar](50) NULL,
	[phone_number] [nvarchar](20) NULL,
	[emergency_number] [nvarchar](20) NULL,
	[remember_token] [nvarchar](600) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
	[is_active] [int] NULL,
	[role] [bigint] NULL,
	[profile_pic] [nvarchar](100) NULL,
	[zone_access] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tab_admin_details]    Script Date: 18-07-2020 10:02:36 ******/
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
PRIMARY KEY CLUSTERED 
(
	[admindtlsid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_Common_Languages]    Script Date: 18-07-2020 10:02:37 ******/
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
/****** Object:  Table [dbo].[tab_Country]    Script Date: 18-07-2020 10:02:37 ******/
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
	[time_zone] [nvarchar](200) NULL,
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
/****** Object:  Table [dbo].[tab_refreshtoken]    Script Date: 18-07-2020 10:02:38 ******/
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
/****** Object:  Table [dbo].[tab_roles]    Script Date: 18-07-2020 10:02:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
PRIMARY KEY CLUSTERED 
(
	[Roleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[tbl_errorlog]    Script Date: 18-07-2020 10:02:40 ******/
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
SET IDENTITY_INSERT [dbo].[tab_admin] ON 

INSERT [dbo].[tab_admin] ([id], [admin_key], [admin_reference], [area_name], [language], [firstname], [lastname], [registration_code], [email], [password], [phone_number], [emergency_number], [remember_token], [created_at], [updated_at], [deleted_at], [is_active], [role], [profile_pic], [zone_access]) VALUES (1, N'401420', 401420, N'', 1, N'Dilip', N'Ashok', N'18784', N'admin@gmail.com', N'123456789', N'962777774565', N'919003991988', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJEaWxpcCIsImxhc3ROYW1lIjoiQXNob2siLCJyb2xlIjoic3VwZXJBZG1pbiIsImp0aSI6ImFjZWMxM2YzLWI2ZWYtNDk4ZC1hZjk2LTYyM2FlOWRiMDRlMCIsImV4cCI6MTU5NDUzOTYwNywiaXNzIjoiaHR0cHM6Ly90YXhpYXBwemFwaS5henVyZXdlYnNpdGVzLm5ldC8iLCJhdWQiOiJodHRwczovL3RheGlhcHB6YXBpLmF6dXJld2Vic2l0ZXMubmV0LyJ9.x3Rhsqt9Bog85XvaKH_ZLHEEu-ZvaFvAbRLP6jgpwYI', CAST(0x0000ABEB009440BE AS DateTime), CAST(0x0000ABF60076234C AS DateTime), NULL, 1, 2, N'', 1)
INSERT [dbo].[tab_admin] ([id], [admin_key], [admin_reference], [area_name], [language], [firstname], [lastname], [registration_code], [email], [password], [phone_number], [emergency_number], [remember_token], [created_at], [updated_at], [deleted_at], [is_active], [role], [profile_pic], [zone_access]) VALUES (2, N'401420', 401420, NULL, 1, N'jagan1', N'jagan1', N'18785', N'super@gmail.com', N'123456789', N'9999999999', N'1231231231', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJqYWdhbjEiLCJsYXN0TmFtZSI6ImphZ2FuMSIsInJvbGUiOiJzdHJpbmciLCJqdGkiOiIwOTUxYjBhMC1jYjMxLTQxZmUtYmE1OS01NjhiNzVjZjkzMWMiLCJleHAiOjE1OTUwMDE1NDMsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0Mzc0LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0Mzc0LyJ9.pJj24T36csTnLD31QPUtKFDjZ036vKqCAmXuKPSVJL8', CAST(0x0000ABF601131C5C AS DateTime), CAST(0x0000ABFB00FF2C9A AS DateTime), NULL, 1, 1, NULL, 1)
INSERT [dbo].[tab_admin] ([id], [admin_key], [admin_reference], [area_name], [language], [firstname], [lastname], [registration_code], [email], [password], [phone_number], [emergency_number], [remember_token], [created_at], [updated_at], [deleted_at], [is_active], [role], [profile_pic], [zone_access]) VALUES (5, N'401420', 401420, NULL, 1, N'Jagan', N'Jagan', N'18786', N'RM@gmail.com', N'123456789', N'9999999999', N'1231231231', NULL, CAST(0x0000ABF601150AF4 AS DateTime), NULL, NULL, 1, 6, NULL, 1)
INSERT [dbo].[tab_admin] ([id], [admin_key], [admin_reference], [area_name], [language], [firstname], [lastname], [registration_code], [email], [password], [phone_number], [emergency_number], [remember_token], [created_at], [updated_at], [deleted_at], [is_active], [role], [profile_pic], [zone_access]) VALUES (6, N'401420', 401420, NULL, 1, N'Sundar Ganesh', N'Dhinakaran', N'18787', N'sundar@gmail.com', N'123456789', N'7894561231', N'1231231231', NULL, CAST(0x0000ABF60115BEA0 AS DateTime), NULL, NULL, 1, 5, NULL, 1)
INSERT [dbo].[tab_admin] ([id], [admin_key], [admin_reference], [area_name], [language], [firstname], [lastname], [registration_code], [email], [password], [phone_number], [emergency_number], [remember_token], [created_at], [updated_at], [deleted_at], [is_active], [role], [profile_pic], [zone_access]) VALUES (7, N'401420', 401420, NULL, 1, N'Satheesh', N'Kumar', N'18788', N'satheesh@gmail.com', N'123456789', N'7894561231', N'1231231231', NULL, CAST(0x0000ABF6011999F2 AS DateTime), NULL, NULL, 1, 5, NULL, 1)
INSERT [dbo].[tab_admin] ([id], [admin_key], [admin_reference], [area_name], [language], [firstname], [lastname], [registration_code], [email], [password], [phone_number], [emergency_number], [remember_token], [created_at], [updated_at], [deleted_at], [is_active], [role], [profile_pic], [zone_access]) VALUES (8, N'401420', 401420, NULL, 1, N'Sasi', N'Kumar', N'18789', N'sasi@gmail.com', N'123456789', N'7894561231', N'1231231231', NULL, CAST(0x0000ABF60119D537 AS DateTime), NULL, NULL, 1, 7, NULL, 1)
INSERT [dbo].[tab_admin] ([id], [admin_key], [admin_reference], [area_name], [language], [firstname], [lastname], [registration_code], [email], [password], [phone_number], [emergency_number], [remember_token], [created_at], [updated_at], [deleted_at], [is_active], [role], [profile_pic], [zone_access]) VALUES (9, N'401420', 401420, NULL, 1, N'Rajesh', N'Kannan', N'18790', N'rajesh@gmail.com', N'123456789', N'7894561231', N'1231231231', NULL, CAST(0x0000ABF6011A5BA7 AS DateTime), NULL, NULL, 1, 8, NULL, 1)
SET IDENTITY_INSERT [dbo].[tab_admin] OFF
SET IDENTITY_INSERT [dbo].[tab_admin_details] ON 

INSERT [dbo].[tab_admin_details] ([admindtlsid], [admin_id], [address], [city], [Country_id], [postalCode], [timezone], [document_name], [document], [driver_document_count], [last_login_ip_address], [block], [login_attempt], [isActive], [created_by], [created_at], [updated_at], [deleted_at]) VALUES (1, 1, N'Sport City', NULL, 1, 641001, N'Kolkata', NULL, NULL, NULL, NULL, 1, 1, 1, N'Admin', CAST(0x0000ABFA0126E19B AS DateTime), NULL, NULL)
INSERT [dbo].[tab_admin_details] ([admindtlsid], [admin_id], [address], [city], [Country_id], [postalCode], [timezone], [document_name], [document], [driver_document_count], [last_login_ip_address], [block], [login_attempt], [isActive], [created_by], [created_at], [updated_at], [deleted_at]) VALUES (2, 2, N'Crosscut Road', NULL, 1, 641012, N'Kolkata', NULL, NULL, NULL, NULL, 1, 1, 1, N'Admin', CAST(0x0000ABFA012734A9 AS DateTime), NULL, NULL)
INSERT [dbo].[tab_admin_details] ([admindtlsid], [admin_id], [address], [city], [Country_id], [postalCode], [timezone], [document_name], [document], [driver_document_count], [last_login_ip_address], [block], [login_attempt], [isActive], [created_by], [created_at], [updated_at], [deleted_at]) VALUES (3, 5, N'Gandhi Puram', NULL, 1, 641012, N'Kolkata', NULL, NULL, NULL, NULL, 1, 1, 1, N'Admin', CAST(0x0000ABFA012758E5 AS DateTime), NULL, NULL)
INSERT [dbo].[tab_admin_details] ([admindtlsid], [admin_id], [address], [city], [Country_id], [postalCode], [timezone], [document_name], [document], [driver_document_count], [last_login_ip_address], [block], [login_attempt], [isActive], [created_by], [created_at], [updated_at], [deleted_at]) VALUES (4, 6, N'Gugai,Salem', NULL, 1, 636006, N'Kolkata', NULL, NULL, NULL, NULL, 1, 1, 1, N'Admin', CAST(0x0000ABFA0127C43D AS DateTime), NULL, NULL)
INSERT [dbo].[tab_admin_details] ([admindtlsid], [admin_id], [address], [city], [Country_id], [postalCode], [timezone], [document_name], [document], [driver_document_count], [last_login_ip_address], [block], [login_attempt], [isActive], [created_by], [created_at], [updated_at], [deleted_at]) VALUES (5, 7, N'Chitra,Salem', NULL, 1, 636006, N'Kolkata', NULL, NULL, NULL, NULL, 1, 1, 1, N'Admin', CAST(0x0000ABFA0127D4D0 AS DateTime), NULL, NULL)
INSERT [dbo].[tab_admin_details] ([admindtlsid], [admin_id], [address], [city], [Country_id], [postalCode], [timezone], [document_name], [document], [driver_document_count], [last_login_ip_address], [block], [login_attempt], [isActive], [created_by], [created_at], [updated_at], [deleted_at]) VALUES (6, 8, N'Coimbatore', NULL, 1, 636006, N'Kolkata', NULL, NULL, NULL, NULL, 1, 1, 1, N'Admin', CAST(0x0000ABFA01281F5D AS DateTime), NULL, NULL)
INSERT [dbo].[tab_admin_details] ([admindtlsid], [admin_id], [address], [city], [Country_id], [postalCode], [timezone], [document_name], [document], [driver_document_count], [last_login_ip_address], [block], [login_attempt], [isActive], [created_by], [created_at], [updated_at], [deleted_at]) VALUES (7, 9, N'Coimbatore', NULL, 1, 636006, N'Kolkata', NULL, NULL, NULL, NULL, 1, 1, 1, N'Admin', CAST(0x0000ABFA0128256D AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tab_admin_details] OFF
SET IDENTITY_INSERT [dbo].[tab_Common_Languages] ON 

INSERT [dbo].[tab_Common_Languages] ([Languageid], [Short_Lang], [Name], [Created_By], [Created_At], [Updated_At], [Deleted_At]) VALUES (1, N'en', N'English', N'admin', CAST(0x0000ABF1000CEA72 AS DateTime), NULL, NULL)
INSERT [dbo].[tab_Common_Languages] ([Languageid], [Short_Lang], [Name], [Created_By], [Created_At], [Updated_At], [Deleted_At]) VALUES (2, N'spa', N'Spanish', N'admin', CAST(0x0000ABF1000CEA72 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tab_Common_Languages] OFF
SET IDENTITY_INSERT [dbo].[tab_Country] ON 

INSERT [dbo].[tab_Country] ([CountryId], [Code], [Name], [Currency], [d_code], [time_zone], [Created_By], [Created_At], [Updated_At], [Deleted_At]) VALUES (1, N'IN', N'India', NULL, N'+91', N'Kolkata', N'Admin', CAST(0x0000ABF10011AC4F AS DateTime), NULL, NULL)
INSERT [dbo].[tab_Country] ([CountryId], [Code], [Name], [Currency], [d_code], [time_zone], [Created_By], [Created_At], [Updated_At], [Deleted_At]) VALUES (2, N'SG', N'Singapore', NULL, N'+65', N'Singapore', N'Admin', CAST(0x0000ABF100121A48 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tab_Country] OFF
SET IDENTITY_INSERT [dbo].[tab_roles] ON 

INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (1, N'string', N'string', N'string', 1, 1, N'Admin', CAST(0x0000ABF10006BE6F AS DateTime), CAST(0x0000ABFB00EA481B AS DateTime), 0)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (2, N'admin', N'Admin', N'Admin group with restricted acces', 0, 1, N'admin', CAST(0x0000ABF10007EEB3 AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (3, N'string3333', N'string', N'string333333', 1, 1, N'Admin', CAST(0x0000ABF10007EEB4 AS DateTime), CAST(0x0000ABF900F6469C AS DateTime), 0)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (4, N'driver', N'Driver User', N'Driver user with standard access', 0, 1, N'admin', CAST(0x0000ABF10007EEB4 AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (5, N'dispatcher', N'Dispatcher', N'Dispatcher role to assign trip', 0, 1, N'admin', CAST(0x0000ABF10007EEB4 AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (6, N'Regional Manager', N'Jagan', N'For Coimbatore', 0, 1, N'admin', CAST(0x0000ABF10007EEB4 AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (7, N'J Manager', N'Sasi', N'Admin Control', 0, 1, N'admin', CAST(0x0000ABF10007EEB4 AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (8, N'supervisor', N'super', N'new', 0, 1, N'admin', CAST(0x0000ABF10007EEB4 AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (9, N'Sr. Manager', N'Senior Manager', N'testing', 1, 1, N'Admin', CAST(0x0000ABF70122C3EE AS DateTime), CAST(0x0000ABF70186A9BD AS DateTime), 0)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (10, N'string', N'string', N'string', 1, 1, N'Admin', CAST(0x0000ABF900DF1232 AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (11, N'asdasd', N'asdasdsa', N'asdasdasd', 1, 1, N'Admin', CAST(0x0000ABF900F8FF8E AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (12, N'dfsdfsd', N'sdfsdf', N'sdfsdf', 1, 1, N'Admin', CAST(0x0000ABF900F9F0EA AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (13, N'dfsdfsd', N'sdfsdf', N'sdfsdf', 1, 1, N'Admin', CAST(0x0000ABF900FA0A87 AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (14, N'sadasdas', N'asdas', N'asdasd', 1, 1, N'Admin', CAST(0x0000ABF900FA958F AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (15, N'xzcxz', N'zxczxcz', N'zxczxc', 1, 1, N'Admin', CAST(0x0000ABF900FBBE17 AS DateTime), NULL, 1)
INSERT [dbo].[tab_roles] ([Roleid], [RoleName], [Display_Name], [Description], [ALL_Rights], [Locked], [Created_By], [Created_At], [Updated_At], [IsActive]) VALUES (16, N'zzzz', N'zzz', N'zzz', 1, 1, N'Admin', CAST(0x0000ABFB00E116E5 AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[tab_roles] OFF
SET IDENTITY_INSERT [dbo].[tbl_errorlog] ON 

INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (1, N'Login Entered', CAST(0x0000ABF201348006 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (2, N'Login Entered', CAST(0x0000ABF2013F10F8 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (3, N'Login Entered', CAST(0x0000ABF20141D3D7 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (4, N'Login Entered', CAST(0x0000ABF201449840 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (5, N'Login Entered', CAST(0x0000ABF300BCBAE9 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (6, N'Login Entered', CAST(0x0000ABF300D88774 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (7, N'Login Entered', CAST(0x0000ABF300F4EAEB AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (8, N'Login Entered', CAST(0x0000ABF300FBD04F AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (9, N'Login Entered', CAST(0x0000ABF300FBE9B4 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (10, N'Login Entered', CAST(0x0000ABF300FCB221 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (11, N'Login Entered', CAST(0x0000ABF300FD604C AS DateTime), N'super@gmail.com1', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (12, N'Login Entered', CAST(0x0000ABF30134C414 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (13, N'Login Entered', CAST(0x0000ABF30136B1E2 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (14, N'Login Entered', CAST(0x0000ABF30141C9F6 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (15, N'Login Entered', CAST(0x0000ABF6001FE70C AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (16, N'Login Entered', CAST(0x0000ABF60020A4F7 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (17, N'Login Entered', CAST(0x0000ABF60028181A AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (18, N'Login Entered', CAST(0x0000ABF60029C385 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (19, N'Login Entered', CAST(0x0000ABF6002AFD0C AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (20, N'Lambda expression used inside Include is not valid.', CAST(0x0000ABF6002B1D69 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (21, N'Login Entered', CAST(0x0000ABF6002C019E AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (22, N'Login Entered', CAST(0x0000ABF60031865A AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (23, N'Login Entered', CAST(0x0000ABF600339942 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (24, N'Login Entered', CAST(0x0000ABF600353616 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (25, N'Login Entered', CAST(0x0000ABF60035DD08 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (26, N'Login Entered', CAST(0x0000ABF600381999 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (27, N'Login Entered', CAST(0x0000ABF6003A249F AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (28, N'Login Entered', CAST(0x0000ABF6006ED533 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (29, N'Login Entered', CAST(0x0000ABF60072A1D8 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (30, N'Login Entered', CAST(0x0000ABF6007305A4 AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (31, N'Login Entered', CAST(0x0000ABF6007621CB AS DateTime), N'super@gmail.com', N'Login Controller')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (32, N'Token Generation', CAST(0x0000ABF600A3A174 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (33, N'Update Token', CAST(0x0000ABF600A3BB99 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (34, N'Token Generation', CAST(0x0000ABF600A52442 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (35, N'Update Token', CAST(0x0000ABF600A52B9E AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (36, N'Token Generation', CAST(0x0000ABF600A549C5 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (37, N'Update Token', CAST(0x0000ABF600A54AFB AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (38, N'Token Generation', CAST(0x0000ABF600A55FA6 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (39, N'Update Token', CAST(0x0000ABF600A5610E AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (40, N'Token Generation', CAST(0x0000ABF600A57CB0 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (41, N'Update Token', CAST(0x0000ABF600A57DC1 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (42, N'Token Generation', CAST(0x0000ABF600A60D32 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (43, N'Update Token', CAST(0x0000ABF600A60F20 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (44, N'Token Generation', CAST(0x0000ABF600A6E030 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (45, N'Update Token', CAST(0x0000ABF600A6E0BE AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (46, N'Token Generation', CAST(0x0000ABF601275970 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (47, N'Update Token', CAST(0x0000ABF601275C64 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (48, N'Token Generation', CAST(0x0000ABF6012948C8 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (49, N'Update Token', CAST(0x0000ABF601294C0F AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (50, N'Token Generation', CAST(0x0000ABF6012A96EE AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (51, N'Update Token', CAST(0x0000ABF6012A98DB AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (52, N'Token Generation', CAST(0x0000ABF6012D2CD3 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (53, N'Update Token', CAST(0x0000ABF6012D2F50 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (54, N'Token Generation', CAST(0x0000ABF60130B4DC AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (55, N'Update Token', CAST(0x0000ABF60130B6CD AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (56, N'Token Generation', CAST(0x0000ABF601317F95 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (57, N'Update Token', CAST(0x0000ABF601318188 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (58, N'Token Generation', CAST(0x0000ABF70046EA50 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (59, N'Update Token', CAST(0x0000ABF70046EAAE AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (60, N'Token Generation', CAST(0x0000ABF700F9B1F6 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (61, N'Update Token', CAST(0x0000ABF700F9B392 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (62, N'Token Generation', CAST(0x0000ABF7011F089A AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (63, N'Update Token', CAST(0x0000ABF7011F0B26 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (64, N'Token Generation', CAST(0x0000ABF7012032B5 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (65, N'Update Token', CAST(0x0000ABF70120347A AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (66, N'Token Generation', CAST(0x0000ABF701221545 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (67, N'Update Token', CAST(0x0000ABF70122177C AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (68, N'Token Generation', CAST(0x0000ABF701240D17 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (69, N'Update Token', CAST(0x0000ABF701240EDC AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (70, N'Token Generation', CAST(0x0000ABF7012511AF AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (71, N'Update Token', CAST(0x0000ABF70125137F AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (72, N'Token Generation', CAST(0x0000ABF7012BA35F AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (73, N'Update Token', CAST(0x0000ABF7012BA4D1 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (74, N'Token Generation', CAST(0x0000ABF7012FDABE AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (75, N'Update Token', CAST(0x0000ABF7012FDDA4 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (76, N'Token Generation', CAST(0x0000ABF701308C03 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (77, N'Update Token', CAST(0x0000ABF701308C5A AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (78, N'Token Generation', CAST(0x0000ABF8002BE3A1 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (79, N'Update Token', CAST(0x0000ABF8002BE3C1 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (80, N'Token Generation', CAST(0x0000ABF801262435 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (81, N'Update Token', CAST(0x0000ABF801262764 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (82, N'Token Generation', CAST(0x0000ABF8012A6DD9 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (83, N'Update Token', CAST(0x0000ABF8012A6F97 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (84, N'Token Generation', CAST(0x0000ABF801365CB3 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (85, N'Update Token', CAST(0x0000ABF801365DF2 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (86, N'Token Generation', CAST(0x0000ABF801378DB2 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (87, N'Update Token', CAST(0x0000ABF801378FDD AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (88, N'Token Generation', CAST(0x0000ABF801387050 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (89, N'Update Token', CAST(0x0000ABF8013871BE AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (90, N'Token Generation', CAST(0x0000ABF80139D64E AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (91, N'Update Token', CAST(0x0000ABF80139D86B AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (92, N'Token Generation', CAST(0x0000ABF801443A2F AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (93, N'Update Token', CAST(0x0000ABF801443BBF AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (94, N'Token Generation', CAST(0x0000ABF80145620C AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (95, N'Update Token', CAST(0x0000ABF8014563D1 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (96, N'Token Generation', CAST(0x0000ABF8014A9392 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (97, N'Update Token', CAST(0x0000ABF8014A94F2 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (98, N'Token Generation', CAST(0x0000ABF8014B5807 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (99, N'Update Token', CAST(0x0000ABF8014B59D3 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
GO
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (100, N'Token Generation', CAST(0x0000ABF8014C7A9E AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (101, N'Update Token', CAST(0x0000ABF8014C7C6A AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (102, N'Token Generation', CAST(0x0000ABF8014DE4EB AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (103, N'Update Token', CAST(0x0000ABF8014DE552 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (104, N'Token Generation', CAST(0x0000ABF900C879C8 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (105, N'Update Token', CAST(0x0000ABF900C87A35 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (106, N'Token Generation', CAST(0x0000ABF900C88B83 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (107, N'Update Token', CAST(0x0000ABF900C88BA0 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (108, N'Token Generation', CAST(0x0000ABF900C91284 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (109, N'Update Token', CAST(0x0000ABF900C912A1 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (110, N'Token Generation', CAST(0x0000ABF900C95290 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (111, N'Update Token', CAST(0x0000ABF900C952A8 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (112, N'Token Generation', CAST(0x0000ABF900D3C9AD AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (113, N'Update Token', CAST(0x0000ABF900D3C9C9 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (114, N'Token Generation', CAST(0x0000ABF900D8AB65 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (115, N'Update Token', CAST(0x0000ABF900D8AB7E AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (116, N'Token Generation', CAST(0x0000ABF900E42609 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (117, N'Update Token', CAST(0x0000ABF900E42627 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (118, N'Token Generation', CAST(0x0000ABF900ED50F4 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (119, N'Update Token', CAST(0x0000ABF900ED5117 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (120, N'Token Generation', CAST(0x0000ABF900F7DD99 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (121, N'Update Token', CAST(0x0000ABF900F7DDB1 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (122, N'Token Generation', CAST(0x0000ABF901094E52 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (123, N'Update Token', CAST(0x0000ABF901094E6D AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (124, N'Token Generation', CAST(0x0000ABF901094F76 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (125, N'Update Token', CAST(0x0000ABF901094F8E AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (126, N'Token Generation', CAST(0x0000ABF90117739E AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (127, N'Update Token', CAST(0x0000ABF9011773B9 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (128, N'Token Generation', CAST(0x0000ABFA002BE13F AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (129, N'Update Token', CAST(0x0000ABFA002BE168 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (130, N'Token Generation', CAST(0x0000ABFA0035159D AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (131, N'Update Token', CAST(0x0000ABFA003515B9 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (132, N'Object reference not set to an instance of an object.', CAST(0x0000ABFA00358334 AS DateTime), N'Admin', N'EditRole')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (133, N'Object reference not set to an instance of an object.', CAST(0x0000ABFA0035D4E0 AS DateTime), N'Admin', N'EditRole')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (134, N'Object reference not set to an instance of an object.', CAST(0x0000ABFA0035E974 AS DateTime), N'Admin', N'EditRole')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (135, N'Token Generation', CAST(0x0000ABFA00C77E14 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (136, N'Update Token', CAST(0x0000ABFA00C77E35 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (137, N'Token Generation', CAST(0x0000ABFA00C77EDC AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (138, N'Update Token', CAST(0x0000ABFA00C77EF2 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (139, N'Token Generation', CAST(0x0000ABFA00CDB2C7 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (140, N'Update Token', CAST(0x0000ABFA00CDB2F3 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (141, N'Token Generation', CAST(0x0000ABFA00DAF64B AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (142, N'Update Token', CAST(0x0000ABFA00DAF672 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (143, N'Token Generation', CAST(0x0000ABFA00DAF820 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (144, N'Update Token', CAST(0x0000ABFA00DAF839 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (145, N'Token Generation', CAST(0x0000ABFA00E4C9EE AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (146, N'Update Token', CAST(0x0000ABFA00E4CA0D AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (147, N'Token Generation', CAST(0x0000ABFA00E53E19 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (148, N'Update Token', CAST(0x0000ABFA00E53E36 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (149, N'Token Generation', CAST(0x0000ABFA0143E5ED AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (150, N'Update Token', CAST(0x0000ABFA0143E802 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (151, N'Token Generation', CAST(0x0000ABFA0149B3DA AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (152, N'Update Token', CAST(0x0000ABFA0149B5AE AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (153, N'Token Generation', CAST(0x0000ABFA014B49BF AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (154, N'Update Token', CAST(0x0000ABFA014B4BCA AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (155, N'Token Generation', CAST(0x0000ABFA014BA2A5 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (156, N'Update Token', CAST(0x0000ABFA014BA510 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (157, N'Token Generation', CAST(0x0000ABFA014C08E0 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (158, N'Update Token', CAST(0x0000ABFA014C0AFB AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (159, N'Token Generation', CAST(0x0000ABFA014C933B AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (160, N'Update Token', CAST(0x0000ABFA014C95CB AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (161, N'Token Generation', CAST(0x0000ABFA014D2D09 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (162, N'Update Token', CAST(0x0000ABFA014D2F2A AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (163, N'Token Generation', CAST(0x0000ABFA014E7B19 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (164, N'Update Token', CAST(0x0000ABFA014E7CFF AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (165, N'Token Generation', CAST(0x0000ABFA014F381E AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (166, N'Update Token', CAST(0x0000ABFA014F3A35 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (167, N'Token Generation', CAST(0x0000ABFA014FAE7B AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (168, N'Update Token', CAST(0x0000ABFA014FB04B AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (169, N'Token Generation', CAST(0x0000ABFA0150AB05 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (170, N'Update Token', CAST(0x0000ABFA0150AC6E AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (171, N'Token Generation', CAST(0x0000ABFA01533C6D AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (172, N'Update Token', CAST(0x0000ABFA01533E2D AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (173, N'Token Generation', CAST(0x0000ABFA0153FDD3 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (174, N'Update Token', CAST(0x0000ABFA0153FFA9 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (175, N'Token Generation', CAST(0x0000ABFA0155ACD2 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (176, N'Update Token', CAST(0x0000ABFA0155AEF2 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (177, N'Token Generation', CAST(0x0000ABFB0031861C AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (178, N'Token Generation', CAST(0x0000ABFB0031861C AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (179, N'Update Token', CAST(0x0000ABFB00318684 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (180, N'Update Token', CAST(0x0000ABFB00318684 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (181, N'Token Generation', CAST(0x0000ABFB0031DE07 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (182, N'Update Token', CAST(0x0000ABFB0031DE23 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (183, N'Token Generation', CAST(0x0000ABFB0032113B AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (184, N'Update Token', CAST(0x0000ABFB00321155 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (185, N'Token Generation', CAST(0x0000ABFB00334093 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (186, N'Update Token', CAST(0x0000ABFB003340B2 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (187, N'Token Generation', CAST(0x0000ABFB0034CA3C AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (188, N'Update Token', CAST(0x0000ABFB0034CA57 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (189, N'Token Generation', CAST(0x0000ABFB003EB144 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (190, N'Update Token', CAST(0x0000ABFB003EB160 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (191, N'Token Generation', CAST(0x0000ABFB00432393 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (192, N'Update Token', CAST(0x0000ABFB004323B1 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (193, N'Token Generation', CAST(0x0000ABFB00CD9936 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (194, N'Update Token', CAST(0x0000ABFB00CD995D AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (195, N'Token Generation', CAST(0x0000ABFB00CD9A1B AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (196, N'Update Token', CAST(0x0000ABFB00CD9A38 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (197, N'Token Generation', CAST(0x0000ABFB00D7615D AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (198, N'Update Token', CAST(0x0000ABFB00D76175 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (199, N'Token Generation', CAST(0x0000ABFB00DAA468 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
GO
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (200, N'Update Token', CAST(0x0000ABFB00DAA488 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (201, N'Token Generation', CAST(0x0000ABFB00DF77ED AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (202, N'Update Token', CAST(0x0000ABFB00DF780C AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (203, N'Token Generation', CAST(0x0000ABFB00DFA75C AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (204, N'Update Token', CAST(0x0000ABFB00DFA772 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (205, N'Token Generation', CAST(0x0000ABFB00E0189D AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (206, N'Update Token', CAST(0x0000ABFB00E018B7 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (207, N'Token Generation', CAST(0x0000ABFB00E0AD27 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (208, N'Update Token', CAST(0x0000ABFB00E0AD3E AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (209, N'Token Generation', CAST(0x0000ABFB00E0C891 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (210, N'Update Token', CAST(0x0000ABFB00E0C8A9 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (211, N'Object reference not set to an instance of an object.', CAST(0x0000ABFB00E3C93C AS DateTime), N'Admin', N'EditRole')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (212, N'Token Generation', CAST(0x0000ABFB00EC5146 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (213, N'Update Token', CAST(0x0000ABFB00EC516A AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (214, N'Token Generation', CAST(0x0000ABFB00F00058 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (215, N'Update Token', CAST(0x0000ABFB00F00078 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (216, N'Token Generation', CAST(0x0000ABFB00F3843B AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (217, N'Update Token', CAST(0x0000ABFB00F3845D AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (218, N'Token Generation', CAST(0x0000ABFB00F3862D AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (219, N'Update Token', CAST(0x0000ABFB00F38645 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (220, N'Token Generation', CAST(0x0000ABFB00F55D97 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (221, N'Update Token', CAST(0x0000ABFB00F55DAE AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (222, N'Token Generation', CAST(0x0000ABFB00F59540 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (223, N'Update Token', CAST(0x0000ABFB00F59556 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (224, N'Token Generation', CAST(0x0000ABFB00FF2C60 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
INSERT [dbo].[tbl_errorlog] ([int], [Description], [created_at], [created_by], [FunctionName]) VALUES (225, N'Update Token', CAST(0x0000ABFB00FF2C83 AS DateTime), N'super@gmail.com', N'GenerateJWTToken')
SET IDENTITY_INSERT [dbo].[tbl_errorlog] OFF
ALTER TABLE [dbo].[tab_admin] ADD  CONSTRAINT [DF_tab_admin_Inserted]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tab_admin_details] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tab_Common_Languages] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[tab_Country] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[tab_roles] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[tbl_errorlog] ADD  DEFAULT (getdate()) FOR [created_at]
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
ALTER TABLE [dbo].[tab_admin_details]  WITH CHECK ADD FOREIGN KEY([admin_id])
REFERENCES [dbo].[tab_admin] ([id])
GO
ALTER TABLE [dbo].[tab_admin_details]  WITH CHECK ADD FOREIGN KEY([Country_id])
REFERENCES [dbo].[tab_Country] ([CountryId])
GO
ALTER TABLE [dbo].[tab_refreshtoken]  WITH CHECK ADD  CONSTRAINT [fk_userrefreshtoken] FOREIGN KEY([userid])
REFERENCES [dbo].[tab_admin] ([id])
GO
ALTER TABLE [dbo].[tab_refreshtoken] CHECK CONSTRAINT [fk_userrefreshtoken]
GO
USE [master]
GO
ALTER DATABASE [TaxiAppzDB] SET  READ_WRITE 
GO
