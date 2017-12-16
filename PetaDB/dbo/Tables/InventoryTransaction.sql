CREATE TABLE [dbo].[InventoryTransaction]
(
	[InventoryTransactionId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [TDate] DATETIME NULL, 
    [ItemId] INT NULL, 
    [QtyAdded] INT NULL, 
    [QtyRemoved] INT NULL, 
    [FromLocationId] INT NULL, 
    [ToLocationId] INT NULL, 
    [ToPortionId] INT NULL, 
    [RecvdByUserId] NVARCHAR(128) NULL, 
    [ChkByUserId] NVARCHAR(128) NULL, 
    CONSTRAINT [FK_InventoryTransaction_ItemTbl] FOREIGN KEY ([ItemId]) REFERENCES [ItemsTbl]([ItemId]),
	CONSTRAINT [FK_InventoryTransaction_FromLocation] FOREIGN KEY ([FromLocationId]) REFERENCES [LocationTbl]([LocationId]),
	CONSTRAINT [FK_InventoryTransaction_ToLocation] FOREIGN KEY ([ToLocationId]) REFERENCES [LocationTbl]([LocationId]),
	CONSTRAINT [FK_InventoryTransaction_UnitTbl] FOREIGN KEY ([ToPortionId]) REFERENCES [UnitsTbl]([UnitId]), 
    CONSTRAINT [FK_InventoryTransaction_AspNetUsers] FOREIGN KEY ([RecvdByUserId]) REFERENCES [AspNetUsers]([Id]),
	CONSTRAINT [FK_InventoryTransaction_AspNetUser] FOREIGN KEY ([ChkByUserId]) REFERENCES [AspNetUsers]([Id])
)
