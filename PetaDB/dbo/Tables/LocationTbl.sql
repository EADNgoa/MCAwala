CREATE TABLE [dbo].[Location]
(
	[LocationId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [LocationName] VARCHAR(MAX) NULL, 
    [LocationTypeId] INT NULL, 
    CONSTRAINT [FK_LocationTbl_LocationType] FOREIGN KEY ([LocationTypeId]) REFERENCES [LocationTypes]([LocationTypeId])
)
