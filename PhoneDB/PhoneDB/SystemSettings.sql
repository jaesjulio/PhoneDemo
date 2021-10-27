CREATE TABLE [dbo].[SystemSettings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedAt] DATETIME NULL, 
    [IsActive] BIT NULL, 
    [IsDeleted] BIT NULL, 
    [DeletedAt] DATETIME NULL, 
    [Code] NVARCHAR(50) NULL, 
    [Value] NVARCHAR(50) NULL
)
