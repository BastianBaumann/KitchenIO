CREATE PROCEDURE [dbo].[DELETE_Kitchen]
	@Id uniqueidentifier
AS
	DELETE FROM KitchenTable
	WHERE Id = @Id
