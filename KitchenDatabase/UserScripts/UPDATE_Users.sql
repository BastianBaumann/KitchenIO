CREATE PROCEDURE [dbo].[UPDATE_Users]
	@Id uniqueidentifier,
	@Name varchar(50),
	@Password varchar(50),
	@Allergies varchar(MAX)
AS
BEGIN
	UPDATE Users
	SET Name = @Name, Password = @Password, Allergies = @Allergies
	WHERE Id = @Id;
END
