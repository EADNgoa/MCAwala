/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT * FROM UserFunctions)
BEGIN
	SET IDENTITY_INSERT [dbo].[UserFunctions] ON
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (1, N'Units', N'Masters')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (2, N'CashCard', N'Bar')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (3, N'Course', N'Dining')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (4, N'Location', N'Masters')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (5, N'LocationType', N'Masters')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (6, N'Table', N'Dining')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (7, N'Group', N'Users')
	SET IDENTITY_INSERT [dbo].[UserFunctions] OFF
END