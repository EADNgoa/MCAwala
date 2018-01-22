﻿CREATE TABLE [dbo].[CashCard]
(
	[CardId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [CardName] VARCHAR(50) NULL,
    [Amount] decimal(18,2) NULL, 
    [Discarded] BIT NOT NULL DEFAULT 0 
)
