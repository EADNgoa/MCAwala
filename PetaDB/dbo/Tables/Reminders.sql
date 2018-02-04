CREATE TABLE [dbo].[Reminders]
(
	[ReminderID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Tdate] DATETIME NULL, 
    [Description] VARCHAR(MAX) NULL
)
