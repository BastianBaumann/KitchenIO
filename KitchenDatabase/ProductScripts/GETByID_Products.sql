CREATE PROCEDURE [dbo].[GETByID_Products]
	@Id uniqueidentifier
AS
BEGIN
SELECT Id,Name,Barcode,Price,Type FROM ProductTable
WHERE Id = @Id
END