CREATE TABLE [dbo].[Config]
(
	[TableReservationTime] DATETIME NOT NULL PRIMARY KEY, 
    [CardExpiryDays] INT NULL, 
    [Reminders] INT NULL, 
    [BotlePerDay] INT NULL
)
