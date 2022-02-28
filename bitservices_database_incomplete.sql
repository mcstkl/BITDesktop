create database BITServices;
GO
use BITServices;
GO
create table Customer(
	customerId int identity(1,1) primary key,
	firstName nvarchar(30) not null,
	lastName nvarchar(30) not null,
	email nvarchar(30) not null,
	phone nchar(10) not null,
	[address] nvarchar(30) not null,
	suburb nvarchar(20) not null,
	[state] nvarchar(3) not null,
	postcode nchar(4) not null,
);
GO

create table AccessLevel(
	accessId nchar(1) primary key,
	accessTypeName nvarchar(20) not null
);
GO

create table Staff(
	staffId int identity(1,1) primary key,
	firstName nvarchar(30) not null,
	lastName nvarchar(30) not null,
	username nvarchar(30) not null,
	email nvarchar(30) not null,
	phone nchar(10) not null,
	[password] nvarchar(30) not null,
	accessId nchar(1) references AccessLevel(accessId)
);
GO


create table Contractor(
	contractorId int identity(1,1) primary key,
	firstName nvarchar(30) not null,
	lastName nvarchar(30) not null,
	email nvarchar(30) not null,
	phone nchar(10) not null,
	[address] nvarchar(30) not null,
	suburb nvarchar(20) not null,
	[state] nvarchar(3) not null,
	postcode nchar(4) not null,
);
GO


create table ContractorSkills(
	contractorId int references Contractor(contractorId),
	skills nvarchar(20) not null
);
GO

create table TimeSlot(
	timeSlotId int identity(1,1) primary key,
	startTime time not null,
	endTime time not null
);
GO



--- DATA ---
insert into Customer (firstName,lastName,email,phone,[address],suburb,[state],postcode)
values("Linda", "Lane", "myemail@yahoo.com", "121212", "Street Street 11", "Manly", "NSW", "1234");
insert into Customer(firstName,lastName,email,phone,[address],suburb,[state],postcode)
values("Peter", "Parker", "myotheremail@yahoo.com", "12555", "Green Way 12", "Chatswood", "NSW", "5555");

insert into AccessLevel (accessId,accessTypeName)
values ("A", "Admin");
insert into AccessLevel (accessId,accessTypeName)
values ("C", "Coordinator");

insert into Staff (firstName,lastName,username,email,phone,[password],accessId)
values("Sharon", "Stein", "sstein", "sstein@gmail.com", "123123", "password", "C");

insert into Contractor(firstName,lastName,email,phone,[address],suburb,[state],postcode)
values("Lex", "Luthor", lluthor@gmail.com, "4545453", "Stone Street 33", "Dee Why", "NSW", "8888");