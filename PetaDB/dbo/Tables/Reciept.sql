CREATE TABLE [dbo].[Reciept]
(
	[RecieptID] INT NOT NULL IDENTITY PRIMARY KEY,     
    [Rdate] DATETIME NULL, 
    [ChargeID] INT NULL, 
    [ChargeType] INT NULL, 
    [Amount] DECIMAL(18, 2) NULL, 
    [PayMode] INT NULL, 
    [PayDetails] VARCHAR(150) NULL    
)
