CREATE PROCEDURE [dbo].[GETByName_Users]
	@Name varchar(50)
AS
	SELECT Id,Name,Password,Allergies FROM Users
WHERE Name = @Name