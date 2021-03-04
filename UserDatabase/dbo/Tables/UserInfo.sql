CREATE TABLE [dbo].[UserInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [User_ID] INT NOT NULL, 
    [UserName] NVARCHAR(MAX) NOT NULL, 
    [FirstName] NVARCHAR(MAX) NOT NULL, 
    [LastName] NVARCHAR(MAX) NOT NULL, 
    [MiddleName] NVARCHAR(MAX) NULL, 
    [EmailAddress] NVARCHAR(MAX) NOT NULL, 
    [UserPassword] NVARCHAR(MAX) NOT NULL
)
