﻿CREATE PROCEDURE [dbo].[GETALLByOwner_Inventory]
	@Owner uniqueidentifier
AS
BEGIN
SELECT Id,ProductID,Amount,EP,Owner FROM InventorieTable
WHERE Owner = @Owner
END