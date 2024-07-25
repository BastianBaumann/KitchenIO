CREATE PROCEDURE [dbo].[GETByUsers_Binding]
	@UserId uniqueidentifier
AS
BEGIN
SELECT Id,UserId,KitchenId FROM KitchenBinding
WHERE UserId = @UserId
END
