USE [master]
GO
/****** Object:  Database [CrawlDB]    Script Date: 2/5/2015 12:31:18 AM ******/
CREATE DATABASE [CrawlDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CrawlDB', FILENAME = N'C:\Data\MSSQL11.MSSQLSERVER\MSSQL\DATA\CrawlDB.mdf' , SIZE = 820224KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CrawlDB_log', FILENAME = N'C:\Data\MSSQL11.MSSQLSERVER\MSSQL\DATA\CrawlDB_log.ldf' , SIZE = 43200KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CrawlDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CrawlDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CrawlDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CrawlDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CrawlDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CrawlDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CrawlDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CrawlDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CrawlDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CrawlDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CrawlDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CrawlDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CrawlDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CrawlDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CrawlDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CrawlDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CrawlDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CrawlDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CrawlDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CrawlDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CrawlDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CrawlDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CrawlDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CrawlDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CrawlDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CrawlDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CrawlDB] SET  MULTI_USER 
GO
ALTER DATABASE [CrawlDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CrawlDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CrawlDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CrawlDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CrawlDB]
GO
/****** Object:  User [CrawlAcct]    Script Date: 2/5/2015 12:31:18 AM ******/
CREATE USER [CrawlAcct] FOR LOGIN [CrawlAcct] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [CrawlAcct]
GO
/****** Object:  FullTextCatalog [CrawlIndex]    Script Date: 2/5/2015 12:31:18 AM ******/
CREATE FULLTEXT CATALOG [CrawlIndex]WITH ACCENT_SENSITIVITY = OFF

GO
/****** Object:  PartitionFunction [ifts_comp_fragment_partition_function_286302EC]    Script Date: 2/5/2015 12:31:18 AM ******/
CREATE PARTITION FUNCTION [ifts_comp_fragment_partition_function_286302EC](varbinary(128)) AS RANGE LEFT FOR VALUES (0x006700690066)
GO
/****** Object:  PartitionScheme [ifts_comp_fragment_data_space_286302EC]    Script Date: 2/5/2015 12:31:18 AM ******/
CREATE PARTITION SCHEME [ifts_comp_fragment_data_space_286302EC] AS PARTITION [ifts_comp_fragment_partition_function_286302EC] TO ([PRIMARY], [PRIMARY])
GO
/****** Object:  UserDefinedTableType [dbo].[StringArray]    Script Date: 2/5/2015 12:31:18 AM ******/
CREATE TYPE [dbo].[StringArray] AS TABLE(
	[string] [varchar](2083) NOT NULL
)
GO
/****** Object:  StoredProcedure [dbo].[PageExists]    Script Date: 2/5/2015 12:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PageExists] 
	-- Add the parameters for the stored procedure here
	@URI nvarchar(2083)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1 pm.ID
	FROM PageMetadata pm
	WHERE pm.Uri = @URI
END



GO
/****** Object:  StoredProcedure [dbo].[SaveLinks]    Script Date: 2/5/2015 12:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SaveLinks] 
	-- Add the parameters for the stored procedure here
	@id bigint,
	@urls StringArray READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM PageLinks WHERE ParentPageID = @id;

    -- Insert statements for procedure here
	INSERT INTO PageLinks (ParentPageID, Uri)
	SELECT @id as ParentPageID, u.string as Uri FROM @urls u
END



GO
/****** Object:  Table [dbo].[PageContents]    Script Date: 2/5/2015 12:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageContents](
	[ID] [bigint] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PageContents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PageLinks]    Script Date: 2/5/2015 12:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageLinks](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentPageID] [bigint] NOT NULL,
	[Uri] [nvarchar](2083) NOT NULL,
 CONSTRAINT [PK_PageLinks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PageMetadata]    Script Date: 2/5/2015 12:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PageMetadata](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Bytes] [varbinary](8000) NULL,
	[Charset] [varchar](50) NULL,
	[Encoding] [varchar](50) NULL,
	[Uri] [nvarchar](2083) NOT NULL,
	[ParentUri] [nvarchar](2083) NOT NULL,
 CONSTRAINT [PK_PageMetadata] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [CrawlDB] SET  READ_WRITE 
GO
