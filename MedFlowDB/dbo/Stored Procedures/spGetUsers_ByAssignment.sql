CREATE PROCEDURE [dbo].[spGetUsers_ByAssignment]
	@canAssignTask bit
AS

begin
	set nocount on;

	SELECT
    u.FirstName,
    u.LastName
	FROM dbo.Users u
	INNER JOIN dbo.UserRoles ur ON u.UserRoleId = ur.Id
	WHERE ur.CanAssignTask = @canAssignTask;
end
