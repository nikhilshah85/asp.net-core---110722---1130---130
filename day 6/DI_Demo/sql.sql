	create database shoppingP2APP
	
	use shoppingP2APP
	

	create table Register
	(
		desiredUserName varchar(20) primary key,
		desiredPassword varchar(20),
		firstName varchar(20),
		lastName varchar(20),
		emailAddress varchar(20),
		contactNo int,
		age int,
		city varchar(20),
		address varchar(20),

		constraint uk_email unique(emailAddress),		
		constraint uk_contact unique(contactNo),
	)
	

	create table productList
	(
		pId int primary key,
		pName varchar(20),
		pCategory varchar(20),
		pPrice int,
		pAvailableQty int,
		pIsInStock bit
	)

	insert into productList values(101,'Iphone','Electronic',2200,10,1)
	insert into productList values(102,'Latte','Beverage',5,10,1)
	insert into productList values(103,'Fossil','Electronic',1800,10,1)
	insert into productList values(104,'Green Tea','Beverage',8,10,1)
	insert into productList values(105,'Sandwitch','Fast-Food',2,10,1)

	create table ordersList
	(
		orderId int primary key identity(5000,1),
		orderDate date,
		productId int,
		orderQty int,
		orderCost int,
		userId varchar(20),
		
		constraint fk_produtId foreign key(productId) references productList,
		constraint fk_userId foreign key(userId) references Register
	)


	select * from Register

	select * from ordersList