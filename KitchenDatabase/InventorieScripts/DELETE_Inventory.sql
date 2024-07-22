CREATE PROCEDURE [dbo].[DELETE_Inventory]
	@Id uniqueidentifier
AS
	DELETE FROM InventorieTable
	WHERE Id = @Id