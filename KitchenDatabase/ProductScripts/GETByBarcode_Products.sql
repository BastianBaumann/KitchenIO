CREATE PROCEDURE [dbo].[GETByBarcode_Products]
	@Barcode int
AS
BEGIN
SELECT Id,Name,Barcode,Price,Type FROM ProductTable
WHERE Barcode = @Barcode
END
