CREATE PROCEDURE [dbo].[GETALL_Products]
AS
SELECT Id,Name,Barcode,Price,Type FROM ProductTable