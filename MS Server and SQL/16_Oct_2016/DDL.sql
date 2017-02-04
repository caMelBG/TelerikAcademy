create database Exam_16_Oct_2016

use Exam_16_Oct_2016

create table Towns(
	TownID int primary key identity,
	TownName varchar(30) not null)

create table Airports(
	AirportID int primary key identity,
	AirportName varchar(50) not null,
	TownID int foreign key references Towns(TownID))

create table Airlines(
	AirlineID int primary key identity,
	AirlineName varchar(30) not null,
	Nationality varchar(30) not null,
	Rating int default 0)

create table Customers(
	CustomerID int primary key identity,
	FirstName varchar(20) not null,	
	LastName varchar(20) not null,
	DateOfBirth date not null,
	Gender char(1) check(Gender = 'M' or Gender = 'F'),
	HomeTownID int foreign key references Towns(TownID))

create table Flights(
	FlightID int primary key identity,
	DepartureTime datetime not null,
	ArrivalTime datetime not null,
	Status varchar(9) not null check (Status in ('Departing', 'Delayed', 'Arrived', 'Cancelled')),
	OriginAirportID int foreign key references Airports(AirportID),
	DestinationAirportID int foreign key references Airports(AirportID),
	AirlineID int foreign key references Airlines(AirlineID))

create table Tickets(
	TicketID int primary key identity,
	Price decimal(8, 2) not null,
	Class varchar(6) not null check (Class in ('First', 'Second', 'Third')),
	Seat varchar(5) not null,
	CustomerID int foreign key references Customers(CustomerID),
	FlightID int foreign key references Flights(FlightID))

