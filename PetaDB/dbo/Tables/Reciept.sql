CREATE TABLE [dbo].[Reciept]
(
	[RecieptID] INT NOT NULL PRIMARY KEY, 
    [ReservationID] INT NULL, 
    [Rdate] DATETIME NULL, 
    [ChargeID] INT NULL, 
    [ChargeType] INT NULL, 
    [Amount] DECIMAL(18, 2) NULL, 
    [PayMode] INT NULL, 
    [PayDetails] VARCHAR(150) NULL, 
    CONSTRAINT [FK_Reciept_Reservation] FOREIGN KEY ([ReservationID]) REFERENCES [Reservation]([ReservationID])
)
