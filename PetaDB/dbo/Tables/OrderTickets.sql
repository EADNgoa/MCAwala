CREATE TABLE [dbo].[OrderTickets]
(
	[OTID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [LocationId] INT NULL, 
    [TDateTime] DATETIME NULL, 
    [RoomNo] INT NULL, 
    [TableId] INT NULL, 
    [CardId] INT NULL, 
    [WaiterId] NVARCHAR(128) NULL, 
    [IsServed] BIT NULL, 
    [IsPaid] BIT NULL, 
    [EditedBy] NVARCHAR(128) NULL, 
    [IsVoid] BIT NULL, 
    [VoidedBy] VARCHAR(50) NULL, 
    [VoidedReason] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_OrderTickets_LocationTbl] FOREIGN KEY ([LocationId]) REFERENCES [Location]([LocationId]), 
    CONSTRAINT [FK_OrderTickets_TablesTbl] FOREIGN KEY ([TableId]) REFERENCES [Tables]([TableId]), 
    CONSTRAINT [FK_OrderTickets_CashCard] FOREIGN KEY ([CardId]) REFERENCES [CashCard]([CardId]), 
    CONSTRAINT [FK_OrderTickets_AspNetUsers] FOREIGN KEY ([WaiterId]) REFERENCES [AspNetUsers]([Id]), 
    CONSTRAINT [FK_OrderTickets_AspNetUser] FOREIGN KEY ([EditedBy]) REFERENCES [AspNetUsers]([Id])
)
