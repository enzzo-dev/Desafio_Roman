--DML

USE Desafio_Roman
GO

INSERT INTO TiposUsuarios(TituloTipoUsuario)
VALUES					 ('Professor')
						,('Aluno')
GO

INSERT INTO Usuarios(idTipoUsuario, Email, Senha)
VALUES				(1, 'prof@prof.com', '1234')
				   ,(2, 'aluno@aluno.com', '1234')
GO

INSERT INTO Temas(Tema)
VALUES			 ('Gestao')
				,('HQs')
GO

INSERT INTO Projetos(idTema, Nome, Descricao)
VALUES				(1, 'Controle de estoque', 'Projeto criado para controle de estoque')
				   ,(2, 'Listagem de personagens', 'Projeto criado para listagem de personagens')
GO