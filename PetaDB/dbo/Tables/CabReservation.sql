CREATE TABLE [dbo].[CabReservation]
(
	[CabReservationID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Tdate] DATETIME NULL, 
    [GuestID] INT NULL, 
    [TFrom] VARCHAR(50) NULL, 
    [TTo] VARCHAR(50) NULL, 
    [ReminderMinutes] INT NULL, 
    [DriverID] INT NULL, 
    CONSTRAINT [FK_CabReservation_Guests] FOREIGN KEY ([GuestID]) REFERENCES [Guests]([GuestID]), 
    CONSTRAINT [FK_CabReservation_Drivers] FOREIGN KEY ([DriverID]) REFERENCES [Drivers]([DriverID])
)
