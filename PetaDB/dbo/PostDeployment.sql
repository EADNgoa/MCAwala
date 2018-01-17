IF NOT EXISTS (SELECT * FROM AspNetRoles WHERE Name = 'Admin')
	INSERT INTO [dbo].AspNetRoles (Id, Name) VALUES (N'52504e77-f626-4a41-82ac-21f7b33f12ad', N'Admin')
GO

SET IDENTITY_INSERT [dbo].[UserFunctions] ON
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (1, N'Units', N'Masters')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (2, N'CashCard', N'Bar')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (3, N'Course', N'Dining')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (4, N'Location', N'Masters')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (6, N'Table', N'Dining')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (7, N'Group', N'Users')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (8, N'Inventory Receipts', N'Kitchen')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (9, N'Inventory Checking', N'Kitchen')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (10, N'Unit Conversion', N'Masters')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (11, N'Inventory Portion', N'Kitchen')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (12, N'Wastage Report', N'Kitchen')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (13, N'Inventory Move Use', N'Kitchen')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (14, N'Item', N'Master')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (15, N'Table Res', N'Dining')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (16, N'Menu', N'Dining')
SET IDENTITY_INSERT [dbo].[UserFunctions] OFF

GO

IF NOT EXISTS (SELECT * FROM ItemTypes)
BEGIN
	SET IDENTITY_INSERT [dbo].[ItemTypes] ON
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (1, N'Raw Material')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (2, N'Ready To Serve')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (3, N'Drinks')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (4, N'Stationary')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (5, N'Keys')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (6, N'Maintenance')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (7, N'LaundryGuest')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (8, N'LaundryStaff')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (9, N'Linen')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (10, N'Toiletries')
	SET IDENTITY_INSERT [dbo].[ItemTypes] OFF
END

GO
--Do for Location Types
--Add location: Kitchen Load point

