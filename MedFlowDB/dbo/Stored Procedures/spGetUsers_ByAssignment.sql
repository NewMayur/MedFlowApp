CREATE PROCEDURE [dbo].[spGetUsers_ByAssignment]
	@canAssignTask bit
AS

BEGIN
    SET NOCOUNT ON;

    SELECT
        u.Id,
        u.FirstName,
        u.LastName,
        u.UserRoleId
    FROM dbo.Users u
    INNER JOIN dbo.UserRoles ur ON u.UserRoleId = ur.Id
    WHERE ur.CanAssignTask = @canAssignTask;
END
