CREATE TABLE [dbo].[MenuTbl]
(
	[LocationId] INT NOT NULL, 
    [ItemId] INT NULL, 
    [Price] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_MenuTbl_LocationTbl] FOREIGN KEY ([LocationId]) REFERENCES [LocationTbl]([LocationId]), 
    CONSTRAINT [FK_MenuTbl_ItemsTbl] FOREIGN KEY ([ItemId]) REFERENCES [ItemsTbl]([ItemId])
)
