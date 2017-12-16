CREATE TABLE [dbo].[TableReservation]
(
	[TableReservationId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [TDateTime] DATETIME NULL, 
    [TableId] INT NULL, 
    [PersonName] VARCHAR(MAX) NULL, 
    [Contact] VARCHAR(11) NULL, 
    [NoOfPax] INT NULL, 
    CONSTRAINT [FK_TableReservation_TablesTbl] FOREIGN KEY ([TableId]) REFERENCES [TablesTbl]([TableId])
)
