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
IF NOT EXISTS (SELECT 1 FROM dbo.UserRoles)
    BEGIN
        INSERT INTO dbo.UserRoles(RoleName, CanCreateTask, CanAssignTask)
        VALUES ('Doctor', 1, 1), ('Intern', 0, 0)
    END


IF NOT EXISTS (SELECT 1 FROM dbo.Users)
BEGIN
    DECLARE @userRoleId1 int;
    DECLARE @userRoleId2 int;

    SELECT @userRoleId1 = Id FROM dbo.UserRoles WHERE RoleName = 'Doctor';
    SELECT @userRoleId2 = Id FROM dbo.UserRoles WHERE RoleName = 'Intern';

    INSERT INTO dbo.Users (FirstName, LastName, UserRoleId) 
    VALUES ('Mayur', 'Gharat', @userRoleId1),
           ('New', 'Orange', @userRoleId2);
END



IF NOT EXISTS (SELECT 1 FROM Tasks)
    BEGIN
        INSERT INTO dbo.Tasks(Title, DateCreated, Status, CreatedBy, AssignedTo) 
        VALUES ('Task1', '2024-02-02', 0, 1, 2);
END