CREATE PROCEDURE [dbo].[UPDATE_Inventory]
	@Id uniqueidentifier,
	@Amount int,
	@Weight decimal,
	@EP DateTime
AS
BEGIN
	UPDATE InventorieTable
	SET Amount = @Amount, Weight = @Weight, EP = @EP
	WHERE Id = @Id;
END