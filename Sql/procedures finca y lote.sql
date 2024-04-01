create procedure spFincaSelect @FincaID int
as
	Select *from Finca where FincaID = @fincaid or @fincaid = 0
go

create procedure spFincaInsert @FincaID int output, @Codigo varchar(20),@Nombre varchar(50)
as
	select @FincaID = isnull(max(FincaID),0) +1 from finca
	insert into finca values (@FincaID,@Codigo,@Nombre)
go

create procedure spFincaUpdate @fincaID int,@Codigo varchar(20),@Nombre varchar(50)
as
	update Finca set Codigo = @Codigo, Nombre = @Nombre where FincaID = @fincaID
go

create procedure spFincaDelete @fincaID int
as
	delete from finca where fincaid = @FincaID
go

---------------------------------------------------------------------------
alter procedure spLoteSelect @FincaID int
as
	select *from Lote where FincaID = @FincaID or @FincaID = 0
go

create procedure spLoteInsert @LoteID int output,@FincaID int,@Codigo varchar(20),@ProductoID int
as
	select @LoteID = isNull(max(LoteID),0) + 1 from Lote
	insert into Lote values(@LoteID,@FincaID,@Codigo,@ProductoID)
go

create procedure spLoteUpdate @LoteID int, @FincaID int, @Codigo varchar(20),@ProductoID int
as
	update Lote set FincaID = @FincaID, Codigo = @Codigo, ProductoID = @ProductoID
		where LoteID = @LoteID
go

create procedure spLoteDelete @LoteID int
as
	delete from Lote where LoteID = @LoteID
go