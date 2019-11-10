CREATE TABLE [dbo].[PersonTable]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[PersonId] INT NOT NULL UNIQUE,
    [PersonName] NVARCHAR(50) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [DepartmentName] NVARCHAR(50) NOT NULL 
)
