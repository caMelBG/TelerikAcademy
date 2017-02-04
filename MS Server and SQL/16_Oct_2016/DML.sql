INSERT INTO Towns(TownName)
VALUES
('Sofia'),
('Moscow'),
('Los Angeles'),
('Athene'),
('New York')

INSERT INTO Airports(AirportName, TownID)
VALUES
('Sofia International Airport', 1),
('New York Airport', 5),
('Royals Airport', 1),
('Moscow Central Airport', 2)

INSERT INTO Airlines(AirlineName, Nationality, Rating)
VALUES
('Royal Airline', 'Bulgarian', 200),
('Russia Airlines', 'Russian', 150),
('USA Airlines', 'American', 100),
('Dubai Airlines', 'Arabian', 149),
('South African Airlines', 'African', 50),
('Sofia Air', 'Bulgarian', 199),
('Bad Airlines', 'Bad', 10)

INSERT INTO Customers(FirstName, LastName, DateOfBirth, Gender, HomeTownID)
VALUES
('Cassidy', 'Isacc', '19971020', 'F', 1),
('Jonathan', 'Half', '19830322', 'M', 2),
('Zack', 'Cody', '19890808', 'M', 4),
('Joseph', 'Priboi', '19500101', 'M', 5),
('Ivy', 'Indigo', '19931231', 'F', 1)

insert into Flights (DepartureTime, ArrivalTime, Status, OriginAirportID, DestinationAirportID, AirlineID)
values 
	('2016-10-13 06:00 AM', '2016-10-13 10:00 AM', 'Delayed', 3, 6, 1),
	('2016-10-12 12:00 PM', '2016-10-12 12:01 PM', 'Departing', 3, 5, 2),
	('2016-10-14 03:00 PM', '2016-10-20 04:00 AM', 'Delayed', 6, 4, 4),
	('2016-10-12 01:24 PM', '2016-10-12 4:31 PM', 'Departing', 5, 3, 3),
	('2016-10-12 08:11 AM', '2016-10-12 11:22 PM', 'Departing', 6, 3, 1),
	('1995-06-21 12:30 PM', '1995-06-22 08:30 PM', 'Arrived', 4, 5, 5),
	('2016-10-12 11:34 PM', '2016-10-13 03:00 AM', 'Departing', 4, 6, 2),
	('2016-11-11 01:00 PM', '2016-11-12 10:00 PM', 'Delayed', 6, 5, 1),
	('2015-10-01 12:00 PM', '2015-10-01 12:00 PM', 'Arrived', 3, 4, 1),
	('2016-10-12 07:30 PM', '2016-10-13 12:30 PM', 'Departing', 4, 3, 7)

insert into Tickets(Price, Class, Seat, CustomerID, FlightID)
values
	(3000.00, 'First', '233-A', 3, 11),
	(1799.90, 'Second', '123-D', 1, 4),
	(1200.50, 'Second', '12-Z', 2, 8),
	(410.68, 'Third', '45-Q', 2, 11),
	(560.00, 'Third', '201-R', 4, 9),
	(2100.00, 'Second', '13-T', 1, 12),
	(5500.00, 'First', '98-O', 2, 10)

update Flights
set Status = 'Arrived'
where AirlineID = 1

update Tickets
set Price = Price * 1.5
from Tickets t
	join Flights f
	on t.FlightID = f.FlightID
	join Airlines a
	on f.AirlineID = a.AirlineID
where a.Rating = (select max(Rating) from Airlines)

create table CustomerReviews(
	ReviewID int primary key,
	ReviewContent varchar(255) not null,
	ReviewGrade smallint, check(ReviewGrade between 0 and 10),
	AirlineID int foreign key references Airlines(AirlineID),
	CustomerID int foreign key references Customers(CustomerID))

create table CustomerBankAccounts(	
	AccountID int primary key,
	AccountNumber varchar(10) not null unique,
	Balance decimal(10, 2) not null,
	CustomerID int foreign key references Customers(CustomerID))

insert into CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID)
values
	(1, 'Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
	(2, 'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
	(3, 'Meh...', 5, 4, 3),
	(4, 'Well Ive seen better, but Ive certainly seen a lot worse...', 7, 3, 5)

insert into CustomerBankAccounts(AccountID, AccountNumber, Balance, CustomerID)
values
	(1, '123456790', 2569.23, 1),	
	(2, '18ABC23672', 14004568.23, 2),	
	(3, 'F0RG0100N3', 19345.20, 3)

