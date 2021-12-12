USE [master]
GO
/****** Object:  Database [PastryShop]    Script Date: 12/12/2021 22:08:32 ******/
CREATE DATABASE [PastryShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PastryShop', FILENAME = N'C:\Users\shaol\PastryShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PastryShop_log', FILENAME = N'C:\Users\shaol\PastryShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PastryShop] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PastryShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PastryShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PastryShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PastryShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PastryShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PastryShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [PastryShop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PastryShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PastryShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PastryShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PastryShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PastryShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PastryShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PastryShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PastryShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PastryShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PastryShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PastryShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PastryShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PastryShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PastryShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PastryShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PastryShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PastryShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PastryShop] SET  MULTI_USER 
GO
ALTER DATABASE [PastryShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PastryShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PastryShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PastryShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PastryShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PastryShop] SET QUERY_STORE = OFF
GO
USE [PastryShop]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [PastryShop]
GO
/****** Object:  Table [dbo].[Dolce]    Script Date: 12/12/2021 22:08:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dolce](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](80) NOT NULL,
	[Prezzo] [numeric](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DolciInVendita]    Script Date: 12/12/2021 22:08:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DolciInVendita](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDolce] [int] NOT NULL,
	[Disponibilita] [int] NULL,
	[DataMessaInVendita] [datetime] NULL,
	[Scaduto] [bit] NULL,
 CONSTRAINT [PK_DolciInVendita] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingrediente]    Script Date: 12/12/2021 22:08:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingrediente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NULL,
	[Um] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredientiDolce]    Script Date: 12/12/2021 22:08:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredientiDolce](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDolce] [int] NOT NULL,
	[IdIngrediente] [int] NOT NULL,
	[Quantita] [decimal](18, 0) NULL,
 CONSTRAINT [PK_IngredientiDolce] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Um]    Script Date: 12/12/2021 22:08:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Um](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sigla] [nvarchar](5) NULL,
	[NomeCompleto] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 12/12/2021 22:08:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Utente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dolce] ON 
GO
INSERT [dbo].[Dolce] ([Id], [Nome], [Prezzo]) VALUES (1, N'Torta Random', CAST(11.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Dolce] ([Id], [Nome], [Prezzo]) VALUES (2, N'Torta della nonna', CAST(10.80 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Dolce] OFF
GO
SET IDENTITY_INSERT [dbo].[DolciInVendita] ON 
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (1, 1, 17, CAST(N'2021-12-06T02:37:12.047' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (2, 1, 10, CAST(N'2021-12-05T02:41:14.080' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (3, 2, 0, CAST(N'2021-12-06T22:42:10.627' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (2002, 2, 12, CAST(N'2021-12-04T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (2003, 1, 90, CAST(N'2021-12-09T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (2004, 2, 50, CAST(N'2021-12-09T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (2006, 1, 0, CAST(N'2021-12-09T10:28:59.603' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (2007, 1, 0, CAST(N'2021-12-09T10:32:19.720' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (2008, 1, 0, CAST(N'2021-12-09T10:34:45.697' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (2009, 1, 40, CAST(N'2021-12-09T10:35:28.970' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (3005, 1, 0, CAST(N'2021-12-09T11:51:33.330' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (4004, 1, 20, CAST(N'2021-12-09T17:16:47.633' AS DateTime), 1)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (4005, 2, 4, CAST(N'2021-12-09T19:54:34.503' AS DateTime), 0)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (4008, 1, 33, CAST(N'2021-12-09T19:57:05.880' AS DateTime), 0)
GO
INSERT [dbo].[DolciInVendita] ([Id], [IdDolce], [Disponibilita], [DataMessaInVendita], [Scaduto]) VALUES (5009, 1, 10, CAST(N'2021-12-12T02:06:46.203' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[DolciInVendita] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingrediente] ON 
GO
INSERT [dbo].[Ingrediente] ([Id], [Nome], [Um]) VALUES (1, N'Farina', 4)
GO
INSERT [dbo].[Ingrediente] ([Id], [Nome], [Um]) VALUES (2, N'Uovo', 5)
GO
INSERT [dbo].[Ingrediente] ([Id], [Nome], [Um]) VALUES (3, N'Zucchero', 4)
GO
INSERT [dbo].[Ingrediente] ([Id], [Nome], [Um]) VALUES (4, N'Mascarpone', 4)
GO
INSERT [dbo].[Ingrediente] ([Id], [Nome], [Um]) VALUES (5, N'Lievito', 4)
GO
INSERT [dbo].[Ingrediente] ([Id], [Nome], [Um]) VALUES (6, N'Burro', 4)
GO
INSERT [dbo].[Ingrediente] ([Id], [Nome], [Um]) VALUES (7, N'Latte', 3)
GO
INSERT [dbo].[Ingrediente] ([Id], [Nome], [Um]) VALUES (1005, N'Sale', 6)
GO
INSERT [dbo].[Ingrediente] ([Id], [Nome], [Um]) VALUES (1006, N'Savoiardi', 4)
GO
SET IDENTITY_INSERT [dbo].[Ingrediente] OFF
GO
SET IDENTITY_INSERT [dbo].[IngredientiDolce] ON 
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (2, 1, 3, CAST(210 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (5, 2, 1, CAST(250 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (6, 2, 2, CAST(3 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (7, 2, 3, CAST(120 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (8, 2, 5, CAST(16 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (9, 2, 6, CAST(110 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (10, 2, 1005, CAST(1 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (2022, 1, 2, CAST(3 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (2023, 1, 4, CAST(795 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (3018, 1, 1, CAST(250 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (3019, 1, 5, CAST(15 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (3020, 1, 6, CAST(115 AS Decimal(18, 0)))
GO
INSERT [dbo].[IngredientiDolce] ([Id], [IdDolce], [IdIngrediente], [Quantita]) VALUES (3022, 1, 1005, CAST(100 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[IngredientiDolce] OFF
GO
SET IDENTITY_INSERT [dbo].[Um] ON 
GO
INSERT [dbo].[Um] ([Id], [Sigla], [NomeCompleto]) VALUES (1, N'l', N'Litro')
GO
INSERT [dbo].[Um] ([Id], [Sigla], [NomeCompleto]) VALUES (2, N'dl', N'Decilitro')
GO
INSERT [dbo].[Um] ([Id], [Sigla], [NomeCompleto]) VALUES (3, N'ml', N'Millilitro')
GO
INSERT [dbo].[Um] ([Id], [Sigla], [NomeCompleto]) VALUES (4, N'gr', N'Grammo')
GO
INSERT [dbo].[Um] ([Id], [Sigla], [NomeCompleto]) VALUES (5, N'pz', N'Pezzo')
GO
INSERT [dbo].[Um] ([Id], [Sigla], [NomeCompleto]) VALUES (6, N'Piz', N'Pizzico')
GO
SET IDENTITY_INSERT [dbo].[Um] OFF
GO
SET IDENTITY_INSERT [dbo].[Utente] ON 
GO
INSERT [dbo].[Utente] ([Id], [Nome], [Username], [Password]) VALUES (1, N'Luana', N'lulu', N'lu70')
GO
INSERT [dbo].[Utente] ([Id], [Nome], [Username], [Password]) VALUES (2, N'Maria', N'mary', N'm123')
GO
SET IDENTITY_INSERT [dbo].[Utente] OFF
GO
ALTER TABLE [dbo].[DolciInVendita] ADD  CONSTRAINT [DF_DolciInVendita_Scaduto]  DEFAULT ((0)) FOR [Scaduto]
GO
ALTER TABLE [dbo].[DolciInVendita]  WITH CHECK ADD  CONSTRAINT [FK_DolciInVendita_Dolce] FOREIGN KEY([IdDolce])
REFERENCES [dbo].[Dolce] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DolciInVendita] CHECK CONSTRAINT [FK_DolciInVendita_Dolce]
GO
ALTER TABLE [dbo].[Ingrediente]  WITH CHECK ADD  CONSTRAINT [FK_Ingrediente_Um] FOREIGN KEY([Um])
REFERENCES [dbo].[Um] ([Id])
GO
ALTER TABLE [dbo].[Ingrediente] CHECK CONSTRAINT [FK_Ingrediente_Um]
GO
ALTER TABLE [dbo].[IngredientiDolce]  WITH CHECK ADD  CONSTRAINT [FK_IngredientiDolce_Dolce] FOREIGN KEY([IdDolce])
REFERENCES [dbo].[Dolce] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IngredientiDolce] CHECK CONSTRAINT [FK_IngredientiDolce_Dolce]
GO
ALTER TABLE [dbo].[IngredientiDolce]  WITH CHECK ADD  CONSTRAINT [FK_IngredientiDolce_Ingrediente] FOREIGN KEY([IdIngrediente])
REFERENCES [dbo].[Ingrediente] ([Id])
GO
ALTER TABLE [dbo].[IngredientiDolce] CHECK CONSTRAINT [FK_IngredientiDolce_Ingrediente]
GO
USE [master]
GO
ALTER DATABASE [PastryShop] SET  READ_WRITE 
GO
