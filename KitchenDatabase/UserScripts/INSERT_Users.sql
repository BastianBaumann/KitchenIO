CREATE PROCEDURE [dbo].[INSERT_Users]
	@Id uniqueidentifier,
	@Name varchar(50),
	@Password varchar(50),
	@Allergies varchar(MAX)
AS
INSERT INTO Users
(Id,Name,Password,Allergies)
values
(@Id,@Name,@Password,@Allergies)
