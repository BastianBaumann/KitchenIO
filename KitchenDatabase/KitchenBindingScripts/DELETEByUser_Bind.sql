CREATE PROCEDURE [dbo].[DELETEByUser_Bind]
	@UserId uniqueidentifier
AS
	DELETE FROM KitchenBinding
	WHERE UserId = @UserId
