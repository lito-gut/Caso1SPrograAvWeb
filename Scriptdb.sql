USE [master]
GO

CREATE DATABASE [CasoEstudio]
GO

USE [CasoEstudio]
GO

CREATE TABLE [dbo].[Estudiantes](
	[Consecutivo] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Monto] [decimal](10, 2) NOT NULL,
	[TipoCurso] [int] NOT NULL,
 CONSTRAINT [PK_Estudiantes] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TiposCursos](
	[TipoCurso] [int] NOT NULL,
	[DescripcionTipoCurso] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposCursos] PRIMARY KEY CLUSTERED 
(
	[TipoCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[TiposCursos] ([TipoCurso], [DescripcionTipoCurso]) VALUES (1, N'Programaci�n')
GO
INSERT [dbo].[TiposCursos] ([TipoCurso], [DescripcionTipoCurso]) VALUES (2, N'Cocina')
GO
INSERT [dbo].[TiposCursos] ([TipoCurso], [DescripcionTipoCurso]) VALUES (3, N'Religi�n')
GO
INSERT [dbo].[TiposCursos] ([TipoCurso], [DescripcionTipoCurso]) VALUES (4, N'Manualidades')
GO
INSERT [dbo].[TiposCursos] ([TipoCurso], [DescripcionTipoCurso]) VALUES (5, N'Mec�nica')
GO

ALTER TABLE [dbo].[Estudiantes]  WITH CHECK ADD  CONSTRAINT [FK_Estudiantes_TiposCursos] FOREIGN KEY([TipoCurso])
REFERENCES [dbo].[TiposCursos] ([TipoCurso])
GO
ALTER TABLE [dbo].[Estudiantes] CHECK CONSTRAINT [FK_Estudiantes_TiposCursos]
GO