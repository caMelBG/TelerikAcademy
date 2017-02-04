--Task 15
create function udf_GetRadians(@degrees float)
returns float
as
begin
	set @degrees = @degrees * pi()
	set @degrees = @degrees / 180
	return @degrees
end

SELECT dbo.udf_GetRadians(22.12) AS Radians 

--Task 16
create proc udp_ChangePassword(@email varchar(30), @newPass varchar(20))
as
if 0 = (select count(Email) from Credentials where Email = @email)
begin
	raiserror('The email does''t exist!', 16, 1)
end
else
begin
	update Credentials
	set Password = @newPass
	where Email = @email
end

exec udp_ChangePassword 'abarnes0@sogou.com','new_pass'

--Task 17
create proc udp_SendMessage(@userId int, @chatId int, @content varchar(200))
as
if  exists (
		select u.Id 
		from Users  as u join UsersChats uc
			on uc.UserId = u.Id 
			and uc.UserId = @userId
			and uc.ChatId = @chatId)
begin
	insert into Messages(Content, SentOn, UserId, ChatId)
	values (@content, convert(date, getdate(), 126), @userId, @chatId)
end
else
begin
	raiserror('There is no chat with that user!', 16, 1)
end

EXEC dbo.udp_SendMessage 19, 17, 'Awesome'

--Task 18
create table MessageLogs (
	Id int primary key identity,
	Content varchar(200),
	SentOn date,
	ChatId int foreign key references Chats(Id),
	UserId int foreign key references Users(Id))

create trigger tr_InsertIntoMessagesLogsDeletedMessages
on Messages
after delete
as
	insert into MessageLogs (Content, SentOn, UserId, ChatId)
	select Content, SentOn, UserId, ChatId 
	from deleted
go

--Task 19
delete from Messages where Id = 1

alter trigger tr_DisableUsersConstraints
on Users
instead of delete
as
begin tran 
	alter table Users nocheck constraint FK_UserToCredential
	alter table Users nocheck constraint FK_UserToLocation
	delete from Messages where UserId = (select Id from deleted)
	delete from UsersChats where UserId = (select Id from deleted)
	delete from Users where Id = (select Id from deleted)
	alter table Users with check check constraint FK_UserToCredential
	alter table Users with check check constraint FK_UserToLocation
commit

drop trigger tr_InsertIntoMessagesLogsDeletedMessages
delete from Users where Id = 1