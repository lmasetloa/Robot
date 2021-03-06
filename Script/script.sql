USE [master]
GO
/****** Object:  Database [Survivor]    Script Date: 2022/02/22 18:01:43 ******/
CREATE DATABASE [Survivor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Survivor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Survivor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Survivor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Survivor_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Survivor] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Survivor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Survivor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Survivor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Survivor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Survivor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Survivor] SET ARITHABORT OFF 
GO
ALTER DATABASE [Survivor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Survivor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Survivor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Survivor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Survivor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Survivor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Survivor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Survivor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Survivor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Survivor] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Survivor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Survivor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Survivor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Survivor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Survivor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Survivor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Survivor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Survivor] SET RECOVERY FULL 
GO
ALTER DATABASE [Survivor] SET  MULTI_USER 
GO
ALTER DATABASE [Survivor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Survivor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Survivor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Survivor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Survivor] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Survivor] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Survivor', N'ON'
GO
ALTER DATABASE [Survivor] SET QUERY_STORE = OFF
GO
USE [Survivor]
GO
/****** Object:  Table [dbo].[AuditZombiRep]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditZombiRep](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[reporterID] [int] NOT NULL,
	[newZombieID] [varchar](25) NULL,
	[createdDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender_Ref]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender_Ref](
	[gender] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[gender] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Lat] [varchar](25) NULL,
	[Long] [varchar](25) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Resource] [varchar](50) NOT NULL,
	[UserID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survivors]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survivors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[IdNumber] [varchar](13) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[Age] [int] NOT NULL,
	[IsZombi] [varchar](5) NOT NULL,
	[Lat] [varchar](50) NOT NULL,
	[Long] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AuditZombiRep] ON 

INSERT [dbo].[AuditZombiRep] ([ID], [reporterID], [newZombieID], [createdDate]) VALUES (1, 2, N'1', CAST(N'2022-02-21T14:17:36.643' AS DateTime))
INSERT [dbo].[AuditZombiRep] ([ID], [reporterID], [newZombieID], [createdDate]) VALUES (2, 3, N'1', CAST(N'2022-02-21T14:18:27.580' AS DateTime))
INSERT [dbo].[AuditZombiRep] ([ID], [reporterID], [newZombieID], [createdDate]) VALUES (3, 4, N'1', CAST(N'2022-02-22T17:25:14.530' AS DateTime))
SET IDENTITY_INSERT [dbo].[AuditZombiRep] OFF
GO
SET IDENTITY_INSERT [dbo].[Resources] ON 

INSERT [dbo].[Resources] ([ID], [Resource], [UserID]) VALUES (1, N'Water', 4)
INSERT [dbo].[Resources] ([ID], [Resource], [UserID]) VALUES (2, N'Food', 4)
INSERT [dbo].[Resources] ([ID], [Resource], [UserID]) VALUES (3, N'water', 3)
INSERT [dbo].[Resources] ([ID], [Resource], [UserID]) VALUES (4, N'Medication', 3)
INSERT [dbo].[Resources] ([ID], [Resource], [UserID]) VALUES (5, N'water', 4)
INSERT [dbo].[Resources] ([ID], [Resource], [UserID]) VALUES (6, N'Water', 5)
SET IDENTITY_INSERT [dbo].[Resources] OFF
GO
SET IDENTITY_INSERT [dbo].[Survivors] ON 

INSERT [dbo].[Survivors] ([ID], [Name], [Surname], [IdNumber], [Gender], [Age], [IsZombi], [Lat], [Long]) VALUES (1, N'Moses', N'Masetloa', N'9202205560082', N'F', 30, N'Yes', N'255445', N'84646')
INSERT [dbo].[Survivors] ([ID], [Name], [Surname], [IdNumber], [Gender], [Age], [IsZombi], [Lat], [Long]) VALUES (2, N'mose', N'masetloa', N'9202205561082', N'F', 5, N'No', N'gsgsgs', N'45566')
INSERT [dbo].[Survivors] ([ID], [Name], [Surname], [IdNumber], [Gender], [Age], [IsZombi], [Lat], [Long]) VALUES (3, N'moses', N'masa', N'9202205510082', N'M', 40, N'No', N'454455', N'45222')
INSERT [dbo].[Survivors] ([ID], [Name], [Surname], [IdNumber], [Gender], [Age], [IsZombi], [Lat], [Long]) VALUES (4, N'kaka', N'redicras', N'9802105560082', N'M', 60, N'No', N'555', N'02212')
INSERT [dbo].[Survivors] ([ID], [Name], [Surname], [IdNumber], [Gender], [Age], [IsZombi], [Lat], [Long]) VALUES (5, N'Lebo', N'Masetloa', N'9303305560082', N'F', 29, N'No', N'15553', N'455222')
SET IDENTITY_INSERT [dbo].[Survivors] OFF
GO
ALTER TABLE [dbo].[AuditZombiRep] ADD  CONSTRAINT [DF_AuditZombiRep_createdDate]  DEFAULT (getdate()) FOR [createdDate]
GO
ALTER TABLE [dbo].[Survivors] ADD  CONSTRAINT [DF_Survivors_IsZombi]  DEFAULT ('No') FOR [IsZombi]
GO
/****** Object:  StoredProcedure [dbo].[AddSuvivor]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddSuvivor] 
@Name VARCHAR(50),
@Surname VARCHAR(50),
@Age INT,
@IDnumber VARCHAR(13),
@Gender CHAR(1),
@Lat VARCHAR(50),
@Long VARCHAR(50)

As
BEGIN

Set Nocount on
Declare @UserID int

INSERT INTO Survivors (Name,surname,age,IdNumber,gender,Lat,Long) values(@Name,@Surname,@Age,@IDnumber,@Gender,@Lat,@Long)

select @UserID = ID from Survivors where IdNumber = @IDnumber;

Select @UserID as userid

end
GO
/****** Object:  StoredProcedure [dbo].[AddUserResource]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUserResource]
@UserID int,
@Resource VARCHAR(50)


As
BEGIN

INSERT INTO [Resources] (UserID,[Resource]) values(@UserID,@Resource)

end
GO
/****** Object:  StoredProcedure [dbo].[AddZombi]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddZombi] 
@ReporterID int,
@newZombiID int

As
BEGIN

Set Nocount on
Declare @count int

select @count = COUNT(*) from AuditZombiRep  where [reporterID] = @ReporterID and [newZombieID] = @newZombiID

if(@count > 0)
Begin
  select 'you cannot report the zombi twice' as Results 
  return
end
insert into AuditZombiRep ([reporterID],[newZombieID]) values(@ReporterID,@newZombiID)

select @count = COUNT(*) from AuditZombiRep  where  [newZombieID] = @newZombiID

if(@count > 2)
Begin
 update Survivors set IsZombi  ='Yes' where ID = @newZombiID
 Select 'New zombi been reported' as results
 return

end


Select 'New zombi been reported  will update if 3 people report the same person' as results

end
GO
/****** Object:  StoredProcedure [dbo].[AllNonSurvivors]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[AllNonSurvivors]



As
BEGIN

SELECT TOP (1000) [ID]
      ,[Name]
      ,[Surname]
      ,[IdNumber]
      ,[Gender]
      ,[Age]
      ,[IsZombi]
      ,[Lat]
      ,[Long]
  FROM [Survivor].[dbo].[Survivors] where [IsZombi] = 'Yes'

end
GO
/****** Object:  StoredProcedure [dbo].[AllSurvivors]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AllSurvivors]



As
BEGIN

SELECT TOP (1000) [ID]
      ,[Name]
      ,[Surname]
      ,[IdNumber]
      ,[Gender]
      ,[Age]
      ,[IsZombi]
      ,[Lat]
      ,[Long]
  FROM [Survivor].[dbo].[Survivors] where [IsZombi] = 'No'

end
GO
/****** Object:  StoredProcedure [dbo].[FindUserByID]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindUserByID]
@IDnumber varchar(13)


As
BEGIN

Set NoCOunt On;
DECLARE @count Int = 0
DECLARE @IsTrue BIT = 0

Select @count = COUNT(*) from Survivors where IdNumber =@IDnumber 

if(@count > 0)
Begin
  Set @IsTrue =1
end

select @IsTrue as results 
end
GO
/****** Object:  StoredProcedure [dbo].[Percentage]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Percentage] 


As
BEGIN

Set Nocount on
Declare @CountSurvivor int
Declare @CountNonSurvivor int
Declare @Count int

select @CountSurvivor = COUNT(*) from Survivors where IsZombi = 'No'
select @CountNonSurvivor = COUNT(*) from Survivors where IsZombi = 'Yes'
select @Count = COUNT(*) from Survivors 

select @Count as Allcount ,@CountNonSurvivor as NonSurvivor,@CountSurvivor as Survivor 

end
GO
/****** Object:  StoredProcedure [dbo].[UpdateLocation]    Script Date: 2022/02/22 18:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateLocation] 
@UserID int,
@Lat VARCHAR(50),
@Long VARCHAR(50)
As
BEGIN

Set Nocount on

update Survivors set Lat = @Lat , Long =@Long where ID = @UserID


end
GO
USE [master]
GO
ALTER DATABASE [Survivor] SET  READ_WRITE 
GO
