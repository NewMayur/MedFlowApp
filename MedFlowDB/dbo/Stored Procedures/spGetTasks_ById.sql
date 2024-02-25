CREATE PROCEDURE [dbo].[spGetTasks_ById]
	@creatorId int
AS
	select * from dbo.Tasks t 
	where t.CreatedBy=@creatorId
RETURN 0


