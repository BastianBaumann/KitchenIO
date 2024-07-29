CREATE PROCEDURE [dbo].[INSERT_Inventory]
	@Id uniqueidentifier,
	@ProductID uniqueidentifier,
	@Amount float,
	@EP datetime,
	@Owner uniqueidentifier
AS
INSERT INTO InventorieTable
(Id,ProductID,Amount,EP,Owner)
values
(@Id,@ProductID,@Amount,@EP,@Owner)
