CREATE PROCEDURE [dbo].[GETByBarcode_Products]
	@Barcode varchar(50)
AS
BEGIN
SELECT Id,Name,Barcode,Price,Type,meassurement FROM ProductTable
WHERE Barcode = @Barcode
END
