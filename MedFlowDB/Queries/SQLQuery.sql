select
	t.Title,
	t.DateCreated,
	t.Status,
	uc.FirstName as CreatedBy,
	ua.FirstName as AssignedTo

from dbo.Tasks t
inner join dbo.Users uc on uc.Id = t.CreatedBy
inner join dbo.Users ua on t.AssignedTo = ua.Id;







