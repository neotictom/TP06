USE [Elecciones]
GO
/****** Object:  Table [dbo].[Candidato]    Script Date: 31/7/2023 09:57:18 ******/
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
/****** Object:  Table [dbo].[Partido]    Script Date: 31/7/2023 09:57:18 ******/
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
INSERT [dbo].[Partido] ([IdPartido], [Nombre], [Logo], [Sitioweb], [Fechafundacion], [Cantidaddiputados], [Cantidadsenadores]) VALUES (3357, N'Cañetismo Popular Zurdo', N'cañete.png', N'ok', CAST(N'2023-06-26' AS Date), 30, 10)
INSERT [dbo].[Partido] ([IdPartido], [Nombre], [Logo], [Sitioweb], [Fechafundacion], [Cantidaddiputados], [Cantidadsenadores]) VALUES (4252, N'Libertad Cañete', N'logo2.jfif', N'cañetismoavanza.com.org', CAST(N'2023-07-31' AS Date), 20, 8)
INSERT [dbo].[Partido] ([IdPartido], [Nombre], [Logo], [Sitioweb], [Fechafundacion], [Cantidaddiputados], [Cantidadsenadores]) VALUES (7422, N'9z', N'9z.jfif', N'9z.com', CAST(N'2018-08-08' AS Date), 10, 3)
GO
ALTER TABLE [dbo].[Candidato]  WITH CHECK ADD  CONSTRAINT [FK_Candidato_Partido] FOREIGN KEY([IdPartido])
REFERENCES [dbo].[Partido] ([IdPartido])
GO
ALTER TABLE [dbo].[Candidato] CHECK CONSTRAINT [FK_Candidato_Partido]
GO
