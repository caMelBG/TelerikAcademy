--Task 13
--select Result.Model, Result.Price, Result.ManufacturerId
--from (
--	select
--		c.Model as [Model],
--		c.Price
--			+ (select avg(cam.Price)
--			from Cameras cam
--			where cam.ManufacturerId = c.ManufacturerId)
--			* (select cast(cast(len(m.Name) as float) / 100.00 as float)
--			from Manufacturers m 
--			where m.Id = c.ManufacturerId) 
--			as [Price],
--		c.ManufacturerId,
--		row_number() over (
--			partition by c.ManufacturerId 
--			order by c.ManufacturerId desc, c.Price desc, c.Model desc) 
--			as rowNumber
--	from Cameras c
--	group by c.Model, c.Price, c.ManufacturerId) as [Result]
--where  Result.rowNumber < 4

----Task 14
--declare @money int
--set @money = 54187
--declare @table table (
--	Id int, 
--	ManufacturerId int, 
--	Model varchar(50), 
--	Year int, 
--	Price money, 
--	Megapixels int)
--declare cur cursor for select * from Cameras where Price is not null order by Price asc, Id desc
--open cur

--declare @id int
--declare @manufacturerId int
--declare @model varchar(50)
--declare @year int
--declare @price money
--declare @megapixels int

--fetch next from cur into @id, @manufacturerId, @model, @year, @price, @megapixels

--while (@@fetch_status = 0 and @price <= @money)
--begin
--	set @money = @money - @price
--	insert into @table (Id, ManufacturerId, Model, Year, Price, Megapixels)
--	values (@id, @manufacturerId, @model, @year, @price, @megapixels)
--	fetch next from cur into @id, @manufacturerId, @model, @year, @price, @megapixels
--end

--close cur
--deallocate cur

--select * from @table  order by Year desc, ManufacturerId desc, Id asc

--Task 15

if object_id('dbo.usp_CreateEquipment') is not null
	drop proc usp_CreateEquipment
go

create proc usp_CreateEquipment(@modelName varchar(max))
as

declare @cameraId int, @manufactureId int, @lenseId int

declare camerasCur cursor for
select Id, ManufacturerId from Cameras where Model = @modelName
open camerasCur
fetch next from camerasCur into @cameraId, @manufactureId

while @@fetch_status = 0
begin
	declare lensesCur cursor for
	select Id from Lenses where ManufacturerId = @manufactureId
	open lensesCur
	fetch next from lensesCur into @lenseId

	if @@fetch_status <> 0
	begin
		while @@fetch_status <> 0
		begin
			set @manufactureId = @manufactureId + 1
			close lensesCur
			deallocate lensesCur

			declare lensesCur cursor for
			select Id from Lenses where ManufacturerId = @manufactureId
			open lensesCur
		end
	end
end
-----------------------------------

close cameraIdCursor
deallocate cameraIdCursor

