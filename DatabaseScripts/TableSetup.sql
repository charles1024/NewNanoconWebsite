create table ShoppingList (
	Id bigint identity not null,
	Name nvarchar(100) not null,
	Quantity int,
	[Source] nvarchar(100),
	UnitPrice int,
	primary key (Id)
)


create table Users (
	Id bigint identity not null,
	FirstName nvarchar(100) not null,
	LastName nvarchar(100) not null,
	Email nvarchar(max) not null,
	[Password] varchar(128) not null,
	Bio nvarchar(max),
	[Enabled] bit,
	IsAdmin bit,
	Primary key (Id)
)

create table Vendors (
	Id bigint identity not null,
	Name nvarchar(max) not null,
	ContactName nvarchar(100) not null,
	AddressLine1 nvarchar(max),
	AddressLine2 nvarchar(max),
	City nvarchar(100),
	[State] nvarchar(100),
	Zip	int,
	Phone varchar(15),
	Fax varchar(15),
	ContractFiled bit,
	primary key (Id)
)

create table [Events] (
	Id bigint identity not null,
	Name nvarchar(100) not null,
	[Type] int,
	UserId bigint not null,
	GameSystem nvarchar(100),
	Publisher nvarchar(100),
	Cost float,
	Sponsor nvarchar(100),
	[Time] datetime, 
	Slots int,
	[Description] nvarchar(max),
	Location bigint,
	Approved bit not null,
	Primary key (id),
	foreign key (UserId) references Users(Id)
)

Create table Locations (
	Id bigint identity not null,
	Name nvarchar(100) not null,
	primary key (id)
)


