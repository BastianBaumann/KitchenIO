CREATE PROCEDURE [dbo].[DELETEByUser_Bind]
	@UserId uniqueidentifier,
	@KitchenId uniqueidentifier
AS
	DELETE FROM KitchenBinding
	WHERE UserId = @UserId AND KitchenId = @KitchenId
