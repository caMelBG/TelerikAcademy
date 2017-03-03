--Task 13
create table FriendlyMatches(
	Id int primary key identity, 
	HomeTeamID int foreign key references Teams(Id), 
	AwayTeamId int foreign key references Teams(Id), 
	MatchDate date)

INSERT INTO Teams(TeamName) VALUES
 ('US All Stars'),
 ('Formula 1 Drivers'),
 ('Actors'),
 ('FIFA Legends'),
 ('UEFA Legends'),
 ('Svetlio & The Legends')
GO

INSERT INTO FriendlyMatches(
  HomeTeamId, AwayTeamId, MatchDate) VALUES
  
((SELECT Id FROM Teams WHERE TeamName='US All Stars'), 
 (SELECT Id FROM Teams WHERE TeamName='Liverpool'),
 '30-Jun-2015 17:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Formula 1 Drivers'), 
 (SELECT Id FROM Teams WHERE TeamName='Porto'),
 '12-May-2015 10:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Actors'), 
 (SELECT Id FROM Teams WHERE TeamName='Manchester United'),
 '30-Jan-2015 17:00'),

((SELECT Id FROM Teams WHERE TeamName='FIFA Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='UEFA Legends'),
 '23-Dec-2015 18:00'),

((SELECT Id FROM Teams WHERE TeamName='Svetlio & The Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='Ludogorets'),
 '22-Jun-2015 21:00')

GO

select
	htm.TeamName as [HomeTeam],
	atm.TeamName as [AwayTeam],
	fm.MatchDate as [MatchDate]
from FriendlyMatches fm
join Teams htm on fm.HomeTeamID = htm.Id
join Teams atm on fm.AwayTeamId = atm.Id
order by fm.MatchDate desc

--Task 14
alter table Leagues
add IsSeasonal bit default(0)

insert into TeamMatches(
	HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
values
	(
	(select Id from Teams where TeamName = 'Empoli'),
	(select Id from Teams where TeamName = 'Parma'),
	2, 2, '19-Apr-2015 16:00',
	(select Id from Leagues where LeagueName = 'Italian Serie A')),
	(
	(select Id from Teams where TeamName = 'Internazionale'),
	(select Id from Teams where TeamName = 'AC Milan'),
	0, 0, '19-Apr-2015 21:45',
	(select Id from Leagues where LeagueName = 'Italian Serie A'))

update Leagues
set IsSeasonal = 'true'
where Id in (select LeagueId from TeamMatches)

select
	htm.TeamName as [HomeTeam],
	tm.HomeGoals as [HomeGoals],
	atm.TeamName as [AwayTeam],
	tm.AwayGoals as [AwayGoals],
	l.LeagueName as [LeagueName]
from TeamMatches tm
	join Leagues l 
	on l.Id = tm.LeagueId 
	and l.IsSeasonal = 'true'
	join Teams htm
	on htm.Id = tm.HomeTeamId
	join Teams atm
	on atm.Id = tm.AwayTeamId
where tm.MatchDate > '10-Apr-2015'
order by [LeagueName] asc, tm.HomeGoals desc, tm.AwayGoals desc

--Task 15

declare @json varchar(max)
set @json = 
(select
	t.TeamName 
	as [name],
	reverse(
	stuff(
	reverse(
	'[' + (
		select
			cast(
					concat
					(
					'{"', homeTeam.TeamName, '": ', teamMatches.HomeGoals, ',',
					'"', awayTeam.TeamName, '": ', teamMatches.AwayGoals, ',',
					'"', 'date', '": ', format(teamMatches.MatchDate, 'dd/MM/yyyy'), '}'
					)
				+ ',' as varchar(max)
				)
		from TeamMatches teamMatches 
		join Teams homeTeam
		on homeTeam.Id = teamMatches.HomeTeamId
		join Teams awayTeam
		on awayTeam.Id = teamMatches.AwayTeamId
		where t.TeamName in (homeTeam.TeamName, awayTeam.TeamName)
		order by teamMatches.MatchDate desc
		for xml path ('')
	)
	), 1, 1, '')
	) + ']'
	as [matches]
from Teams t
where t.CountryCode = 'BG'
for json auto, root('teams'))

set @json = replace(@json, '\', '')
select @json
