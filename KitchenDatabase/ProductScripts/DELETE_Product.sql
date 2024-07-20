CREATE PROCEDURE [dbo].[DELETE_Product]
	@Id uniqueidentifier
AS
	DELETE FROM ProductTable
	WHERE Id = @Id

