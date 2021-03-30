USE [MMTShop]
GO

/****** Object:  StoredProcedure [product].[setProducts]    Script Date: 30/03/2021 21:48:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Chhagan>
-- Create date: <Create Date,,>
-- Description:	<To get Product by category,,>
-- =============================================
CREATE PROCEDURE [product].[setProducts] 
	@name varchar(80),
	@description varchar(max),
	@price smallmoney,
	@categoryId int
AS
BEGIN
	Declare @skubaseNumber int = 10000;
	Declare @numberOfItems int = 0;
	Declare @skuString nvarchar(5) = '';
	select @numberOfItems = count(id) from [product].[productDetail];
	IF (@numberOfItems = 0)
	BEGIN
	  set @skuString = '10000';
	END
	Else
	BEGIN
	 set @skuString = CONVERT(nvarchar(5), @numberOfItems+10000);
	END
	insert into [product].[productDetail] (name, sku, description,price,categoryId) values(@name,  @skuString, @description, @price, @categoryId)
END
GO


