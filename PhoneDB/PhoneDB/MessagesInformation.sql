CREATE TABLE [dbo].[MessagesInformation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MessageId] INT NULL, 
    [SentDateTime] DATETIME NULL, 
    [TwilioConfirmation] NVARCHAR(50) NULL, 
    [TwilioMessage] NVARCHAR(MAX) NULL, 
    [IsActive] BIT NULL, 
    [IsDeleted] BIT NULL, 
    [DeletedAt] DATETIME NULL,
    [CreatedAt] DATETIME NULL, 
    CONSTRAINT [FK_MessagesInformation_ToMessage] FOREIGN KEY (MessageId) REFERENCES Messages(Id)
)
