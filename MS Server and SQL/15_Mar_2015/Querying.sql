--Task 1
select t.TeamName
from Teams t
order by t.TeamName asc

--Task 2
select top 30 c.CountryName, c.Population
from Countries c
order by c.Population desc, c.CountryName

--Task 3
select 
	c.CountryName, 
	c.CountryCode,
	case
	when c.CurrencyCode = 'EUR'
	then 'Inside'
	else 'Outside'
	end as [EuroZone]
from Countries c
order by c.CountryName asc

--Task 4
select *
from Teams t
where t.TeamName like '%[1-9]%'
order by t.CountryCode

--Task 5
select [ht].CountryName, [at].CountryName, [it].MatchDate
from InternationalMatches as [it]
	join Countries as [ht]
	on [it].HomeCountryCode = [ht].CountryCode
	join Countries as [at]
	on [it].AwayCountryCode = [at].CountryCode
order by [it].MatchDate desc

--Task 6
select
	t.TeamName,
	l.LeagueName,
	case
	when exists (select CountryCode from Countries where CountryCode = l.CountryCode)
	then (select CountryName from Countries where CountryCode = l.CountryCode)
	else 'International'
	end as [League Country]
from Teams t
	join Leagues_Teams lt
	on lt.TeamId = t.Id
	join Leagues l
	on l.Id = lt.LeagueId
order by t.TeamName asc

--Task 7
select 
	t.TeamName,
	(select count(*) 
	from TeamMatches tm 
	where t.Id = tm.AwayTeamId 
	or t.Id = tm.HomeTeamId) 
	as [Matches Count]
from Teams t
where 1 < (
	select count(*) 
	from TeamMatches tm 
	where t.Id = tm.AwayTeamId 
	or t.Id = tm.HomeTeamId)
order by t.TeamName

--Task 8
select
	l.LeagueName,
	(select count(*) from Teams t where t.CountryCode = l.CountryCode) as [Teams],
	(select count(*) from TeamMatches tm where tm.LeagueId = l.Id) as [Matches],
	(select count(tm.AwayGoals) + count(tm.HomeGoals) from TeamMatches tm where tm.LeagueId = l.Id) 
	as [Average Goals]
from Leagues l
order by [Teams] desc, [Matches] desc

--Task 9
select
	t.TeamName,
	isnull((select sum(tm.HomeGoals) from TeamMatches tm where tm.HomeTeamId = t.Id), 0) + 
	isnull((select sum(tm.AwayGoals) from TeamMatches tm where tm.AwayTeamId = t.Id), 0)
	as [Total Goals]
from Teams t
order by [Total Goals] desc

--Task 10
select
	ftm.MatchDate as [First Date],
	stm.MatchDate as [Second Date]
from TeamMatches ftm, TeamMatches stm
where 
	datepart(day, ftm.MatchDate) = datepart(day, stm.MatchDate)
	and ftm.MatchDate < stm.MatchDate
	and ftm.Id <> stm.Id
order by [First Date] desc, [Second Date] desc

--Task 11
select
	concat(lower(ft.TeamName), 
		lower(substring(reverse(st.TeamName), 2, len(st.TeamName))))
	as [Mix]
from Teams ft, Teams st
where 
	substring(ft.TeamName, len(ft.TeamName), 1) = 
	substring(reverse(st.TeamName), 1, 1)
order by [Mix]

--Task 12
select
	c.CountryName,
	isnull((select count(*) from InternationalMatches im where im.HomeCountryCode = c.CountryCode), 0) +
	isnull((select count(*) from InternationalMatches im where im.AwayCountryCode = c.CountryCode), 0)
	as [International Matches],
	isnull((select count(*) from TeamMatches tm join Leagues l on l.Id = tm.LeagueId and l.CountryCode = c.CountryCode), 0)
	as [Team Matches]
from Countries c
order by [International Matches] desc, [Team Matches] desc