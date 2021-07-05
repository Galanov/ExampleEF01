
USE master

DROP DATABASE IF EXISTS ZoomShoesDb
GO

CREATE DATABASE ZoomShoesDb
GO

USE ZoomShoesDb
GO

Create table Colors(
	Id bigint Identity(1,1) not null,
	Name nvarchar(max) not null,
	MainColor nvarchar(max) not null,
	HighlightColor nvarchar(max) not null,
	Constraint PK_Colors Primary Key(Id));

Set Identity_insert dbo.Colors on
Insert dbo.Colors (Id, Name, MainColor, HighlightColor)
	Values
		(1,N'Red Flash', N'Red', N'Yellow'),
		(2, N'Cool Blue', N'Dark Blue', N'Light Blue'),
		(3, N'Midnight',N'Black', N'Black'),
		(4, N'Beacon' , N'Yellow', N'Green')
Set Identity_Insert dbo.Colors off
GO

select * from dbo.Colors


create table Shoes(
	Id bigint identity(1,1) not null,
	Name nvarchar(max) not null,
	ColorId bigint not null,
	Price decimal(18,2) not null,
	Constraint PK_Shoes primary key (Id),
	Constraint FK_Shoes_Colors Foreign key(ColorId) References dbo.Colors(Id)
	)
Set identity_insert dbo.Shoes on
insert dbo.Shoes (Id, Name, ColorId, Price)
	Values(1, N'Road Rocket', 2, 145.0000),
		(2, N'Trail Blazer',4, 150.0000),
		(3, N'All Terrain Monster' , 3, 250.0),
		(4, N'Track Star', 1, 120.0)
set identity_insert dbo.Shoes off
go

create table SalesCampaigns(
	Id bigint Identity(1,1) not null,
	Slogan nvarchar(max) null,
	MaxDiscount int null,
	LaunchDate date null,
	ShoeId bigint not null,
	constraint PK_SalesCampaigns primary key (Id),
	constraint FK_SalesCampaigns_Shoes foreign key(ShoeId)
		references dbo.Shoes (Id),
	index IX_SalesCampaigns_ShoeId Unique (ShoeId))
	
set identity_insert dbo.SalesCampaigns on
insert dbo.SalesCampaigns (Id, Slogan, MaxDiscount,
	LaunchDate, ShoeId)
Values
	(1, N'Jet-Powered Shoes for the Win!', 20, CAST(N'2019-01-01' as date),1),
	(2, N'"Blaze" a Trial with Side-Mounted Flame Throwers', 15, CAST(N'2019-05-03' as date), 2),
	(3, N'All Surfaces. All Weathers. Victory Guaranteed.', 5, CAST(N'2020-01-01' as date), 3),
	(4, N'Contains an Actual Star to Dazzle Competitors', 25, CAST(N'2020-01-01' as date), 4)
set identity_insert dbo.SalesCampaigns off
go


Create table Categories(
	Id bigint Identity(1,1) not null,
	Name nvarchar(max) not null,
	Constraint PK_Categories primary key (Id))

set identity_insert dbo.Categories on
Insert dbo.Categories (Id, Name)
Values
	(1, N'Road/Tarmac'), 
	(2, N'Track'), 
	(3, N'Trail'),
	(4, N'Road to Trail')
set identity_insert dbo.Categories off
go

create table ShoeCategoryJunction(
	Id bigint identity(1,1) not null,
	ShoeId bigint not null,
	CategoryId bigint not null,
	Constraint PK_ShoeCategoryJunction Primary key (Id),
	constraint FK_ShoeCategoryJunction_Categories foreign key(CategoryId) references dbo.Categories (Id),
	constraint FK_ShoeCategoryJunction_Shoes foreign key (ShoeId) references dbo.Shoes (Id))

set identity_insert dbo.ShoeCategoryJunction on
insert dbo.ShoeCategoryJunction (Id, ShoeId, CategoryId)
Values
	(1,1,1),
	(2,2,3),
	(3,2,4),
	(4,3,1),
	(5,3,2),
	(6,3,3),
	(7,3,4),
	(8,4,2)
set identity_insert dbo.ShoeCategoryJunction off
go