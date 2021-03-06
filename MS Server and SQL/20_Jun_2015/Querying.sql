--Task 1
select PeakName
from Peaks
order by PeakName asc

--Task 2
select top 30
	c.CountryName,
	c.Population
from Countries c
where c.ContinentCode = 'EU'
order by c.Population desc, c.CountryName asc

--Task 3
select
	c.CountryName,
	c.CountryCode,
	case
	when c.CurrencyCode = 'EUR'
	then 'Euro'
	else 'Not Euro'
	end
from Countries c
order by c.CountryName asc

--Task 4
select
	c.CountryName,
	c.IsoCode
from Countries c
where lower(c.CountryName) like '%a%a%a%'
order by c.IsoCode asc

--Task 5
select
	p.PeakName,
	m.MountainRange,
	p.Elevation
from Peaks p 
	join Mountains m 
	on m.Id = p.MountainId
order by p.Elevation desc

--Task 6
select
	p.PeakName,
	m.MountainRange,
	c.CountryName,
	cc.ContinentName
from Peaks p
	join Mountains m
	on m.Id = p.MountainId
	join MountainsCountries mc
	on mc.MountainId = m.Id
	join Countries c
	on c.CountryCode = mc.CountryCode
	join Continents cc
	on cc.ContinentCode = c.ContinentCode
order by p.PeakName asc, c.CountryName asc

--Task 7
select
	r.RiverName as [River],
	case
	when 2 < (
		select count(cr.RiverId) 
		from CountriesRivers cr 
		where cr.RiverId = r.Id)
	then (
		select count(cr.RiverId) 
		from CountriesRivers cr 
		where cr.RiverId = r.Id)
	end
	as [Countries Count]
from Rivers r
order by r.RiverName

--Task 8
select
	max(p.Elevation) as [MaxElevation],
	min(p.Elevation) as [MinElevation],
	avg(p.Elevation) as [AverageElevation]
from Peaks p

--Task 9
select
	c.CountryName,
	cc.ContinentName,
	(
	select count(cr.RiverId) 
	from CountriesRivers cr 
	where cr.CountryCode = c.CountryCode) 
	as [RiverCount],
	isnull((
		select sum(r.Length)
		from CountriesRivers cr join Rivers r
		on r.Id = cr.RiverId
		where cr.CountryCode = c.CountryCode), 0)
	as [TotalLength]
from Countries c
	join Continents cc
	on cc.ContinentCode = c.ContinentCode
order by [RiverCount] desc, [TotalLength] desc

--Task 10
select
	c.CurrencyCode,
	c.Description,
	(
	select count(*)
	from Countries cc
	where cc.CurrencyCode = c.CurrencyCode)
	as [NumberOfCountries]
from Currencies c
order by [NumberOfCountries] desc, c.Description asc

--Task 11
select
	c.ContinentName as [ContinentName],
	sum(convert(numeric, cc.AreaInSqKm)) as [CountriesArea],
	sum(convert(numeric, cc.Population)) as [CountriesPopulation]
from Continents c
	join Countries cc
	on c.ContinentCode = cc.ContinentCode
group by c.ContinentName
order by [CountriesPopulation] desc

--Task 12
select
	c.CountryName
	as [CountryName],
	(
	select top 1 p.Elevation
	from Peaks p join Mountains m 
	on m.Id = p.MountainId join MountainsCountries mc
	on mc.MountainId = m.Id and mc.CountryCode = c.CountryCode
	order by p.Elevation desc)
	as [HighestPeakElevation],
	(
	select top 1 r.Length 
	from CountriesRivers cr join Rivers r
	on r.Id = cr.RiverId
	where cr.CountryCode = c.CountryCode
	order by r.Length desc)
	as [LongestRiverLength]
from Countries c
order by 
	[HighestPeakElevation] desc, 
	[LongestRiverLength] desc, 
	[CountryName] asc

--Task 13
select
	p.PeakName,
	r.RiverName,
	lower(concat(p.PeakName, substring(r.RiverName, 2, len(r.RiverName))))
	as [Mix]
from Rivers r join Peaks p
on lower(substring(reverse(p.PeakName), 1, 1)) = lower(substring(r.RiverName, 1, 1))
order by [Mix]

--Task 14
select
	c.CountryName as [CountryName],
	isnull(p.PeakName, '(no highest peak)') as [Highest Peak Name],
	isnull(p.Elevation, 0) as [Highest Peak Elevation],
	case
	when p.PeakName is null
	then '(no mountain)'
	else m.MountainRange
	end
  as [Mountain]
from Countries c
	left join MountainsCountries mc on mc.CountryCode = c.CountryCode
	left join Mountains m on m.Id = mc.MountainId
	left join Peaks p on p.MountainId = m.Id and p.Elevation = (
		select max(sp.Elevation) 
		from Peaks sp 
		join Mountains sm
		on sp.MountainId = sm.Id
		join MountainsCountries smc 
		on smc.MountainId = sm.Id 
		group by smc.CountryCode
		having smc.CountryCode = c.CountryCode)
order by c.CountryName asc

--Task 14
select
	c.CountryName as [CountryName],
	isnull(p.PeakName, '(no highest peak)') as [Highest Peak Name],
	isnull(p.Elevation, 0) as [Highest Peak Elevation],
	isnull(m.MountainRange, '(no mountain)') as [Mountain]
from Countries c 
left join MountainsCountries mc on mc.CountryCode = c.CountryCode
left join Mountains m on m.Id = mc.MountainId
left join Peaks p on p.MountainId = m.Id
where p.Elevation is null or p.Elevation = (
	select max(sp.Elevation)
	from MountainsCountries smc
		join Mountains sm on sm.Id = smc.MountainId
		join Peaks sp on sp.MountainId = sm.Id
	where smc.CountryCode = c.CountryCode)
order by [CountryName] asc

