CREATE TABLE [dbo].[FoodStock]
(
	[FoodStockId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [TDate] DATE NOT NULL, 
    [InventoryTransactionId] INT NULL, 
    [ItemId] INT NOT NULL, 
    [Qty] DECIMAL(18, 3) NOT NULL, 
	[Size]                    DECIMAL (18, 2) NOT NULL,
    [UnitId] INT NOT NULL, 
    [LocationId] INT NOT NULL ,
	CONSTRAINT [FK_FoodStock_ToLocation] FOREIGN KEY ([LocationId]) REFERENCES [Location]([LocationId]),
	CONSTRAINT [FK_FoodStock_UnitTbl] FOREIGN KEY ([UnitId]) REFERENCES [Units]([UnitId]), 
	CONSTRAINT [FK_FoodStock_ItemTbl] FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId]),
	CONSTRAINT [FK_FoodStock_InventoryTransaction] FOREIGN KEY ([InventoryTransactionId]) REFERENCES [InventoryTransaction]([InventoryTransactionId])
)
