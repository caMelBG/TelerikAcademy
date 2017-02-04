--Task 1
select Name
from Characters
order by Name asc
select Name
from Characters
order by Name asc

--Task 2
select top 50
	Name as [Game], 
	convert(date, Start, 126) as [Start]
from Games
where Start between '2011-1-1' and '2012-1-1'
order by Start asc, Name asc

--Task 3
select 
	Username as [Username], 
	Email as [Email Provider]
from Users
order by Email desc, Username asc

--Task 4
select 
	Username as [Username], 
	IpAddress as [IP Address] 
from Users
where IpAddress like '___.1%.%.___'
order by Username asc

--Task 5
select 
	g.Name,
	case
	when datepart(hour, g.Start) between 0 and 12 then 'Morning'
	when datepart(hour, g.Start) between 12 and 18 then 'Evening'
	when datepart(hour, g.Start) between 18 and 24 then 'Afternoon'
	end as [Part of the Day],
	case
	when g.Duration < 4 then 'Extra short'
	when g.Duration between 4 and 6 then 'Short'
	when g.Duration > 6 then 'Long'
	when g.Duration is null then 'Extra Long'
	end as [Duration]
from Games as g
order by Name asc, [Duration], [Part of the Day] 

--Task 6
select distinct
	(
	SELECT
		SUBSTRING(u.Email, LEN(u.Email) - CHARINDEX('@', REVERSE(u.Email)) + 2, LEN(u.Email))) 
	as [Email Provider],
	count(*) as [Number of Users]
from Users u
	join Users uu on 
		SUBSTRING(u.Email, LEN(u.Email) - CHARINDEX('@', REVERSE(u.Email)) + 2, LEN(u.Email)) = 
		SUBSTRING(uu.Email, LEN(uu.Email) - CHARINDEX('@', REVERSE(uu.Email)) + 2, LEN(uu.Email))
group by u.Email
order by [Number of Users] desc, [Email Provider] desc

--Task 8
select
	g.Name as [Game],
	gt.Name as [Game Type],
	u.Username as [Username],
	ug.Level as [Level],
	ug.Cash as [Cash],
	c.Name as [Character]
from Users u join UsersGames ug
	on ug.UserId = u.Id join Games g
	on ug.GameId = g.Id join GameTypes gt
	on gt.Id = g.GameTypeId join Characters c
	on c.Id = ug.CharacterId
order by [Level] desc, [Username] asc, [Game]

--Task 8
select
	u.Username as [Username],
	g.Name as [Game],
	count(i.Price) as [Items Count],
	sum(i.Price) as [Items Price]
from Users u join UsersGames ug
	on ug.UserId = u.Id join Games g 
	on g.Id = ug.GameId join UserGameItems ugi
	on ugi.UserGameId = ug.Id join Items i
	on i.Id = ugi.ItemId
group by u.Username, g.Name
having count(i.Price) > 9
order by [Items Count] desc ,[Items Price] desc, [Username] asc

--Task 10
select
	i.Name as [Name],
	i.Price as [Price],
	i.MinLevel as [MinLevel],
	s.Strength as [Strength],
	s.Defence [Defence],
	s.Speed [Speed],
	s.Luck [Luck],
	s.Mind [Mind]
from Items i join [Statistics] s
	on i.StatisticId = s.Id
	and s.Mind > (
		select avg(Mind) 
		from [Statistics] 
		where Id in (select StatisticId from Items))
	and s.Luck > (
		select avg(Luck) 
		from [Statistics] 
		where Id in (select StatisticId from Items))
	and s.Speed > (
		select avg(Speed) 
		from [Statistics] 
		where Id in (select StatisticId from Items))
order by i.Name

--Task 11
select 
	i.Name as [Name],
	i.Price as [Price],
	i.MinLevel as [MinLevel],
	gt.Name as [Forbidden Game Type]
from 
	GameTypeForbiddenItems gtfi join Items i
	on gtfi.ItemId = i.Id join GameTypes gt
	on gt.Id = gtfi.GameTypeId
order by [Forbidden Game Type] desc, [Name] asc