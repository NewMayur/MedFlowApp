CREATE PROCEDURE [dbo].[spGetUser_ById]
	@userId int 
AS

begin
	set nocount on;
	
	select u.FirstName, u.LastName
	from dbo.Users u
	where u.Id = @userId;
end
