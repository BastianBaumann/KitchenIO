CREATE PROCEDURE [dbo].[LOGIN_User]
    @Name varchar(50),
    @Password varchar(50)
AS
BEGIN
    SELECT Id, Name, Password, Allergies FROM Users
    WHERE Name = @Name AND Password = @Password
END
