USE [stokTakip]
GO
/****** Object:  Table [dbo].[kategoriler]    Script Date: 17.02.2022 12:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kategoriler](
	[kategoriId] [smallint] IDENTITY(1,1) NOT NULL,
	[kategoriAd] [varchar](50) NULL,
 CONSTRAINT [PK_kategoriler] PRIMARY KEY CLUSTERED 
(
	[kategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[musteriler]    Script Date: 17.02.2022 12:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[musteriler](
	[musteriId] [int] IDENTITY(1,1) NOT NULL,
	[musteriAd] [varchar](50) NULL,
	[musteriSoyad] [varchar](50) NULL,
 CONSTRAINT [PK_musteri] PRIMARY KEY CLUSTERED 
(
	[musteriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[satislar]    Script Date: 17.02.2022 12:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[satislar](
	[satisId] [int] IDENTITY(1,1) NOT NULL,
	[urunId] [int] NULL,
	[musteriId] [int] NULL,
	[adet] [tinyint] NULL,
	[satisFiyat] [decimal](18, 2) NULL,
 CONSTRAINT [PK_satislar] PRIMARY KEY CLUSTERED 
(
	[satisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[urunler]    Script Date: 17.02.2022 12:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[urunler](
	[urunId] [int] IDENTITY(1,1) NOT NULL,
	[urunAd] [varchar](80) NULL,
	[urunMarkaAd] [varchar](50) NULL,
	[urunKategori] [smallint] NULL,
	[urunFiyat] [decimal](18, 2) NULL,
	[urunStok] [tinyint] NULL,
 CONSTRAINT [PK_urunler] PRIMARY KEY CLUSTERED 
(
	[urunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[satislar]  WITH CHECK ADD  CONSTRAINT [FK_satislar_musteriler] FOREIGN KEY([musteriId])
REFERENCES [dbo].[musteriler] ([musteriId])
GO
ALTER TABLE [dbo].[satislar] CHECK CONSTRAINT [FK_satislar_musteriler]
GO
ALTER TABLE [dbo].[satislar]  WITH CHECK ADD  CONSTRAINT [FK_satislar_urunler] FOREIGN KEY([urunId])
REFERENCES [dbo].[urunler] ([urunId])
GO
ALTER TABLE [dbo].[satislar] CHECK CONSTRAINT [FK_satislar_urunler]
GO
ALTER TABLE [dbo].[urunler]  WITH CHECK ADD  CONSTRAINT [FK_urunler_kategoriler] FOREIGN KEY([urunKategori])
REFERENCES [dbo].[kategoriler] ([kategoriId])
GO
ALTER TABLE [dbo].[urunler] CHECK CONSTRAINT [FK_urunler_kategoriler]
GO
