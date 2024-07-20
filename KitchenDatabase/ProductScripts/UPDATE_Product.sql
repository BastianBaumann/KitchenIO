CREATE PROCEDURE [dbo].[UPDATE_Product]
	@Id uniqueidentifier,
	@Name varchar(50),
	@Barcode int,
	@Price decimal,
	@Type int
AS
BEGIN
	UPDATE ProductTable
	SET Name = @Name, Barcode = @Barcode, Price = @Price, Type = @Type 
	WHERE Id = @Id;
END