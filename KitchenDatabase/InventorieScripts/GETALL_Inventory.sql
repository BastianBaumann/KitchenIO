﻿CREATE PROCEDURE [dbo].[GETALL_Inventory]
AS
SELECT Id,ProductId,Amount,Weight,EP,Owner  FROM InventorieTable
