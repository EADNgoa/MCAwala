CREATE TABLE [dbo].[LocationTbl]
(
	[LocationId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [LocationName] VARCHAR(MAX) NULL, 
    [LocationTypeId] INT NULL, 
    CONSTRAINT [FK_LocationTbl_LocationType] FOREIGN KEY ([LocationTypeId]) REFERENCES [LocationType]([LocationTypeId])
)
