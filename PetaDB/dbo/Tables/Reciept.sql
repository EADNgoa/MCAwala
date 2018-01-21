CREATE TABLE [dbo].[Reciept]
(

	[RecieptID] INT NOT NULL PRIMARY KEY IDENTITY,     
    [Rdate] DATETIME NULL, 
    [ChargeID] INT NULL, 
    [ChargeType] INT NULL, 
    [Amount] DECIMAL(18, 2) NULL, 
    [PayMode] INT NULL, 
    [PayDetails] VARCHAR(150) NULL    
)
