CREATE PROCEDURE [dbo].[UPDATE_Kitchen]
	@Id uniqueidentifier,
	@Name varchar(50),
	@Description varchar(MAX)
AS
BEGIN
	UPDATE KitchenTable
	SET Name = @Name, Description = @Description
	WHERE Id = @Id;
END