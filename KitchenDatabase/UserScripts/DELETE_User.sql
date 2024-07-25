CREATE PROCEDURE [dbo].[DELETE_User]
	@Id uniqueidentifier
AS
	DELETE FROM Users
	WHERE Id = @Id
