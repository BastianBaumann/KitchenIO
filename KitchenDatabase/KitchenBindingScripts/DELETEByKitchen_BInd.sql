CREATE PROCEDURE [dbo].[DELETEByKitchen_Bind]
	@KitchenId uniqueidentifier
AS
	DELETE FROM KitchenBinding
	WHERE KitchenId = @KitchenId

