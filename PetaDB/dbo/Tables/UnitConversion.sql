CREATE TABLE [dbo].[UnitConversion]
(
	[UCId] INT NOT NULL IDENTITY PRIMARY KEY, 
	[AUnitOfId] INT NOT NULL,
    [IsJust] DECIMAL(18, 3) NOT NULL, 
    [OfUnitId] INT NOT NULL,     
    CONSTRAINT [FK_UnitConversion_FromUnits] FOREIGN KEY (AUnitOfId) REFERENCES Units([UnitId]),
	CONSTRAINT [FK_UnitConversion_ToUnits] FOREIGN KEY (OfUnitId) REFERENCES Units([UnitId]) 
)
