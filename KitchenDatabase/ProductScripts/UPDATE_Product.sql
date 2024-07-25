CREATE PROCEDURE [dbo].[UPDATE_Product]
	@Id uniqueidentifier,
	@Name varchar(50),
	@Barcode int,
	@Price decimal,
	@Type varchar(50),
	@meassurement varchar(50)
AS
BEGIN
	UPDATE ProductTable
	SET Name = @Name, Barcode = @Barcode, Price = @Price, Type = @Type , meassurement = @meassurement
	WHERE Id = @Id;
END