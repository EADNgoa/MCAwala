CREATE TABLE [dbo].[ItemsTbl]
(
	[ItemId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [ItemName] VARCHAR(50) NULL, 
    [ItemTypeId] INT NULL, 
    [ExpiryDays] INT NULL, 
    [UnitId] INT NULL,
	CONSTRAINT [FK_ItemsTbl_ItemTypes] FOREIGN KEY ([ItemTypeId]) REFERENCES [ItemTypes]([ItemTypeId]), 
    CONSTRAINT [FK_ItemsTbl_UnitsTbl] FOREIGN KEY ([UnitId]) REFERENCES [UnitsTbl]([UnitId])
)
