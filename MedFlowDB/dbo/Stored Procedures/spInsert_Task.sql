CREATE PROCEDURE [dbo].[spInsert_Task]
	@title text,
	@dateCreated date,
	@createdBy int,
	@assignedTo int
AS

begin
	set nocount on;
	
    INSERT INTO dbo.Tasks(Title, DateCreated, Status, CreatedBy, AssignedTo) 
    VALUES (@title, @dateCreated, 0, @createdBy, @assignedTo);

end
