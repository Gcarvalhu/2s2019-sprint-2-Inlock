create database T_Inlock
use T_InLock

create table Usuarios
(
IdUsuario int primary key identity,
NomeUsuario varchar (200) not null,
Email varchar (200) unique not null,
Senha varchar(200) not null,
PermissaoUsuario varchar (200) not null
)


create table Estudios
(
IdEstudio int identity primary key,
NomeEstudio varchar (200) unique not null,
PaisEstudio varchar (200) not null,
DataCriacao date not null,
IdUsuario int foreign key references Usuarios (IdUsuario)
)

create table Jogos
(
IdJogo int primary key identity,
NomeJogo varchar (200) unique not null,
Descricao varchar (200),
DataLancamento date not null,
Valor int not null,
IdEstudio int foreign key references Estudios (IdEstudio)
)


