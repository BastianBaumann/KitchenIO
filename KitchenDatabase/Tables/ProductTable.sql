CREATE TABLE [dbo].[ProductTable]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Barcode] VARCHAR(50) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [Type] INT NULL
)
