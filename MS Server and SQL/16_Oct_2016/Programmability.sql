--Task 12
create proc usp_SubmitReview(
	@CustomerID int, 
	@ReviewContent varchar(255), 
	@ReviewGrade int,  
	@AirlineName varchar(30))
as
begin
declare @Count int, @AirlineID int, @Row int
set @Count = (
	select count(*) 
	from Airlines 
	where AirlineName = @AirlineName)
	if @Count = 0
		begin
		raiserror('Airline does not exist.', 16, 1) rollback
		end

set @AirlineID = (
	select AirlineID 
	from Airlines 
	where AirlineName = @AirlineName)

set @Row = (
	select count(*) 
	from CustomerReviews)
insert into CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID)
values (@Row + 1, @ReviewContent, @ReviewGrade, @AirlineID, @CustomerID)
end

--Task 13
alter proc usp_PurchaseTicket(
	@CustomerID int, 
	@FlightID int, 
	@TicketPrice decimal(8, 2), 
	@Class varchar(6), 
	@Seat varchar(5))
as
if (@TicketPrice > (select Balance from CustomerBankAccounts ca where ca.CustomerID = @CustomerID))
begin
	raiserror('Insufficient bank account balance for ticket purchase.', 16, 1)
end
else
begin
	begin tran
		update CustomerBankAccounts
		set Balance = Balance - @TicketPrice
		where CustomerID = @CustomerID
			
		declare @Row int
		set @Row = (select count(*) from Tickets)
		insert into Tickets(TicketID, Price, Class, Seat, CustomerID, FlightID)
		values (@Row + 1, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)
	commit
end

--Task 14
create table ArrivedFlights(
	FlightID int primary key,
	ArrivalTime datetime not null,
	Origin varchar(50) not null,
	Destination varchar(50) not null,
	Passengers int not null)

alter trigger TR_InsertIntoArrivedFlights 
on Flights
for update
as
begin
	if (select top 1 Status from inserted) in ('Arrived')
	begin
	insert into ArrivedFlights(FlightID, ArrivalTime, Origin, Destination, Passengers)
	select 
		d.FlightID, 
		d.ArrivalTime, 
		oa.AirportName, 
		da.AirportName, 
		(select count(*) from Tickets t where t.FlightID = d.FlightID)
	from deleted as d
	join Airports oa on oa.AirportID = d.OriginAirportID
	join Airports da on da.AirportID = d.DestinationAirportID

	update Flights
	set Status = 'Arrived'
	where FlightID = (select FlightID from deleted)
	end
end
go

update Flights
set Status = 'Arrived'
where FlightID = 5
