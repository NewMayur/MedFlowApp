CREATE TABLE [dbo].[Tasks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Title] TEXT NOT NULL, 
	[DateCreated] DATE NOT NULL, 
    [Status] BIT NOT NULL DEFAULT 0, 
    [CreatedBy] INT NOT NULL, 
    [AssignedTo] INT NOT NULL, 
    CONSTRAINT [FK_Tasks_CreatedBy_Users] FOREIGN KEY (CreatedBy) REFERENCES Users(Id), 
    CONSTRAINT [FK_Tasks_AssignedTo_Users] FOREIGN KEY (AssignedTo) REFERENCES Users(Id)
)
