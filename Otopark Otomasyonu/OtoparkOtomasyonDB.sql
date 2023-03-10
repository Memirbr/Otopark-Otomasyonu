USE [otopark]
GO
/****** Object:  Table [dbo].[aracdurum]    Script Date: 12.12.2022 03:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aracdurum](
	[parkyeri] [nvarchar](50) NULL,
	[durum] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[markabilgi]    Script Date: 12.12.2022 03:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[markabilgi](
	[marka] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[musteri]    Script Date: 12.12.2022 03:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[musteri](
	[Plaka] [nvarchar](50) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[tel] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[tc] [nvarchar](50) NULL,
	[marka] [nvarchar](50) NULL,
	[seri] [nvarchar](50) NULL,
	[renk] [nvarchar](50) NULL,
	[parkyeri] [nvarchar](50) NULL,
	[tarih] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[satis]    Script Date: 12.12.2022 03:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[satis](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[parkyeri] [nvarchar](50) NOT NULL,
	[Plaka] [nvarchar](50) NOT NULL,
	[geliş_tarihi] [nvarchar](50) NOT NULL,
	[çıkış_tarihi] [nvarchar](50) NOT NULL,
	[süre] [decimal](18, 2) NOT NULL,
	[tutar] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_satis] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seribilgi]    Script Date: 12.12.2022 03:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seribilgi](
	[marka] [nvarchar](50) NULL,
	[seri] [nvarchar](50) NULL
) ON [PRIMARY]
GO
