CREATE TABLE [dbo].[Reservation]
(
	[ReservationID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RDate] DATE NULL, 
    [ReservationSourceID] INT NULL, 
    [Rstart] DATE NULL, 
    [NoOfDays] INT NULL, 
    [CheckIn] DATETIME NULL, 
    [CheckOut] DATETIME NULL, 
    [RoomNo] VARCHAR(50) NULL, 
    [GuestComment] VARCHAR(MAX) NULL, 
    [CavalaReply] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Reservation_ReservationSource] FOREIGN KEY ([ReservationSourceID]) REFERENCES [ReservationSource]([ReservationSourceID])
)
