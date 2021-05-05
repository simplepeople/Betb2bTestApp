create database betb2b;
use betb2b;
drop table Users;
create table Users (
	Id INT NOT NULL auto_increment,
    Name nvarchar(1024) NOT NULL,
    Status INT NOT NULL,
    primary key (Id)
);

select * from Users