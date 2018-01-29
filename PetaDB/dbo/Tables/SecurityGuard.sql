CREATE TABLE [dbo].[SecurityGuard]
(
	[SecurityGuardID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AttendanceSystemID] VARCHAR(50) NULL, 
    [Name] VARCHAR(100) NULL, 
    [Address] VARCHAR(350) NULL, 
    [Mobile] VARCHAR(15) NULL
)
