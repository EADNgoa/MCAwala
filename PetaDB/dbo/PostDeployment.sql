﻿
IF NOT EXISTS (SELECT * FROM UserFunctions)
BEGIN
	SET IDENTITY_INSERT [dbo].[UserFunctions] ON
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (1, N'Units', N'Masters')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (2, N'CashCard', N'Bar')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (3, N'Course', N'Dining')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (4, N'Location', N'Masters')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (5, N'Order', N'Dining')
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
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (17, N'Discounts', N'Masters')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (18, N'OrderReceipt', N'Dining')

	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (19, N'Reservation', N'Reservation')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (20, N'Cab Reservation', N'Cab Reservation')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (21, N'User Rights', N'Masters')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (22, N'KOT', N'Kitchen')
INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (25, N'Birthday', N'Birthday')

	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (23, N'Security', N'Masters')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (24, N'Cashier', N'Cashier')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (3004, N'Room Cost', N'Restaurant')
	INSERT INTO [dbo].[UserFunctions] ([FunctionID], [FunctionName], [Module]) VALUES (4001, N'Reminders', N'Reminders')


	SET IDENTITY_INSERT [dbo].[UserFunctions] OFF
END


IF NOT EXISTS (SELECT * FROM ItemTypes)
BEGIN
	SET IDENTITY_INSERT [dbo].[ItemTypes] ON
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (1, N'Raw Material')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (2, N'Ready To Serve')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (3, N'Drinks Non-Alcoholic')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (4, N'Stationary')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (5, N'Keys')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (6, N'Maintenance')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (7, N'LaundryGuest')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (8, N'LaundryStaff')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (9, N'Linen')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (10, N'Toiletries')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (11, N'Menu Dishes')
	INSERT INTO [dbo].[ItemTypes] ([ItemTypeId], [ItemTypeName]) VALUES (12, N'Drinks Alcoholic')
	SET IDENTITY_INSERT [dbo].[ItemTypes] OFF
END


IF NOT EXISTS (SELECT * FROM LocationTypes)
BEGIN
	SET IDENTITY_INSERT [dbo].[LocationTypes] ON
	INSERT INTO [dbo].[LocationTypes] ([LocationTypeId], [LocationTypeName]) VALUES (1, N'Restaurant')
	INSERT INTO [dbo].[LocationTypes] ([LocationTypeId], [LocationTypeName]) VALUES (2, N'Hardware Store')
	INSERT INTO [dbo].[LocationTypes] ([LocationTypeId], [LocationTypeName]) VALUES (3, N'Fridge')
	INSERT INTO [dbo].[LocationTypes] ([LocationTypeId], [LocationTypeName]) VALUES (4, N'Food Store')
	SET IDENTITY_INSERT [dbo].[LocationTypes] OFF
END

--used in Kitchen inventory receipt
IF NOT EXISTS (SELECT * FROM Location WHERE LocationName = 'Kitchen Load point')
	INSERT INTO [dbo].Location (LocationName, LocationTypeId) VALUES ('Kitchen Load point', 4)
IF NOT EXISTS (SELECT * FROM Location WHERE LocationName = 'Room Service')
    INSERT INTO [dbo].Location (LocationName, LocationTypeId) VALUES ('Room Service', 1)


--used in Restaurant Order screen
IF NOT EXISTS (SELECT * FROM Groups WHERE GroupName = 'Waiter')
	INSERT INTO [dbo].Groups (GroupName) VALUES ('Waiter')

--Used in Room Costs  Screen
	
IF NOT EXISTS (SELECT * FROM Units WHERE UnitName = 'Pieces')
	SET IDENTITY_INSERT [dbo].[Units] ON

	INSERT INTO [dbo].Units (UnitName) VALUES (1,'Pieces')
SET IDENTITY_INSERT [dbo].[Units] OFF

IF NOT EXISTS (SELECT * FROM Items WHERE ItemName = 'Room Water Bottle')
	INSERT INTO [dbo].Items (ItemName,ItemTypeId,ExpiryDays,UnitId) VALUES ('Room Water Bottle',3,180,1)
	



	