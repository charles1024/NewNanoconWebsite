USE [master]
GO
/****** Object:  Database [nanocon]    Script Date: 2/11/2014 5:47:54 PM ******/
CREATE DATABASE [nanocon] ON  PRIMARY 
( NAME = N'nanocon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\nanocon.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'nanocon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\nanocon_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [nanocon] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [nanocon].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [nanocon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [nanocon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [nanocon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [nanocon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [nanocon] SET ARITHABORT OFF 
GO
ALTER DATABASE [nanocon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [nanocon] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [nanocon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [nanocon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [nanocon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [nanocon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [nanocon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [nanocon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [nanocon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [nanocon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [nanocon] SET  ENABLE_BROKER 
GO
ALTER DATABASE [nanocon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [nanocon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [nanocon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [nanocon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [nanocon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [nanocon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [nanocon] SET RECOVERY FULL 
GO
ALTER DATABASE [nanocon] SET  MULTI_USER 
GO
ALTER DATABASE [nanocon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [nanocon] SET DB_CHAINING OFF 
GO
USE [nanocon]
GO
/****** Object:  Table [dbo].[tblEvent]    Script Date: 2/11/2014 5:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEvent](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [varchar](100) NOT NULL,
	[EventType] [int] NOT NULL,
	[EventPlayers] [int] NOT NULL,
	[EventGM] [varchar](100) NOT NULL,
	[EventGameSystem] [varchar](100) NOT NULL,
	[EventPublisher] [varchar](100) NOT NULL,
	[EventKnowledge] [tinyint] NOT NULL,
	[EventCost] [varchar](100) NULL,
	[EventSponsor] [varchar](100) NULL,
	[EventTime] [smalldatetime] NOT NULL,
	[EventSlots] [int] NOT NULL,
	[EventSlotExempt] [bit] NULL,
	[EventDescription] [varchar](max) NULL,
	[EventSpecial] [varchar](max) NOT NULL,
	[EventApproved] [bit] NULL,
	[EventOwner] [int] NULL,
 CONSTRAINT [PK_tblEvent] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEventType]    Script Date: 2/11/2014 5:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEventType](
	[EventTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EventTypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblEventType] PRIMARY KEY CLUSTERED 
(
	[EventTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblKnowledge]    Script Date: 2/11/2014 5:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblKnowledge](
	[KnowledgeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[KnowledgeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblKnowledge] PRIMARY KEY CLUSTERED 
(
	[KnowledgeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblMembers]    Script Date: 2/11/2014 5:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMembers](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[MemberName] [varchar](50) NOT NULL,
	[MemberLifetime] [bit] NOT NULL,
	[MemberExempt] [bit] NOT NULL,
 CONSTRAINT [PK_tblMembers] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblShoppingList]    Script Date: 2/11/2014 5:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblShoppingList](
	[ShoppingListID] [int] IDENTITY(1,1) NOT NULL,
	[ShoppingListItem] [varchar](50) NOT NULL,
	[ShoppingListQuantity] [int] NOT NULL,
	[ShoppingListSource] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 2/11/2014 5:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] NOT NULL,
	[UserUsername] [varchar](50) NOT NULL,
	[UserPassword] [varchar](50) NOT NULL,
	[UserAccess] [nchar](10) NOT NULL,
	[UserEmail] [varchar](50) NOT NULL,
	[UserFirstName] [varchar](50) NOT NULL,
	[UserLastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblSiteUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblVendor]    Script Date: 2/11/2014 5:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblVendor](
	[VendorID] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [varchar](100) NOT NULL,
	[VendorContactName] [varchar](100) NOT NULL,
	[VendorAddressLine1] [varchar](100) NOT NULL,
	[VendorAddressLine2] [varchar](100) NULL,
	[VendorCity] [varchar](100) NOT NULL,
	[VendorState] [varchar](2) NOT NULL,
	[VendorZip] [varchar](5) NOT NULL,
	[VendorPhone] [varchar](12) NOT NULL,
	[VendorFax] [varchar](12) NULL,
	[VendorContractFiled] [bit] NOT NULL,
 CONSTRAINT [PK_tblVendor] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblEvent] ADD  CONSTRAINT [DF_tblEvent_EventKnowledge]  DEFAULT ((1)) FOR [EventKnowledge]
GO
ALTER TABLE [dbo].[tblEvent]  WITH CHECK ADD  CONSTRAINT [FK_tblEvent_tblEventType] FOREIGN KEY([EventType])
REFERENCES [dbo].[tblEventType] ([EventTypeID])
GO
ALTER TABLE [dbo].[tblEvent] CHECK CONSTRAINT [FK_tblEvent_tblEventType]
GO
ALTER TABLE [dbo].[tblEvent]  WITH CHECK ADD  CONSTRAINT [FK_tblEvent_tblKnowledge] FOREIGN KEY([EventKnowledge])
REFERENCES [dbo].[tblKnowledge] ([KnowledgeID])
GO
ALTER TABLE [dbo].[tblEvent] CHECK CONSTRAINT [FK_tblEvent_tblKnowledge]
GO
ALTER TABLE [dbo].[tblEvent]  WITH CHECK ADD  CONSTRAINT [FK_tblEvent_tblUser] FOREIGN KEY([EventOwner])
REFERENCES [dbo].[tblUser] ([UserID])
GO
ALTER TABLE [dbo].[tblEvent] CHECK CONSTRAINT [FK_tblEvent_tblUser]
GO
USE [master]
GO
ALTER DATABASE [nanocon] SET  READ_WRITE 
GO
