CREATE TABLE [dbo].[AutoEmail]
(
	[AutoID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GuestID] INT NULL, 
    [Body] VARCHAR(MAX) NULL, 
    [LuckyDraw] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_AutoEmail_Guest] FOREIGN KEY ([GuestID]) REFERENCES [Guests]([GuestID])
)
