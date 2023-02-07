USE MERCADERIAS;

CREATE TABLE PRODUCTOS(
CodigoProducto nvarchar(50) primary key not null,
DescripcionProducto nvarchar(50) not null,
PrecioCosto decimal not null,
PrecioVenta decimal not null,
IdMarca int not null,
IdFamilia int not null,
FechaModificacion Datetime not null,
Baja bit not null,
FechaBaja Datetime null)

select * from PRODUCTOS

CREATE TABLE MARCA(
Id int identity (1,1) primary key,
Descripcion nvarchar(50) not null,
FechaModificacion Datetime not null,
Baja bit not null,
FechaBaja Datetime null)

select * from MARCA

CREATE TABLE FAMILIA(
Id int identity (1,1) primary key,
Descripcion nvarchar(50) not null,
FechaModificacion Datetime not null,
Baja bit not null,
FechaBaja Datetime null)

select * from FAMILIA

ALTER TABLE PRODUCTOS
ADD FOREIGN KEY (IdMarca) REFERENCES MARCA(Id);

ALTER TABLE PRODUCTOS
ADD FOREIGN KEY (IdFamilia) REFERENCES FAMILIA(Id);