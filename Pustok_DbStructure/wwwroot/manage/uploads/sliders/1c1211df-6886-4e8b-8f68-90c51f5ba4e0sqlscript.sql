USE [master]
GO
/****** Object:  Database [lessonTask4]    Script Date: 6/22/2023 10:58:25 AM ******/
CREATE DATABASE [lessonTask4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'lessonTask4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\lessonTask4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'lessonTask4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\lessonTask4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [lessonTask4] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [lessonTask4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [lessonTask4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [lessonTask4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [lessonTask4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [lessonTask4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [lessonTask4] SET ARITHABORT OFF 
GO
ALTER DATABASE [lessonTask4] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [lessonTask4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [lessonTask4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [lessonTask4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [lessonTask4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [lessonTask4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [lessonTask4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [lessonTask4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [lessonTask4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [lessonTask4] SET  ENABLE_BROKER 
GO
ALTER DATABASE [lessonTask4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [lessonTask4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [lessonTask4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [lessonTask4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [lessonTask4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [lessonTask4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [lessonTask4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [lessonTask4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [lessonTask4] SET  MULTI_USER 
GO
ALTER DATABASE [lessonTask4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [lessonTask4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [lessonTask4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [lessonTask4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [lessonTask4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [lessonTask4] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [lessonTask4] SET QUERY_STORE = ON
GO
ALTER DATABASE [lessonTask4] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [lessonTask4]
GO
/****** Object:  Table [dbo].[Cashier]    Script Date: 6/22/2023 10:58:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cashier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/22/2023 10:58:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Price] [decimal](4, 2) NULL,
	[Sale_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 6/22/2023 10:58:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[TotalPrice] [decimal](5, 2) NULL,
	[Cashier_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cashier] ON 

INSERT [dbo].[Cashier] ([Id], [Name]) VALUES (1, N'Faiq')
INSERT [dbo].[Cashier] ([Id], [Name]) VALUES (2, N'Nuru')
INSERT [dbo].[Cashier] ([Id], [Name]) VALUES (3, N'Bahruz')
INSERT [dbo].[Cashier] ([Id], [Name]) VALUES (4, N'Samir')
SET IDENTITY_INSERT [dbo].[Cashier] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Price], [Sale_Id]) VALUES (1, N'PR1', CAST(14.22 AS Decimal(4, 2)), 2)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Sale_Id]) VALUES (2, N'PR2', CAST(4.99 AS Decimal(4, 2)), 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Sale_Id]) VALUES (3, N'PR3', CAST(2.00 AS Decimal(4, 2)), 3)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Sale_Id]) VALUES (4, N'PR4', CAST(23.89 AS Decimal(4, 2)), 4)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale] ON 

INSERT [dbo].[Sale] ([Id], [Date], [TotalPrice], [Cashier_Id]) VALUES (1, CAST(N'2023-05-16' AS Date), CAST(50.20 AS Decimal(5, 2)), 1)
INSERT [dbo].[Sale] ([Id], [Date], [TotalPrice], [Cashier_Id]) VALUES (2, CAST(N'2023-05-11' AS Date), CAST(101.90 AS Decimal(5, 2)), 3)
INSERT [dbo].[Sale] ([Id], [Date], [TotalPrice], [Cashier_Id]) VALUES (3, CAST(N'2023-03-10' AS Date), CAST(150.50 AS Decimal(5, 2)), 2)
INSERT [dbo].[Sale] ([Id], [Date], [TotalPrice], [Cashier_Id]) VALUES (4, CAST(N'2023-04-14' AS Date), CAST(66.10 AS Decimal(5, 2)), 4)
SET IDENTITY_INSERT [dbo].[Sale] OFF
GO
ALTER TABLE [dbo].[Sale] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([Sale_Id])
REFERENCES [dbo].[Sale] ([Id])
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD FOREIGN KEY([Cashier_Id])
REFERENCES [dbo].[Cashier] ([Id])
GO
USE [master]
GO
ALTER DATABASE [lessonTask4] SET  READ_WRITE 
GO
