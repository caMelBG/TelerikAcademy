update Chats
set StartDate = m.SentOn
from Chats c
	join Messages m
	on m.ChatId = c.Id
where c.StartDate > m.SentOn

delete l
from Locations as l
where 0 = (
	select count(*)
	from Users u
	where u.LocationId = l.Id)


insert into Messages(Content, SentOn, ChatId, UserId)
select 
	concat(u.Age, '-', u.Gender, '-', l.Latitude, '-', l.Longitude) as [Content],
	convert(date, getdate(), 126) as [SentOn],
	case 
		when u.Gender = 'F'
		then round(sqrt(u.Age * 2), 0)
		when u.Gender = 'M'
		then round(power(u.Age / 18, 3), 0)
		end as [ChatId],
	u.Id as [UserId]
from Users u
	join Locations l
	on l.Id = u.LocationId 
where u.Id between 10 and 20