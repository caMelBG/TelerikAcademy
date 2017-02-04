--Task 1
select a.Name, case 
		when a.Description is not null then a.Description
		else 'No description' end
		as [Description]
from Albums a
order by a.Name asc

--Task 2
select p.Title, a.Name
from Photographs p
	join AlbumsPhotographs ap
	on ap.PhotographId = p.Id
	join Albums a
	on a.Id = ap.AlbumId
order by a.Name asc,p.Title desc

--Task 3
select p.Title, p.Link, p.Description, c.Name as [CategoryName], u.FullName as [Author]
from Photographs p
	join Categories c
	on c.Id = p.CategoryId
	join Users u
	on u.Id = p.UserId
where p.Description is not null
order by p.Title

--Task 4
select 
	u.Username,
	u.FullName,
	u.BirthDate,
	case 
		when p.Title is not null 
		then p.Title 
		else 'No photos' 
		end as [Photo]
from Users u
	left join Photographs p
	on p.UserId = u.Id
where u.BirthDate like('%Jan%')
order by u.FullName asc

--Task 5
select p.Title as [Title], c.Model as [CameraModel], l.Model as [LensModel]
from Photographs p
	join Equipments e
	on e.Id = p.EquipmentId
	join Cameras c
	on c.Id = e.CameraId
	join Lenses l
	on l.Id = e.LensId
order by p.Title asc

--Task 6
select 
	photo.Title as [Title], 
	category.Name as [Category Name],
	camera.Model as [Model],
	manufacturer.Name as [Manufacturer Name],
	camera.Megapixels as [Megapixels],
	camera.Price as [Price]
from Categories category
	join Photographs photo
	on photo.CategoryId = category.Id
	join Equipments equipments
	on equipments.Id = photo.EquipmentId
	join Cameras camera
	on camera.Id = equipments.CameraId
	join Manufacturers manufacturer
	on manufacturer.Id = camera.ManufacturerId
where camera.Price = (
	select max(cm.Price)
	from Cameras cm
		join Equipments e
		on e.CameraId = cm.Id
		join Photographs p
		on p.EquipmentId = e.Id
		join Categories ct
		on ct.Id = p.CategoryId
	where ct.Id = category.Id)
order by camera.Price desc, photo.Title asc

--Task 7
select m.Name, c.Model, c.Price 
from Cameras c
	join Manufacturers m
	on m.Id = c.ManufacturerId
where c.Price > (select avg(Price) from Cameras)
order by c.Price desc, c.Model asc

--Task 8
select m.Name, sum(l.Price) as [Total Price]
from Manufacturers m
	join Lenses l
	on l.ManufacturerId = m.Id
group by m.Name
order by m.Name

--Task 9
select u.FullName, m.Name as [Manufacturer], c.Model as [Camera Model], c.Megapixels
from Cameras c
	join Equipments e
	on e.CameraId = c.Id
	join Users u
	on u.EquipmentId = e.Id
	join Manufacturers m
	on m.Id = c.ManufacturerId
where c.Year < 2015
order by u.FullName asc

--Task 10
select l.Type, count(*) as [Count]
from Lenses l
group by l.Type
order by [Count] desc, l.Type asc

--Task 11
select u.Username, u.FullName
from Users u
order by len(concat(u.Username, ',', u.FullName)) asc, u.BirthDate desc

--Task 12
select distinct m.Name
from Manufacturers m
where 
	0 = (select count(*) from Cameras c where c.ManufacturerId = m.Id) and
	0 = (select count(*) from Lenses l where l.ManufacturerId = m.Id)