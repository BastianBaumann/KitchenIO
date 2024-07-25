CREATE PROCEDURE [dbo].[INSERT_Products]
	@Id uniqueidentifier,
	@Name varchar(50),
	@Barcode varchar(50),
	@Price float,
	@Type varchar(50),
	@meassurement varchar(50)
AS
INSERT INTO ProductTable
(Id,Name,Barcode,Price, Type, meassurement)
values
(@Id,@Name,@Barcode,@Price,@Type, @meassurement)