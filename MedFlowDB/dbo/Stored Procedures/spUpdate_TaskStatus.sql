CREATE PROCEDURE [dbo].[spUpdate_TaskStatus]
    @taskId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Tasks
    SET Status = 1
    WHERE Id = @taskId;
END
