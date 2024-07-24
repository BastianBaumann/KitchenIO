CREATE PROCEDURE [dbo].[GETById_Kitchen]
	@KitchenId uniqueidentifier
AS
SELECT Id,Name,Description FROM KitchenTable
WHERE Id = @KitchenId