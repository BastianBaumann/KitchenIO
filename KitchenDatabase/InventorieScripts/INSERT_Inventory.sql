CREATE PROCEDURE [dbo].[INSERT_Inventory]
	@Id uniqueidentifier,
	@ProductID uniqueidentifier,
	@Amount float,
	@Weight float,
	@EP datetime
AS
INSERT INTO InventorieTable
(Id,ProductID,Amount,Weight,EP)
values
(@Id,@ProductID,@Amount,@Weight,@EP)
