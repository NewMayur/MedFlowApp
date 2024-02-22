CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [UserRoleId] INT NOT NULL, 
    CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY (UserRoleId) REFERENCES UserRoles(Id)
)
