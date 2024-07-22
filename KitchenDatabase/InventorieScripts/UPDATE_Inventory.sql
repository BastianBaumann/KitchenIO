CREATE PROCEDURE [dbo].[UPDATE_Inventory]
	@Id uniqueidentifier,
	@Amount int,
	@Weight decimal,
	@EP DateTime,
	@Owner uniqueidentifier
AS
BEGIN
	UPDATE InventorieTable
	SET Amount = @Amount, Weight = @Weight, EP = @EP, Owner = @Owner
	WHERE Id = @Id;
END