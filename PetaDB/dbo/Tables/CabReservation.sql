CREATE TABLE [dbo].[CabReservation]
(
	[CabReservationID] INT NOT NULL PRIMARY KEY, 
    [Tdate] DATETIME NULL, 
    [GuestID] INT NULL, 
    [TFrom] VARCHAR(50) NULL, 
    [TTo] VARCHAR(50) NULL, 
    [ReminderMinutes] INT NULL
)
