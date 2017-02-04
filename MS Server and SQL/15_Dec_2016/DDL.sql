create database Exam_15_Dec_2015
go

use Exam_15_Dec_2015
go

create table Locations(
	Id int identity,
	Latitude float,
	Longitude float,
	constraint PK_LocationId primary key (Id))

create table Credentials(
	Id int identity,
	Email varchar(30),
	Password varchar(20),
	constraint PK_CredentialId primary key (Id))

create table Chats(
	Id int identity,
	Title varchar(32),
	StartDate date,
	IsActive bit,
	constraint PK_ChatId primary key(Id))
	
create table Users(	
	Id int identity,
	Nickname varchar(25),
	Gender char(1),
	Age int,
	LocationId int,
	CredentialId int unique,
	constraint PK_UserId primary key (Id),
	constraint FK_UserToLocation foreign key (LocationId) references Locations(Id),
	constraint FK_UserToCredential foreign key (CredentialId) references Credentials(Id))

create table Messages(
	Id int identity,
	Content varchar(200),
	SentOn date,
	ChatId int,
	UserId int,
	constraint PK_MessageId primary key (Id),
	constraint FK_MessageToUser foreign key (UserId) references Users(Id),
	constraint FK_MessageToChat foreign key (ChatId) references Chats(Id))

create table UsersChats(
	UserId int foreign key references Users(Id),
	ChatId int foreign key references Chats(Id),
	constraint PK_UsersChatsId primary key(UserId, ChatId))
