CREATE TABLE [dbo].[UserGroups]
(
	[UserID] NVARCHAR(128) NOT NULL , 
    [GroupID] INT NOT NULL, 
    PRIMARY KEY ([UserID], [GroupID]), 
    CONSTRAINT [FK_UserGroups_ToUsers] FOREIGN KEY (UserID) REFERENCES Users(UserID), 
    CONSTRAINT [FK_UserGroups_ToGroups] FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)
)
