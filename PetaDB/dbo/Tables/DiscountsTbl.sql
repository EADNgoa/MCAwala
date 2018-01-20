CREATE TABLE [dbo].[Discounts]
(
	[DiscountId] INT NOT NULL IDENTITY PRIMARY KEY, 
	[DiscountName] Varchar(150) NULL,
	[ItemTypeId] INT NULL, 
    [ItemId] INT NULL, 
    [Tfrom] DATETIME NULL, 
    [Tto] DATETIME NULL, 
    [Percentage] DECIMAL(5, 2) NULL, 
    [Amount] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_DiscountsTbl_ItemsTbl] FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId]),
	CONSTRAINT [FK_DiscountsTbl_Itemstypes] FOREIGN KEY ([ItemTypeId]) REFERENCES [ItemTypes]([ItemTypeId])
)
