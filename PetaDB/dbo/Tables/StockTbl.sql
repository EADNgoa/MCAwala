CREATE TABLE [dbo].[StockTbl]
(
	[ItemId] INT NOT NULL, 
    [Quantity] INT NULL, 
    [UnitId] INT NULL, 
    [LocationId] INT NULL, 
    CONSTRAINT [FK_StockTbl_ItemsTbl] FOREIGN KEY ([ItemId]) REFERENCES [ItemsTbl]([ItemId]), 
    CONSTRAINT [FK_StockTbl_UnitsTbl] FOREIGN KEY ([UnitId]) REFERENCES [UnitsTbl]([UnitId]), 
    CONSTRAINT [FK_StockTbl_LocationTbl] FOREIGN KEY ([LocationId]) REFERENCES [LocationTbl]([LocationId])
)
