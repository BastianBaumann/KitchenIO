CREATE PROCEDURE [dbo].[GETALL_Inventory]
AS
SELECT Id,ProductId,Amount,EP,Owner  FROM InventorieTable
