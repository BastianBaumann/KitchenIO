CREATE PROCEDURE [dbo].[GETALL_Users]
AS
SELECT Id,Name,Password,Allergies FROM Users
