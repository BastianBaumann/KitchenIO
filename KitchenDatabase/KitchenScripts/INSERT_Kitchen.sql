CREATE PROCEDURE [dbo].[INSERT_Kitchen]
	@Id uniqueidentifier,
	@Name varchar(50),
	@Description varchar(MAX)
AS
INSERT INTO KitchenTable
(Id,Name,Description)
values
(@Id,@Name,@Description)
