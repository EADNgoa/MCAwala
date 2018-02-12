CREATE TABLE [dbo].[SecurityGuardDetails]
(
	[SecurityGuardDetailID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SecurityGuardID] INT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [Tdate] DATETIME NULL, 
    [Path] VARCHAR(100) NULL
)
