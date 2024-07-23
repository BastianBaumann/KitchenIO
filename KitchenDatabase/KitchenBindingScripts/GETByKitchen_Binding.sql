CREATE PROCEDURE [dbo].[GETByKitchen_Binding]
	@KitchenId uniqueidentifier
AS
BEGIN
SELECT Id,UserId,KitchenId FROM KitchenBinding
WHERE KitchenId = @KitchenId
END
