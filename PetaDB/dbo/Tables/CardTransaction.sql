CREATE TABLE [dbo].[CardTransaction]
(
    [CardTransactionId] INT IDENTITY NOT NULL, 
	[CardId] INT NOT NULL, 
    [CardIssueId] INT NULL, 
    [TDateTime] DATETIME NULL, 
    [RechargeAmt] DECIMAL(18, 2) NULL, 
    [AmountSpent] DECIMAL(18, 2) NULL, 
    [OTID] INT NULL, 
    CONSTRAINT [FK_CardTransaction_OrderTickets] FOREIGN KEY ([OTID]) REFERENCES [OrderTickets]([OTID]), 
    CONSTRAINT [FK_CardTransaction_CashCard] FOREIGN KEY ([CardId]) REFERENCES [CashCard]([CardId]), 
    CONSTRAINT [FK_CardTransaction_CardIssue] FOREIGN KEY ([CardIssueId]) REFERENCES [CardIssue]([CardIssueId]), 
    CONSTRAINT [PK_CardTransaction] PRIMARY KEY ([CardTransactionId])
)
