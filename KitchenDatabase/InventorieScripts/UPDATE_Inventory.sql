﻿CREATE PROCEDURE [dbo].[UPDATE_Inventory]
	@Id uniqueidentifier,
	@Amount int,
	@EP DateTime,
	@Owner uniqueidentifier
AS
BEGIN
	UPDATE InventorieTable
	SET Amount = @Amount, EP = @EP, Owner = @Owner
	WHERE Id = @Id;
END