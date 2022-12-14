USE [master]
GO
/****** Object:  Database [test2]    Script Date: 22.08.2022 22:04:54 ******/
CREATE DATABASE [test2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'test2', FILENAME = N'C:\Program Files (x86)\MSSQL15.MSSQLSERVER\MSSQL\DATA\test2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'test2_log', FILENAME = N'C:\Program Files (x86)\MSSQL15.MSSQLSERVER\MSSQL\DATA\test2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [test2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [test2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [test2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [test2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [test2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [test2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [test2] SET ARITHABORT OFF 
GO
ALTER DATABASE [test2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [test2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [test2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [test2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [test2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [test2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [test2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [test2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [test2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [test2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [test2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [test2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [test2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [test2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [test2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [test2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [test2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [test2] SET RECOVERY FULL 
GO
ALTER DATABASE [test2] SET  MULTI_USER 
GO
ALTER DATABASE [test2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [test2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [test2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [test2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [test2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [test2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'test2', N'ON'
GO
ALTER DATABASE [test2] SET QUERY_STORE = OFF
GO
USE [test2]
GO
/****** Object:  Table [dbo].[DocService]    Script Date: 22.08.2022 22:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocService](
	[doctor_id] [numeric](6, 0) NOT NULL,
	[service_id] [numeric](6, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 22.08.2022 22:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[doctor_id] [numeric](6, 0) IDENTITY(1,1) NOT NULL,
	[doctor_name] [varchar](50) NOT NULL,
	[doctor_login] [varchar](20) NOT NULL,
	[doctor_pass] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[doctor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnerDoc]    Script Date: 22.08.2022 22:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnerDoc](
	[owner_id] [numeric](6, 0) NOT NULL,
	[doctor_id] [numeric](6, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owners]    Script Date: 22.08.2022 22:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owners](
	[owner_id] [numeric](6, 0) IDENTITY(1,1) NOT NULL,
	[owner_name] [varchar](50) NOT NULL,
	[owner_login] [varchar](20) NOT NULL,
	[owner_pass] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[owner_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnService]    Script Date: 22.08.2022 22:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnService](
	[owner_id] [numeric](6, 0) NOT NULL,
	[service_id] [numeric](6, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pets]    Script Date: 22.08.2022 22:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pets](
	[pet_id] [numeric](6, 0) IDENTITY(1,1) NOT NULL,
	[pet_name] [varchar](50) NOT NULL,
	[pet_type] [varchar](20) NOT NULL,
	[pet_owner_id] [numeric](6, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 22.08.2022 22:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[service_id] [numeric](6, 0) IDENTITY(1,1) NOT NULL,
	[service_name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vaccinations]    Script Date: 22.08.2022 22:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vaccinations](
	[vac_id] [numeric](6, 0) IDENTITY(1,1) NOT NULL,
	[vac_name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[vac_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VacPet]    Script Date: 22.08.2022 22:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VacPet](
	[vac_id] [numeric](6, 0) NOT NULL,
	[pet_id] [numeric](6, 0) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DocService]  WITH CHECK ADD  CONSTRAINT [_doctor_id] FOREIGN KEY([doctor_id])
REFERENCES [dbo].[Doctors] ([doctor_id])
GO
ALTER TABLE [dbo].[DocService] CHECK CONSTRAINT [_doctor_id]
GO
ALTER TABLE [dbo].[DocService]  WITH CHECK ADD  CONSTRAINT [_service_id] FOREIGN KEY([service_id])
REFERENCES [dbo].[Services] ([service_id])
GO
ALTER TABLE [dbo].[DocService] CHECK CONSTRAINT [_service_id]
GO
ALTER TABLE [dbo].[OwnerDoc]  WITH CHECK ADD  CONSTRAINT [_doctor] FOREIGN KEY([doctor_id])
REFERENCES [dbo].[Doctors] ([doctor_id])
GO
ALTER TABLE [dbo].[OwnerDoc] CHECK CONSTRAINT [_doctor]
GO
ALTER TABLE [dbo].[OwnerDoc]  WITH CHECK ADD  CONSTRAINT [_owner_id] FOREIGN KEY([owner_id])
REFERENCES [dbo].[Owners] ([owner_id])
GO
ALTER TABLE [dbo].[OwnerDoc] CHECK CONSTRAINT [_owner_id]
GO
ALTER TABLE [dbo].[OwnService]  WITH CHECK ADD  CONSTRAINT [__owner_id] FOREIGN KEY([owner_id])
REFERENCES [dbo].[Owners] ([owner_id])
GO
ALTER TABLE [dbo].[OwnService] CHECK CONSTRAINT [__owner_id]
GO
ALTER TABLE [dbo].[OwnService]  WITH CHECK ADD  CONSTRAINT [__service_id] FOREIGN KEY([service_id])
REFERENCES [dbo].[Services] ([service_id])
GO
ALTER TABLE [dbo].[OwnService] CHECK CONSTRAINT [__service_id]
GO
ALTER TABLE [dbo].[Pets]  WITH CHECK ADD  CONSTRAINT [_owner] FOREIGN KEY([pet_owner_id])
REFERENCES [dbo].[Owners] ([owner_id])
GO
ALTER TABLE [dbo].[Pets] CHECK CONSTRAINT [_owner]
GO
ALTER TABLE [dbo].[VacPet]  WITH CHECK ADD  CONSTRAINT [_pet] FOREIGN KEY([pet_id])
REFERENCES [dbo].[Pets] ([pet_id])
GO
ALTER TABLE [dbo].[VacPet] CHECK CONSTRAINT [_pet]
GO
ALTER TABLE [dbo].[VacPet]  WITH CHECK ADD  CONSTRAINT [_vac] FOREIGN KEY([vac_id])
REFERENCES [dbo].[Vaccinations] ([vac_id])
GO
ALTER TABLE [dbo].[VacPet] CHECK CONSTRAINT [_vac]
GO
USE [master]
GO
ALTER DATABASE [test2] SET  READ_WRITE 
GO
