create database MyShop

create table Products(
ProductID int primary key,
ProductName varchar(50) not null,
SupplierID int foreign key references Supliers(SupplierID),
CategoryID int foreign key references Categories(CategoryID),
Price money check(Price > 0)
)
create table Supliers
(
SupplierID int primary key,
SupplierName varchar(50) not null,
City varchar(50),
Country varchar(50)
)
create table Categories
(
CategoryID int primary key,
CategoryName varchar(50) not null,
Description varchar(500)
)

insert into Products values(1, 'Chairs', 1, 1, 18.00)
insert into Products values(2, 'Chang', 1, 1, 19.00)
insert into Products values(3, 'Aniseed Syrup', 1, 2, 10.00)
insert into Products values(4, 'Chef Anton’s Cajun Seasoning', 2, 2, 22.00)
insert into Products values(5, 'Chef Anton’s Cajun Seasoning', 2, 2, 21.35)

insert into Supliers values(1,'Exotic Liquid', 'London', 'UK')
insert into Supliers values(2, 'New Orleans Cajun Delights', 'New Orleans', 'USA')
insert into Supliers values(3, 'Grandma Kelly’s Homestead', 'Ann Arbor', 'USA')
insert into Supliers values(4, 'Tokyo Traders', 'Tokyo', 'Japan')
insert into Supliers values(5, 'Cooperativa de Quesos ‘Las Cabras’', 'Oviedo','Spain')

insert into Categories values(1, 'Beverages', 'Soft drinks, coffees, teas, beers, and ales')
insert into Categories values(2, 'Condiments', 'Sweet and savory sauces, relishes, spreads, and seasonings')
insert into Categories values(3, ' Confections', 'Desserts, candies, and sweet breads')
insert into Categories values(4, 'Dairy Products', 'Cheeses')
insert into Categories values(5, 'Grains/Cereals', 'Breads, crackers, pasta, and cerea')

select * from Products
select * from Categories
select * from Supliers

/*1*/
select * from Products 
where ProductName LIKE 'C%';

/*2*/
select ProductName, Price
from Products
where Price = (select MIN(Price) from Products);

/*3*/
select Price
From Products
Join Supliers
on Products.SupplierID = Supliers.SupplierID AND Supliers.Country = 'USA';

/*4*/
select SupplierName
From Products
Join Supliers on Products.SupplierID = Supliers.SupplierID
Join Categories on Products.CategoryID = Categories.CategoryID
where Categories.CategoryName = 'Condiments';

/*5*/
insert into Supliers values(6, 'Norske Meierier','Lviv', 'Ukraine')
insert into Products values(6, 'Green tea', 6, 1, 10.00)


