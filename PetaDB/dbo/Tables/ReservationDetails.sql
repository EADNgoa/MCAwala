CREATE TABLE [dbo].[ReservationDetails]
(
	[ReservationDetailID] INT NOT NULL PRIMARY KEY, 
    [RDdate] DATE NULL, 
    [Description] VARBINARY(250) NULL, 
    [Amount] DECIMAL(18, 2) NULL, 
    [ChargeID] INT NULL, 
    [ChargeType] INT NULL, 
    [ReservationID] INT NULL, 
    CONSTRAINT [FK_ReservationDetails_Reservation] FOREIGN KEY ([ReservationID]) REFERENCES [Reservation]([ReservationID])
)
