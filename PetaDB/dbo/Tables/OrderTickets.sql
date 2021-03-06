﻿CREATE TABLE [dbo].[OrderTickets]
(
	[OTID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [LocationId] INT NULL, 
    [TDateTime] DATETIME NULL DEFAULT GetDate(), 
    [ReservationId] int NULL, 
    [TableId] VARCHAR(50) NULL, 
    [CardId] INT NULL, 
    [WaiterId] NVARCHAR(128) NULL, 
    [IsServed] BIT NULL, 
    [IsPaid] BIT NULL, 
    [EditedBy] NVARCHAR(128) NULL, 
    [IsVoid] BIT NULL, 
    [VoidedBy] VARCHAR(50) NULL, 
    [VoidedReason] VARCHAR(MAX) NULL, 
    [Notes] VARCHAR(300) NULL, 
    CONSTRAINT [FK_OrderTickets_LocationTbl] FOREIGN KEY ([LocationId]) REFERENCES [Location]([LocationId]),     
    CONSTRAINT [FK_OrderTickets_CashCard] FOREIGN KEY ([CardId]) REFERENCES [CashCard]([CardId]), 
    CONSTRAINT [FK_OrderTickets_AspNetUsers] FOREIGN KEY ([WaiterId]) REFERENCES [AspNetUsers]([Id]), 
    CONSTRAINT [FK_OrderTickets_AspNetUser] FOREIGN KEY ([EditedBy]) REFERENCES [AspNetUsers]([Id]),
	CONSTRAINT [FK_OrderTickets_Reservation] FOREIGN KEY ([ReservationId]) REFERENCES [Reservation]([ReservationId])
)
