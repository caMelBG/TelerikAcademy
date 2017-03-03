--Task 15
create table Monasteries(
	Id int primary key identity(1, 1), 
	Name varchar(50), 
	CountryCode char(2) foreign key references Countries(CountryCode))

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('S?mela Monastery', 'TR')

alter table Continents
add IsDeleted bit default(0)

update Continents
set IsDeleted = 1
where ContinentCode in (
	select c.ContinentCode
	from Continents c
	join Countries cc on cc.ContinentCode = c.ContinentCode
	join CountriesRivers cr on cr.CountryCode = cc.CountryCode
	group by c.ContinentCode
	having count(cr.RiverId) > 3)

select
	m.Name,
	c.CountryName
from Monasteries m
join Countries c on c.CountryCode = m.CountryCode

--Task 16
update Countries
set CountryName = 'Burma'
where CountryName = 'Myanmar'

declare @countryCode char(2) = (select CountryCode from Countries where CountryName = 'Tanzania')
insert into Monasteries(Name, CountryCode)
values ('Hanga Abbey', @countryCode)

declare @countryCode char(2) = (select CountryCode from Countries where CountryName = 'Myanmar')
insert into Monasteries(Name, CountryCode)
values ('Myin-Tin-Daik', @countryCode)

select
	c.ContinentName,
	cc.CountryName,
	(select count(*) 
	from Monasteries m 
	where m.CountryCode = cc.CountryCode)
	as [MonasteriesCount]
from Continents c
join Countries cc on cc.ContinentCode = c.ContinentCode
order by [MonasteriesCount] desc

--Task 17
select
	m.MountainRange as ['name'],
	(select p.PeakName as [name], p.Elevation as [elevation]
	from Peaks p
	where p.MountainId = m.Id
	for json path) as [peaks]
from Mountains m
order by m.MountainRange
for json path, root('mountains')