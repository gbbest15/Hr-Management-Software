USE [master]
GO
/****** Object:  Database [hr Management software]    Script Date: 9/14/2020 11:20:14 AM ******/
CREATE DATABASE [hr Management software]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hr Management software', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\hr Management software.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hr Management software_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\hr Management software_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [hr Management software] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hr Management software].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hr Management software] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hr Management software] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hr Management software] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hr Management software] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hr Management software] SET ARITHABORT OFF 
GO
ALTER DATABASE [hr Management software] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hr Management software] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hr Management software] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hr Management software] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hr Management software] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hr Management software] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hr Management software] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hr Management software] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hr Management software] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hr Management software] SET  DISABLE_BROKER 
GO
ALTER DATABASE [hr Management software] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hr Management software] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hr Management software] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hr Management software] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hr Management software] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hr Management software] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hr Management software] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hr Management software] SET RECOVERY FULL 
GO
ALTER DATABASE [hr Management software] SET  MULTI_USER 
GO
ALTER DATABASE [hr Management software] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hr Management software] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hr Management software] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hr Management software] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hr Management software] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'hr Management software', N'ON'
GO
ALTER DATABASE [hr Management software] SET QUERY_STORE = OFF
GO
USE [hr Management software]
GO
/****** Object:  Table [dbo].[cert_tran]    Script Date: 9/14/2020 11:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cert_tran](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Name] [varchar](255) NULL,
	[Certificate_Name] [varchar](255) NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_cert_tran] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DropdownMenu]    Script Date: 9/14/2020 11:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DropdownMenu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dropdown] [varchar](50) NOT NULL,
	[Added_Text] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DropdownMenu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee_form]    Script Date: 9/14/2020 11:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee_form](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Employee_No] [varchar](50) NULL,
	[Employee_Name] [varchar](50) NULL,
	[Nationality] [varchar](50) NULL,
	[Destination] [varchar](50) NULL,
	[Division] [varchar](50) NULL,
	[Qid_No] [varchar](50) NULL,
	[Qid_Expiry_Date] [date] NULL,
	[Passport_Number] [varchar](50) NULL,
	[PP_Expiry_Date] [date] NULL,
	[Driving_Licence] [varchar](50) NULL,
	[D_Licence_Expiry_Date] [date] NULL,
	[Health_Card_No] [varchar](50) NULL,
	[Health_Card_Expiry_Date] [date] NULL,
	[Dath_of_Birth] [date] NULL,
	[Blood_Group] [varchar](50) NULL,
	[Join_Date] [date] NULL,
	[Re_entry_date] [varchar](50) NULL,
	[Total_year_service] [varchar](50) NULL,
	[Re_service] [varchar](50) NULL,
	[Basic_salary] [varchar](50) NULL,
	[Allawance] [varchar](50) NULL,
	[Mobile_Number] [varchar](50) NULL,
	[Address_in_qater] [varchar](50) NULL,
	[Next_of_kin] [varchar](50) NULL,
	[Image] [image] NULL,
	[Destination_Image] [image] NULL,
	[Qid_image] [image] NULL,
	[PP_image] [image] NULL,
	[DL_Image] [image] NULL,
	[Health_Image] [image] NULL,
	[Allowance_Image] [image] NULL,
 CONSTRAINT [PK_employee_form] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gate_Pass]    Script Date: 9/14/2020 11:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gate_Pass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Name] [varchar](50) NULL,
	[Pass_Type] [varchar](50) NULL,
	[GatePass_Validity] [varchar](50) NULL,
	[Retun_Date] [varchar](50) NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_Gate_Pass] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gratidute_paid]    Script Date: 9/14/2020 11:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gratidute_paid](
	[Description] [varchar](50) NULL,
	[Paid] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave_Salary]    Script Date: 9/14/2020 11:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave_Salary](
	[Date] [varchar](50) NULL,
	[Employee_Name] [varchar](50) NULL,
	[ID_No] [varchar](50) NULL,
	[Nationality] [varchar](50) NULL,
	[Agreement_Date] [varchar](50) NULL,
	[Departure_Date] [varchar](50) NULL,
	[Agreement_Salary] [varchar](50) NULL,
	[Date_From] [date] NULL,
	[Date_To] [date] NULL,
	[Total_Days] [varchar](50) NULL,
	[T_Absent] [varchar](50) NULL,
	[No_Day_Vacation] [varchar](50) NULL,
	[T_Works_Days] [varchar](50) NULL,
	[Total_Leave_Days] [numeric](18, 0) NULL,
	[T_Leave_Salary] [money] NULL,
	[T_End_Service] [money] NULL,
	[Net_Payable] [varchar](50) NULL,
	[Net_Balance] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[letter]    Script Date: 9/14/2020 11:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[letter](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Name] [varchar](50) NULL,
	[Letter_Name] [varchar](50) NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_letter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[login]    Script Date: 9/14/2020 11:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login](
	[id] [int] NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[V_schedule]    Script Date: 9/14/2020 11:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[V_schedule](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Name] [varchar](50) NULL,
	[First_Entry] [varchar](50) NULL,
	[Leave_Application_Copy] [varchar](50) NULL,
	[Leave_Salary_Net] [varchar](50) NULL,
	[Paid_Leave_Salary] [varchar](50) NULL,
	[Balance_Leave_Salary] [varchar](50) NULL,
	[Re_Entry_Ticket_Copy] [varchar](50) NULL,
	[Total_Year_of_Service] [varchar](255) NULL,
	[Re_Service] [varchar](50) NULL,
	[Image] [image] NULL,
	[image1] [image] NULL,
 CONSTRAINT [PK_V_schedule] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle_Expenses]    Script Date: 9/14/2020 11:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle_Expenses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Vehicle_No] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Expenses] [varchar](50) NULL,
	[Fine] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
 CONSTRAINT [PK_Vehicle_Expenses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle_No]    Script Date: 9/14/2020 11:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle_No](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Vehicle_No] [varchar](50) NULL,
	[Istimary_Expiry_Date] [date] NULL,
	[Insurance_Validity_Date] [date] NULL,
	[Vehicle_Pass] [varchar](50) NULL,
	[Image] [image] NULL,
	[Image1] [image] NULL,
	[Image2] [image] NULL,
 CONSTRAINT [PK_Vehicle_No] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [hr Management software] SET  READ_WRITE 
GO
