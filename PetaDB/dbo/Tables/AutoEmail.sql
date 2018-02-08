CREATE TABLE [dbo].[AutoEmail]
(
	[AutoID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GuestID] INT NULL, 
    [Salutation] VARCHAR(50) NULL, 
    [Body] VARCHAR(MAX) NULL, 
    [Closing] VARCHAR(150) NULL, 
    [LuckyDraw] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_AutoEmail_Guest] FOREIGN KEY ([GuestID]) REFERENCES [Guests]([GuestID])
)
