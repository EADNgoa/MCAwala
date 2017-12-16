CREATE TABLE [dbo].[DiscountsTbl]
(
	[DiscountId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [ItemId] INT NULL, 
    [Tfrom] DATETIME NULL, 
    [Tto] DATETIME NULL, 
    [Percentage] DECIMAL(5, 2) NULL, 
    [Amount] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_DiscountsTbl_ItemsTbl] FOREIGN KEY ([ItemId]) REFERENCES [ItemsTbl]([ItemId])
)
