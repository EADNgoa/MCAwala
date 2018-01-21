CREATE TABLE [dbo].[Guests]
(
	[GuestID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GuestName] VARCHAR(100) NULL, 
    [GuestAddress] VARCHAR(250) NULL, 
    [GuestCountry] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL, 
    [Phone] VARCHAR(15) NULL, 
    [PhotoID] VARCHAR(100) NULL, 
    [Likes] VARCHAR(MAX) NULL, 
    [Dislikes] VARCHAR(MAX) NULL
)
