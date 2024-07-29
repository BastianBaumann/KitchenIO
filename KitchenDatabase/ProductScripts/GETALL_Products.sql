CREATE PROCEDURE [dbo].[GETALL_Products]
AS
SELECT Id,Name,Barcode,Price,Type,meassurement FROM ProductTable