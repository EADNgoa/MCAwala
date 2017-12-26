CREATE TABLE [dbo].[OrderTicketDetails]
(
	[OTdetailsId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [OTID] INT NULL, 
    [ItemId] INT NULL, 
    [Qty] INT NULL, 
    [Price] DECIMAL(18, 2) NULL, 
    [CourseId] INT NULL, 
    [NC] BIT NULL, 
    [NCtext] VARCHAR(50) NULL, 
    [NCUserId] NVARCHAR(128) NULL, 
    CONSTRAINT [FK_OrderTicketDetails_OrderTickets] FOREIGN KEY ([OTID]) REFERENCES [OrderTickets]([OTID]), 
    CONSTRAINT [FK_OrderTicketDetails_ItemsTbl] FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId]), 
    CONSTRAINT [FK_OrderTicketDetails_CourseTbl] FOREIGN KEY ([CourseId]) REFERENCES [Course]([CourseId]), 
    CONSTRAINT [FK_OrderTicketDetails_AspNetUsers] FOREIGN KEY ([NCUserId]) REFERENCES [AspNetUsers]([Id])
)
