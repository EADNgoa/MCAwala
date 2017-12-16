CREATE TABLE [dbo].[TablesTbl]
(
	[TableId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [TableName] VARCHAR(50) NULL, 
    [LocationId] INT NULL, 
    CONSTRAINT [FK_TablesTbl_LocationTbl] FOREIGN KEY ([LocationId]) REFERENCES [LocationTbl]([LocationId])
)
