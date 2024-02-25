CREATE PROCEDURE [dbo].[spGetTasks_ById&Assignment]
    @userId INT,
    @isAssigned BIT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.Id,
        t.Title,
        t.DateCreated,
        t.Status,
        t.CreatedBy,
        uCreated.FirstName AS CreatorFirstName,
        uCreated.LastName AS CreatorLastName,
        t.AssignedTo,
        uAssigned.FirstName AS AssigneeFirstName,
        uAssigned.LastName AS AssigneeLastName
    FROM
        dbo.Tasks t
        INNER JOIN dbo.Users uAssigned ON t.AssignedTo = uAssigned.Id
        INNER JOIN dbo.Users uCreated ON t.CreatedBy = uCreated.Id
    WHERE
        (@isAssigned = 1 AND t.AssignedTo = @userId)
        OR
        (@isAssigned = 0 AND t.CreatedBy = @userId);
END
