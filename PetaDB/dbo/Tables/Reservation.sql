CREATE TABLE [dbo].[Reservation]
(
	[ReservationID] INT NOT NULL PRIMARY KEY, 
    [RDate] DATE NULL, 
    [ReservationSourceID] INT NULL, 
    [Rstart] DATE NULL, 
    [NoOfDays] INT NULL, 
    [CheckIn] DATETIME NULL, 
    [CheckOut] DATETIME NULL, 
    [RoomNo] INT NULL, 
    [GuestComment] VARCHAR(MAX) NULL, 
    [CavalaReply] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Reservation_ReservationSource] FOREIGN KEY ([ReservationSourceID]) REFERENCES [ReservationSource]([ReservationSourceID])
)
