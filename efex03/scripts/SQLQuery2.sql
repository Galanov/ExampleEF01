
-- Модификация БД
create table Fittings(
	Id bigint Identity(1,1) not null,
	Name nvarchar(max) not null,
	constraint PK_Fittings Primary Key(id))
GO

set Identity_insert Fittings on
insert Fittings(Id, Name)
	Values(1, N'Narrow'),
		(2, N'Standard'),
		(3, N'Wide'),
		(4, N'Big Foot')
set Identity_insert Fittings off
GO

Alter table Shoes
	Add FittingId bigint
Alter table Shoes
	ADD CONSTRAINT FK_Shoes_Fittings FOREIGN KEY(FittingId) REFERENCES Fittings (Id)
GO

UPDATE Shoes SET FittingId = 2
GO

SELECT * FROM Shoes
