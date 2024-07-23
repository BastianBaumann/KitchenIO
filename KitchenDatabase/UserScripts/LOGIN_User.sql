CREATE PROCEDURE [dbo].[LOGIN_User]
	@Name varchar(50),
	@Password varchar(50)
AS
BEGIN
SELECT Id,Name,Password FROM Users
WHERE Name = @Name AND Password = @Password
END
