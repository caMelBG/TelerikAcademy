--Task 1
select u.Nickname, u.Gender, u.Age
from Users u
where u.Age between 22 and 37

--Task 2
select m.Content, m.SentOn
from Messages m
where m.SentOn > '2014-5-12' and m.Content like ('%just%')
order by m.Id desc

--Task 3
select c.Title, c.IsActive
from Chats c
where 
	(c.IsActive = 'False' and
	len(c.Title) < 5) or
	substring(c.Title, 3, 2) in ('tl')
order by c.Title desc

--Task 4
select c.Id, c.Title, m.Id
from Chats c
	join Messages m
	on m.ChatId = c.Id
	and m.SentOn < '2012-03-26'
where substring(c.Title, len(c.Title), 1) = 'x'
order by c.Id asc, m.Id asc

--Task 5
select top 5
	c.Id as [Id], (
	select count(m.ChatId) 
	from Messages m 
	where m.ChatId = c.Id and m.Id < 90) 
	as [TotalMessages]
from Chats c
order by [TotalMessages] desc, [Id] asc

--Task 6
select 
	u.Nickname as [Nickname], 
	c.Email as [Email], 
	c.Password as [Password]
from Users u
	join Credentials c
	on c.Id = u.Id 
	and c.Email like '%co.uk'
order by [Email] asc

--Task 7
select u.Id, u.Nickname, u.Age 
from Users u 
where u.LocationId is null

--Task 8
select u.Nickname, c.Title, l.Latitude, l.Longitude
from Users u
	join UsersChats uc
	on uc.UserId = u.Id
	join Chats c
	on uc.ChatId = c.Id
	join Locations l
	on l.Id = u.LocationId
	and l.Latitude between 41.14 and 44.13
	and l.Longitude between	22.21 and 28.36
order by c.Title asc

--Task 9
select 
	c.Title, 
	case 
	when (select top 1 m.Content from Messages m where m.ChatId = c.Id) is null
	then null
	else (select top 1 m.Content from Messages m where m.ChatId = c.Id)
	end as [Content]
from Chats c
where c.StartDate = (select max(StartDate) from Chats)