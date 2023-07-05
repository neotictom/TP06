USE [master]
GO
/****** Object:  Database [Elecciones]    Script Date: 26/6/2023 09:47:59 ******/
CREATE DATABASE [Elecciones]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Elecciones', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Elecciones.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Elecciones_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Elecciones_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Elecciones] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Elecciones].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Elecciones] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Elecciones] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Elecciones] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Elecciones] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Elecciones] SET ARITHABORT OFF 
GO
ALTER DATABASE [Elecciones] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Elecciones] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Elecciones] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Elecciones] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Elecciones] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Elecciones] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Elecciones] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Elecciones] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Elecciones] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Elecciones] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Elecciones] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Elecciones] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Elecciones] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Elecciones] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Elecciones] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Elecciones] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Elecciones] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Elecciones] SET RECOVERY FULL 
GO
ALTER DATABASE [Elecciones] SET  MULTI_USER 
GO
ALTER DATABASE [Elecciones] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Elecciones] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Elecciones] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Elecciones] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Elecciones] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Elecciones', N'ON'
GO
ALTER DATABASE [Elecciones] SET QUERY_STORE = OFF
GO
USE [Elecciones]
GO
/****** Object:  User [alumno]    Script Date: 26/6/2023 09:48:00 ******/

/****** Object:  Table [dbo].[Candidato]    Script Date: 26/6/2023 09:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidato](
	[IdCandidato] [int] NOT NULL,
	[IdPartido] [int] NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Fechanacimiento] [date] NOT NULL,
	[Foto] [varchar](50) NULL,
	[Postulacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Candidato] PRIMARY KEY CLUSTERED 
(
	[IdCandidato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partido]    Script Date: 26/6/2023 09:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partido](
	[IdPartido] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Logo] [varchar](50) NULL,
	[Sitioweb] [varchar](50) NULL,
	[Fechafundacion] [date] NOT NULL,
	[Cantidaddiputados] [int] NOT NULL,
	[Cantidadsenadores] [int] NOT NULL,
 CONSTRAINT [PK_Partido] PRIMARY KEY CLUSTERED 
(
	[IdPartido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Candidato] ([IdCandidato], [IdPartido], [Apellido], [Nombre], [Fechanacimiento], [Foto], [Postulacion]) VALUES (45080481, NULL, N'Cañete', N'Santiago', CAST(N'2006-07-25' AS Date), N'ok', N'ete sech')
GO
INSERT [dbo].[Partido] ([IdPartido], [Nombre], [Logo], [Sitioweb], [Fechafundacion], [Cantidaddiputados], [Cantidadsenadores]) VALUES (3357, N'Cañetismo Popular Zurdo', N'ok', N'ok', CAST(N'2023-06-26' AS Date), 30, 10)
GO
ALTER TABLE [dbo].[Candidato]  WITH CHECK ADD  CONSTRAINT [FK_Candidato_Partido] FOREIGN KEY([IdPartido])
REFERENCES [dbo].[Partido] ([IdPartido])
GO
ALTER TABLE [dbo].[Candidato] CHECK CONSTRAINT [FK_Candidato_Partido]
GO
USE [master]
GO
ALTER DATABASE [Elecciones] SET  READ_WRITE 
GO
