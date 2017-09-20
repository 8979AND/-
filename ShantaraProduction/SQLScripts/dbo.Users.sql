CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [Auth_Level] INT NOT NULL DEFAULT 3, 
    [FName] NVARCHAR(50) NULL, 
    [LName] NVARCHAR(50) NULL, 
    [CellNumber] NCHAR(10) NULL, 
    [DateAdded] DATETIME NULL
)
