USE [master]
GO
/****** Object:  Database [CqrsProduct]    Script Date: 29.10.2023 19:06:12 ******/
CREATE DATABASE [CqrsProduct]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CqrsProduct', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CqrsProduct.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CqrsProduct_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CqrsProduct_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CqrsProduct] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CqrsProduct].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CqrsProduct] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CqrsProduct] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CqrsProduct] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CqrsProduct] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CqrsProduct] SET ARITHABORT OFF 
GO
ALTER DATABASE [CqrsProduct] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CqrsProduct] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CqrsProduct] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CqrsProduct] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CqrsProduct] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CqrsProduct] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CqrsProduct] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CqrsProduct] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CqrsProduct] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CqrsProduct] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CqrsProduct] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CqrsProduct] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CqrsProduct] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CqrsProduct] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CqrsProduct] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CqrsProduct] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CqrsProduct] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CqrsProduct] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CqrsProduct] SET  MULTI_USER 
GO
ALTER DATABASE [CqrsProduct] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CqrsProduct] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CqrsProduct] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CqrsProduct] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CqrsProduct] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CqrsProduct] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CqrsProduct] SET QUERY_STORE = OFF
GO
USE [CqrsProduct]
GO
/****** Object:  Table [dbo].[TableProduct]    Script Date: 29.10.2023 19:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductCode] [nvarchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[Amount] [money] NOT NULL,
 CONSTRAINT [PK_TableProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [CqrsProduct] SET  READ_WRITE 
GO
