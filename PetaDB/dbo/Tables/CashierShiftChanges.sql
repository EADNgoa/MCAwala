CREATE TABLE [dbo].[CashierShiftChanges]
(
	[CashierID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] NVARCHAR(128) NULL, 
    [Tdate] DATETIME NULL, 
    [CashInHand] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_CashierShiftChanges_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers]([Id])
)
