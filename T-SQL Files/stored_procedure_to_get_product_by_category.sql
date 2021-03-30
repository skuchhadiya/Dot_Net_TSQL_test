USE [MMTShop]
GO

/****** Object:  StoredProcedure [product].[getProducts]    Script Date: 30/03/2021 21:48:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Chhagan>
-- Create date: <Create Date,,>
-- Description:	<To get Product by category,,>
-- =============================================
CREATE PROCEDURE [product].[getProducts] 
	@categoryId int
AS
BEGIN
	SELECT * from [product].[productDetail] where categoryId = @categoryId 
END
GO


