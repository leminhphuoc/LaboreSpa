create Table Orders
(
	Id bigint identity primary key,
	IdCustomer bigint,
	IdServices bigint default 0,
	IdProduct bigint default 0
)

