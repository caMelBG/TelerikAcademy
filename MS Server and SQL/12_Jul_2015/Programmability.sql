--Task 12
declare @itemId int, @userGameId int, @price money, @name varchar(max)
declare itemsCursor cursor for
select Id, Price, Name from Items where Name in (
	'Blackguard', 
	'Bottomless Potion of Amplification', 
	'Eye of Etlich (Diablo III)', 
	'Gem of Efficacious Toxin', 
	'Golden Gorget of Leoric',
	'Hellfire Amulet')
open itemsCursor
fetch next from itemsCursor into @itemId, @price, @name
while @@fetch_status = 0
begin
	set @userGameId = (
		select ug.Id 
		from UsersGames ug 
		join Users u 
		on ug.UserId = u.Id and u.Username = 'Alex'
		join Games g
		on ug.GameId = g.Id and g.Name = 'Edinburgh')
	
	--Insert into UserGamesItems the current item
	insert into UserGameItems(UserGameId, ItemId)
	values (@userGameId, @itemId)

	--Take the money from user 'Alex' in game 'Edinburgh'
	update UsersGames
	set Cash = Cash - @price
	where Id = @userGameId

	fetch next from itemsCursor into @itemId, @price, @name	
end
close itemsCursor
deallocate itemsCursor
---------------------------------------------------------------------

--Task 13
declare @itemId int, @userGameId int, @itemPrice money
declare itemsCursor cursor for
select Id, Price from Items where (MinLevel between 11 and 12) or (MinLevel between 19 and 21)
open itemsCursor
fetch next from itemsCursor 
into @itemId, @itemPrice

set @userGameId = (
	select ug.Id 
	from UsersGames ug
		join Games g on g.Id = ug.GameId
		join Users u on u.Id = ug.UserId
	where u.Username = 'Stamat' and g.Name = 'Safflower')

while @@fetch_status = 0
begin
	update UsersGames
	set Cash = Cash - @itemPrice
	where Id = @userGameId

	insert into UserGameItems(UserGameId, ItemId)
	values (@userGameId, @itemId)

	fetch next from itemsCursor 
	into @itemId, @itemPrice
end

close itemsCursor
deallocate itemsCursor

delete
from UserGameItems
where UserGameId = 110

Task 14

select dbo.fn_CashInUsersGames('Bali')

create function fn_CashInUsersGames(@gameName varchar(max))
returns money
as
begin
	declare @index int = 1, @currCash money = 0, @sumCash money = 0
	declare cashCursor cursor for 
	select ug.Cash
	from UsersGames ug
		join Games g 
		on g.Id = ug.GameId 
		and g.Name like @gameName
	order by ug.Cash desc

	open cashCursor
	fetch next from cashCursor into @currCash
	while @@fetch_status = 0
	begin
		if @index % 2 > 0
		begin
			set @sumCash = @sumCash + @currCash
		end

		set @index = @index + 1
		fetch next from cashCursor into @currCash
	end

	close cashCursor
	deallocate cashCursor
	return @sumCash
end
