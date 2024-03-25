use atlas

create table titles
(
	title_id int not null,
	title    varchar(20) not null,
	stor_id  int not null,
	description varchar(50) not null,
	constraint pkTitles primary key (title_id)
)
go
create procedure spTitlesSelect @title_id int
as
	select *from titles where title_id = @title_id or @title_id =0
go

create procedure spTitlesInsert @title_id int,@title varchar(20), @stor_id int,@description varchar(50)
as
	select @title_id = isnull(max(title_id),0) + 1 from titles
	insert into titles values( @title_id, @title,@stor_id,@description)
go

create procedure spTitlesUpdate @title_id int,@title varchar(20), @stor_id int,@description varchar(50)
as
	update titles set title = @title, stor_id = @stor_id, description = @description
	where title_id = @title_id
go

create procedure spTitlesDelete @title_id int
as
	delete from titles where title_id = @title_id
go