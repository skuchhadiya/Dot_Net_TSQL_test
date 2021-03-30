USE [MMTShop]
GO

/****** Object:  Table [product].[productDetail]    Script Date: 30/03/2021 21:47:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [product].[productDetail](
	[id] [int] IDENTITY(10000,1) NOT NULL,
	[name] [varchar](80) NOT NULL,
	[sku] [nvarchar](5) NOT NULL,
	[description] [varchar](max) NULL,
	[price] [smallmoney] NOT NULL,
	[categoryId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [product].[productDetail]  WITH CHECK ADD  CONSTRAINT [FK_categoryDetail] FOREIGN KEY([categoryId])
REFERENCES [category].[categoryDetail] ([id])
GO

ALTER TABLE [product].[productDetail] CHECK CONSTRAINT [FK_categoryDetail]
GO


