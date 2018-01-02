CREATE TABLE [dbo].[InventoryTransaction]
(
	[InventoryTransactionId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [TDate] DATETIME NOT NULL, 
    [ItemId] INT NOT NULL, 
    [QtyAdded] DECIMAL(18, 3) NULL, 
    [QtyRemoved] DECIMAL(18, 3) NULL, 
    [FromLocationId] INT NULL, 
    [ToLocationId] INT NULL,      
    [RecvdByUserId] NVARCHAR(128) NULL, 
    [ChkByUserId] NVARCHAR(128) NULL, 
    [UnitId] INT NOT NULL, 
    [FoodStockId] INT NULL, 
    CONSTRAINT [FK_InventoryTransaction_ItemTbl] FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId]),
	CONSTRAINT [FK_InventoryTransaction_FromLocation] FOREIGN KEY ([FromLocationId]) REFERENCES [Location]([LocationId]),
	CONSTRAINT [FK_InventoryTransaction_ToLocation] FOREIGN KEY ([ToLocationId]) REFERENCES [Location]([LocationId]),
	CONSTRAINT [FK_InventoryTransaction_UnitTbl] FOREIGN KEY ([UnitId]) REFERENCES [Units]([UnitId]), 
    CONSTRAINT [FK_InventoryTransaction_AspNetUsers] FOREIGN KEY ([RecvdByUserId]) REFERENCES [AspNetUsers]([Id]),
	CONSTRAINT [FK_InventoryTransaction_AspNetUser] FOREIGN KEY ([ChkByUserId]) REFERENCES [AspNetUsers]([Id]),
	CONSTRAINT [FK_InventoryTransaction_FoodStock] FOREIGN KEY ([FoodStockId]) REFERENCES [FoodStock]([FoodStockId])
)
