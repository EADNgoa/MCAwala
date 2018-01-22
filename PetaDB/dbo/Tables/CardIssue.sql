CREATE TABLE [dbo].[CardIssue]
(
	[CardIssueId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [CardId] INT NULL, 
    [IssuedOn] DATETIME NULL, 
    [ReturnedOn] DATETIME NULL, 
    [ExpiresOn] DATE NULL, 
    [ToPerson] VARCHAR(80) NULL, 
    [ContactDetails] VARCHAR(150) NULL, 
    [DepositAmt] DECIMAL(18, 2) NULL,     
    CONSTRAINT [FK_CardIssue_CashCard] FOREIGN KEY ([CardId]) REFERENCES [CashCard]([CardId])    
)
