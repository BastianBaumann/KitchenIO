﻿CREATE PROCEDURE [dbo].[INSERT_Inventory]
	@Id uniqueidentifier,
	@ProductID uniqueidentifier,
	@Amount float,
	@Weight float,
	@EP datetime,
	@Owner uniqueidentifier
AS
INSERT INTO InventorieTable
(Id,ProductID,Amount,Weight,EP,Owner)
values
(@Id,@ProductID,@Amount,@Weight,@EP,@Owner)
