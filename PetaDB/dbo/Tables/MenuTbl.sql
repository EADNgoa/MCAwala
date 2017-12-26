CREATE TABLE [dbo].[Menu]
(
	[LocationId] INT NOT NULL, 
    [ItemId] INT NULL, 
    [Price] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_MenuTbl_LocationTbl] FOREIGN KEY ([LocationId]) REFERENCES [Location]([LocationId]), 
    CONSTRAINT [FK_MenuTbl_ItemsTbl] FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId])
)
