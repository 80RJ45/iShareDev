use atlas

create table finca
(
	FincaID   int not null,
	Codigo    varchar(20) not null,
	Nombre    varchar(50) not null,
	constraint pkFinca primary key (FincaID)
)

create table Lote
(
	LoteID     int not null,
	FincaID    int not null,
	Codigo     varchar(20) not null,
	Productoid int not null,
	constraint pkLote primary key (loteid),
	constraint fkLoteFinca foreign key (FincaID) references finca,
	constraint fkLoteProducto foreign key (ProductoID) references Producto
)

create table Producto
(
	ProductoID int not null,
	Codigo     varchar(20)not null,
	Nombre     varchar(20) not null,
	constraint pkProducto primary key (ProductoID)
)
go

alter procedure spProductoSelect @Productoid int
as
	select *from producto where ProductoID = @Productoid or @ProductoID = 0
go

alter procedure spProductoInsert @ProductoID int output, @Codigo varchar(20), @Nombre varchar(20)
as
	select @ProductoID = isnull(max(productoid),0) + 1 from producto
	insert into producto values (@ProductoID,@Codigo,@Nombre)
go

create procedure spProductoDelete @ProductoID int
as
	delete from producto where ProductoID = @ProductoID
go

create procedure spProductoUpdate @Productoid int,@Codigo varchar(20),@Nombre varchar(20)
as
	update producto set Codigo = @Codigo, Nombre = @Nombre where ProductoID = @Productoid
go


