CREATE PROCEDURE [dbo].[GETByBarcode_Products]
	@Barcode varchar(50)
AS
BEGIN
SELECT Id,Name,Barcode,Price,Type FROM ProductTable
WHERE Barcode = @Barcode
END
