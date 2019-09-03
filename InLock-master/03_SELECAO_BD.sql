select * from Usuarios
select * from Estudios
select * from Jogos


select Estudios.NomeEstudio, Estudios.PaisEstudio, Estudios.DataCriacao, Usuarios.NomeUsuario from Estudios join Usuarios on Usuarios.IdUsuario = Estudios.IdUsuario

select Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudios.NomeEstudio from Jogos join Estudios on Estudios.IdEstudio = Jogos.IdEstudio 