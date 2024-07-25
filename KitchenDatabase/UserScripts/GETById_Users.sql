CREATE PROCEDURE [dbo].[GETById_Users]
	@UserId uniqueidentifier
AS
	SELECT Id,Name,Password,Allergies FROM Users
WHERE Id = @UserId