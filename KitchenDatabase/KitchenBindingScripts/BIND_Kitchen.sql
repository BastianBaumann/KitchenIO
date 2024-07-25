CREATE PROCEDURE [dbo].[BIND_Kitchen]
	@UserId uniqueidentifier,
	@KitchenId uniqueidentifier
AS
INSERT INTO KitchenBinding
(Id,UserID,KitchenID)
values
(NEWID(),@UserID,@KitchenID)
