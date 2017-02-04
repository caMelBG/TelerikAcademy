--Task 1
select TicketID, Price, Class, Seat
from Tickets
order by TicketID

--Task 2
select CustomerID, concat(FirstName, ' ', LastName) as [FullName], Gender
from Customers
order by FullName asc, CustomerID desc 

--Task 3
select FlightID , DepartureTime, ArrivalTime
from Flights
where Status = 'Delayed'

--Task 4
select top 5 AirlineID, AirlineName, Nationality, Rating
from Airlines a
where 0 < (
	select count(*)
	from Flights f 
	where f.AirlineID = a.AirlineID)
order by Rating desc, AirlineID asc

--Task 5
select t.TicketID, a.AirportName as [Destination], concat(c.FirstName, ' ', c.LastName) as [CustomerName]
from Tickets t
	join Customers c
	on c.CustomerID = t.CustomerID
	join Flights f
	on f.FlightID = t.FlightID
	join Airports a
	on a.AirportID = f.DestinationAirportID
where Price < 5000 and Class = 'First'

--Task 6
select c.CustomerID, concat(c.FirstName, ' ', c.LastName) as [FullName], t.TownName
from Customers c
	join Towns t
	on c.HomeTownID = t.TownID
	and c.HomeTownID in (
		select tw.TownID
		from Towns tw
			join Tickets tc
			on tc.CustomerID = c.CustomerID
			join Flights f
			on f.FlightID = tc.FlightID
			join Airports a
			on a.AirportID = f.OriginAirportID
			and a.TownID = c.HomeTownID)
order by c.CustomerId asc

--Task 7
select c.CustomerID, 
	concat(c.FirstName, ' ', c.LastName) as [FullName], 
	datediff(year, c.DateOfBirth, getdate()) as [Age]
from Customers c
	join Tickets t
	on t.CustomerID = c.CustomerID
	join Flights f
	on f.FlightID = t.FlightID
	and f.Status = 'Departing'
order by [Age] asc, c.CustomerID asc

--Task 8
select top 3 c.CustomerID, concat(c.FirstName, ' ', c.LastName), t.Price, a.AirportName
from Customers c
	join Tickets t
	on t.CustomerID = c.CustomerID
	join Flights f
	on f.FlightID = t.FlightID
	and f.Status = 'Delayed'
	join Airports a
	on a.AirportID = f.DestinationAirportID
order by t.Price desc, c.CustomerID asc

--Task 9
select top 5 
	f.FlightID, 
	f.DepartureTime, 
	f.ArrivalTime, 
	a.AirportName as [Origin], 
	ai.AirportName as [Destination]
from Flights f
	join Airports a
	on a.AirportID = f.OriginAirportID
	join Airports ai
	on ai.AirportID = f.DestinationAirportID
where f.Status = 'Departing'
order by f.DepartureTime asc, f.FlightID asc

--Task 10
select c.CustomerID,
	concat(c.FirstName, ' ', c.LastName) as [Full Name], 
	datediff(year, c.DateOfBirth, getdate()) as [Age]
from Customers c
	join Tickets t
	on t.CustomerID = c.CustomerID
	join Flights f
	on f.FlightID = t.FlightID
	and f.Status = 'Arrived'
where datediff(year, c.DateOfBirth, getdate()) < 21
order by Age desc, c.CustomerID asc

--Task 11
select distinct a.AirportID, a.AirportName, @@rowcount as [Passengers]
from Airports a
	join Flights f
	on f.OriginAirportID = a.AirportID
	and f.Status = 'Departing'
where 
	@@rowcount > 0 and 
	@@rowcount = (
		select count(*)
		from Customers c
			join Tickets t
			on t.CustomerID = c.CustomerID
			and t.FlightID = f.FlightID)
order by a.AirportID asc