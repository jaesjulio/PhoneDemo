CREATE TABLE [dbo].[Messages]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedAt] DATETIME NULL, 
    [ToNumber] NVARCHAR(50) NULL, 
    [TextMessage] NVARCHAR(MAX) NULL, 
    [IsActive] BIT NULL, 
    [IsDeleted] BIT NULL, 
    [DeletedAt] DATETIME NULL
)
