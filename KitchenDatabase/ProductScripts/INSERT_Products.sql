CREATE PROCEDURE [dbo].[INSERT_Products]
	@Id uniqueidentifier,
	@Name varchar(50),
	@Barcode varchar(50),
	@Price float,
	@Type int
AS
INSERT INTO ProductTable
(Id,Name,Barcode,Price, Type)
values
(@Id,@Name,@Barcode,@Price,@Type)