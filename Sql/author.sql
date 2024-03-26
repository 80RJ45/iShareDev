use atlas

create table author
(
	authorID    int not null,
	au_Name     varchar(50) not null,
	phone       varchar(8) not null,
	au_Address      varchar(20) not null,
	constraint pkAuthor primary key (AuthorID)
)
go
create procedure spAuthorSelect @authorID int
as
	select *from author where authorID = @authorID
go
create procedure spAuthorInsert @authorID int, @au_Name varchar(50),@phone varchar(8),@au_Address varchar(20)
as
	select @authorID = ISNULL(max(authorID),0) from author
	insert into author values(@authorID,@au_Name,@phone,@au_Address)
go
create procedure spAuthorUpdate @authorID int, @au_name varchar(50), @phone varchar(8),@au_Address varchar(20)
as
	update author set au_Name = @au_name, phone = @phone,@au_Address = @au_Address
		where authorID = @authorID
go
create procedure spAuthorDelete @AuthorID int
as
	delete from author where authorID = @AuthorID
go