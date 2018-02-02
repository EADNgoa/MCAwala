CREATE TABLE [dbo].[ReservationDetails]
(
	[ReservationDetailID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RDdate] DATE NULL, 
    [Description] VARCHAR(250) NULL, 
    [Amount] DECIMAL(18, 2) NULL, 
    [ChargeID] INT NULL, 
    [ChargeType] INT NULL, 
    [ItemID] INT NULL, 
    [Qty] INT NULL, 

 
)
