CREATE TABLE [dbo].[FuctionGroups]
(
	[FunctionID] INT NOT NULL , 
    [GroupID] INT NOT NULL, 
    PRIMARY KEY ([GroupID], [FunctionID]), 
    CONSTRAINT [FK_FuctionGroups_ToUserFunctions] FOREIGN KEY (FunctionID) REFERENCES UserFunctions(FunctionID), 
    CONSTRAINT [FK_FuctionGroups_ToGroupID] FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)
)
