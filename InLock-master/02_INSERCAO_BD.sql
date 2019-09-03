insert into Usuarios(NomeUsuario,Email,Senha,PermissaoUsuario) values ('jorge','J@.com',123456,'ADMINISTRADOR');
insert into Usuarios(NomeUsuario,Email,Senha,PermissaoUsuario) values ('joao','B@.com',12345,'COMUM');
insert into Usuarios(NomeUsuario,Email,Senha,PermissaoUsuario) values ('Kleber','A@.com',12345,'COMUM');

insert into Estudios (NomeEstudio,PaisEstudio,DataCriacao,IdUsuario) values('blizzard','brasil','2008-11-11',1);
insert into Estudios (NomeEstudio,PaisEstudio,DataCriacao,IdUsuario) values('riot','belgica','2008-11-11',2);


insert into jogos(NomeJogo,Descricao,DataLancamento,Valor,IdEstudio) values('overwatch','blablabla','2014-11-11',200,1);
insert into jogos(NomeJogo,Descricao,DataLancamento,Valor,IdEstudio) values('league of legends','blablabla','2014-11-11',250,2);