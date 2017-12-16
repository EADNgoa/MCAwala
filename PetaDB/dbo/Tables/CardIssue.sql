CREATE TABLE [dbo].[CardIssue]
(
	[CardIssueId] INT NOT NULL PRIMARY KEY, 
    [CardId] INT NULL, 
    [IssuedOn] DATETIME NULL, 
    [ReturnedOn] DATETIME NULL, 
    [ExpiresOn] DATETIME NULL, 
    [ToPerson] NVARCHAR(128) NULL, 
    [ContactDetails] VARCHAR(150) NULL, 
    [DepositAmt] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_CardIssue_CashCard] FOREIGN KEY ([CardId]) REFERENCES [CashCard]([CardId]), 
    CONSTRAINT [FK_CardIssue_AspNetUsers] FOREIGN KEY ([ToPerson]) REFERENCES [AspNetUsers]([Id])
)
