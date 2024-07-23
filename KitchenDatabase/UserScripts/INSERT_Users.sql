CREATE PROCEDURE [dbo].[INSERT_Users]
	@Name varchar(50),
	@Password varchar(50),
	@Allergies varchar(MAX)
AS
INSERT INTO Users
(Id,Name,Password,Allergies)
values
(NEWID(),@Name,@Password,@Allergies)
