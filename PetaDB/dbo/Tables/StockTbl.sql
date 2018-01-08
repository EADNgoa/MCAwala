CREATE TABLE [dbo].[Stock]
(
	[ItemId] INT NOT NULL, 
    [Quantity] DECIMAL(18, 3) NULL, 
    [UnitId] INT NULL, 
    [LocationId] INT NULL, 
    CONSTRAINT [FK_StockTbl_ItemsTbl] FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId]), 
    CONSTRAINT [FK_StockTbl_UnitsTbl] FOREIGN KEY ([UnitId]) REFERENCES [Units]([UnitId]), 
    CONSTRAINT [FK_StockTbl_LocationTbl] FOREIGN KEY ([LocationId]) REFERENCES [Location]([LocationId]), 
    CONSTRAINT [PK_Stock] PRIMARY KEY ([ItemId])
)
