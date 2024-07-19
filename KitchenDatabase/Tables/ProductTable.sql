﻿CREATE TABLE [dbo].[ProductTable]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NOT NULL, 
    [Barcode] UNIQUEIDENTIFIER NOT NULL, 
    [Amount] INT NOT NULL, 
    [Weight] FLOAT NULL, 
    [Price] FLOAT NOT NULL
)
