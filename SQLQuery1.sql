create database Day7Db
use Day7Db

create table Customers
(Id int primary key,
Name nvarchar(50) not null,
ODLimit float not null,
SStartDate date not null,
SEndDate date not null)

insert into Customers values(1,'Sam',59800,'12/12/2019','12/12/2022')
insert into Customers values(2,'Ram',66600,'02/20/2022','12/12/2024')
insert into Customers values(3,'Ravi',85700,'01/12/2023','12/12/2025')

select * from Customers