CREATE TABLE [dbo].[Guests]
(
	[GuestID] INT NOT NULL PRIMARY KEY, 
    [GuestName] VARCHAR(100) NULL, 
    [GuestAddress] VARCHAR(100) NULL, 
    [GuestCountry] VARBINARY(50) NULL, 
    [Email] VARCHAR(50) NULL, 
    [Phone] VARCHAR(50) NULL, 
    [PhotoID] INT NULL, 
    [Likes] VARCHAR(MAX) NULL, 
    [Dislikes] VARCHAR(MAX) NULL
)
