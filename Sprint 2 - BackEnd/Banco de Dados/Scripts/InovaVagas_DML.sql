USE InovaVagas
GO

SELECT * FROM TipoCurso;

INSERT INTO Usuario (Email, Senha, Endereco, Telefone, Celular, EmailContato, DataCadastro)
VALUES ('lorraine@gmail.com', 'lorraine123', 'Rua Lorraine de Jesus, 124', '1140028922', '11975679933', 'logata@email.com', '12/12/2001'),
	   ('jefferson@gmail.com', 'jefferson143', 'Av Rua Nova, 236', '1135028822', '11975674536', 'jeffzinho@email.com', '09/11/2000'),
	   ('thadeu@gmail.com', 'thadeuJefferson', 'Rua Avenida, 193', '1128823432', '11975679933', 'thadeujefferson@email.com', '04/05/2003'),
	   ('jailson@gmail.com', 'jailson123', 'Rua Cantareira, 123', '1140028922', '11975679933', 'jaja@email.com', '08/02/1998'),
	   ('lidiane@gmail.com', 'pepino123', 'Rua Jesus Amado de Cristo, 71', '1140028922', '11975679933', 'lidi@email.com', '08/04/1996');


INSERT INTO Usuario (Email, Senha, Endereco, Telefone, Celular, EmailContato, DataCadastro)
VALUES ('carla@gmail.com', 'carlacarvalho', 'Rua Cantareira, 124', '1140028922', '11975679933', 'carla22@email.com', '12/12/2017'),
	   ('facebook@empresa.com.br', 'facebook123', 'Avenida Paulista, 124', '1140028922', '11975679933', 'josefafacebook@email.com', '12/12/2019'),
	   ('brq@empresa.com.br', 'empresabrq123', 'Rua Santa Cecília, 134', '1140028922', '11975679933', 'thabatabrq@email.com', '10/02/2015');

INSERT INTO Administrador (NomeAdministrador, IdUsuario)
VALUES ('Jailson Gomes Santos', 4);

INSERT INTO Genero (NomeGenero)
VALUES ('Feminino'),('Masculino'),('Outros');


INSERT INTO Pessoa (NomePessoa, CPF, RG, DataNasc, IdGenero, TituloPerfil, Empregado, IdUsuario)
VALUES ('Lorraine De Jesus', '11176534786', '765498345', '12/08/1984', 2, 'Desenvolvedora Java', 1, 1), 
	   ('Jefferson Amadeus Justos', '56743896431', '084567345', '28/08/1981', 1, 'Desenvolvedor FullStack', 0, 2),
	   ('Thadeu dos Santos', '86367829734', '567287658', '12/08/1984', 1, 'Desenvolvedor C+', 0, 3),
	   ('Lidiane de Carvalho', '11176534786', '765498345', '12/08/1983', 2, 'Desenvolvedor Phyton', 1, 5),
	   ('Carla Carvalho', '11176534786', '765498345', '20/04/1981', 2, 'Analista de Redes', 0, 6);

INSERT INTO Empresa (RazaoSocial, NomeFantasia, RamoAtuacao, TamanhoEmpresa, CNPJ, CNAE, PessoaResponsavel, IdUsuario)
VALUES ('Facebook Enterprices', 'Facebook', 'Internet', '100238000','12894567290', '6736895', 'Josefa Amaral', 7),
	   ('BRQ Digital Solutions LTDA.', 'BRQ Digital Solutions', 'Desenvolvimento de soluções tecnológicas', '100235','12894567290', '6736895', 'Thabata Gomez', 8);

//*Ver se essas são mesmo as áreas das vagas*//
INSERT INTO AreaVaga (NomeAreaVaga)
VALUES ('Desenvolvimento'), ('Redes'), ('Multimídia');

//*Ver se essas são mesmo as formas de contratação*//
INSERT INTO FormaContratacao (NomeFormaContratacao)
VALUES ('CLT'), ('Estágio'), ('Jovem Aprendiz'), ('PJ'), ('Autônomo');

DROP TABLE AreaVaga;

INSERT INTO Vaga (NomeVaga, Descricao, Requisitos, Endereco, VagaAtiva, DataEncerramento, DataCadastro, Salario, IdEmpresa, IdFormaContratacao, IdAreaVaga)
VALUES ('Analista de desenvolvimento de sistemas', 'O funcionario escolhido irá desenvolver sistemas para a empresa de maneira benéfica','Conhecimento na área', 'Rua Carlota Joaquina, 1876', 0, '12/12/2020', '12/03/2021', 'R$2500,00', 1, 1, 1),
	   ('Estágio em redes ', 'O funcionario escolhido irá desenvolver redes de computadores para a empresa de maneira benéfica', 'Conhecimento na área', 'Rua Ipiranga, 956', 1, '12/12/2020', '12/03/2021', 'R$1200,00', 2, 2, 2);


INSERT INTO Candidatura (DataCandidatura, IdVaga, IdPessoa)
VALUES ('03/10/2020', 2, 5), 
	   ('10/08/2020', 1, 1),
	   ('21/10/2020', 1, 2),
	   ('11/09/2020', 1, 4),
	   ('02/10/2020', 1, 3);

INSERT INTO Termo (NumeroTermo)
VALUES (1), (2), (3);

INSERT INTO Turno (NomeTurno)
VALUES ('Manhã'), ('Tarde'), ('Noite'), ('Intergral');


INSERT INTO TipoCurso (NomeTipoCurso)
VALUES ('Curso Técnico'), ('Aprendizagem Profissional'), ('Aperfeiçoamento Profissional'), ('Iniciação Profissional'), ('Qualificação Profissional'), ('Especialização Profissional');

INSERT INTO Curso (NomeCurso, IdTermo, IdTurno, IdTipoCurso)
VALUES ('Desenvolvimento de Sistemas', 3, 1, 1), 
	   ('Desenvolvimento de Sistemas', 3, 2, 1), 
	   ('Redes de Computadores', 3, 1, 1), 
	   ('Redes de Computadores', 3, 2, 1), 
	   ('Redes de Computadores', 3, 1, 1), 
	   ('Programação JAVA', 1, 4, 3),
	   ('Informática Básica', 1, 3, 4),
	   ('Designer Gráfico Editorial', 1, 1, 5),
	   ('Introdução ao Excel', 1, 4, 6);



INSERT INTO Aluno (NumeroMatricula, IdPessoa, IdCurso)
VALUES ('65789563', 1, 2),
	   ('98765400', 2, 1),
	   ('34569123', 3, 6);

INSERT INTO Funcionario (CargoAtual, Salario, IdPessoa)
VALUES ('Segurança', 'R$2000,00', 4),
	   ('Professora', 'R$7000,00', 5);

INSERT INTO StatusContrato (NomeStatusContrato)
VALUES ('Concluído'), ('Evadido'), ('Em Andamento');

INSERT INTO Contrato (DataInicio, DataTermino, DiasContrato, RequerimentoAssinatura, CopiaContrato, PlanoEstagio, MotivoEvasao, IdVaga, IdStatusContrato)
VALUES ('12/03/2021', '12/03/2022', '365', 1, 1, 1, 0, 2, 3),
	   ('12/03/2021', '12/03/2022', '365', 0, 0, 0, 1, 1, 2);

INSERT INTO Contrato (DataInicio, DataTermino, DiasContrato, RequerimentoAssinatura, CopiaContrato, PlanoEstagio, MotivoEvasao, IdVaga, IdStatusContrato)
VALUES ('12/03/2021', '12/03/2022', '365', 1, 1, 1, 0, 1, 2);


INSERT INTO Avaliacao (AvaliacaoEmpresa, AutoAvaliacao, Avaliacao1Data, Avaliacao1Realizada, Avaliacao2Data, Avaliacao2Realizada, VisitaTecnicaData, VisitaTecnicaRealizada, IdContrato)
VALUES ('Avaliação Empresa', 'Auto Avaliação', '09/10/2021', 0, '04/12/2022', 0, '24/12/2021', 0, 1),
	   ('Avaliação Empresa2', 'Auto Avaliação2', '18/10/2021', 0, '05/01/2021', 0, '20/10/2021', 0, 3);

INSERT INTO Curriculo (NomeEmpresa, DataInicioEmprego, DataTerminoEmprego, DescricaoEmprego, NomeEscola, DataInicioEscola, DataTerminoEscola, Competencia, LinkLinkedIn, LinkGitHub, InformacoesAdicionais, IdPessoa)
VALUES ('Digio', '13/09/2019', '21/03/2020', 'Emprego bom e bem legal', 'FATEC São Paulo', '02/01/2015', '05/12/2019','Phyton, JAVA, Git, HTML', 'www.linkedin.com.br', 'www.github.com.br', 'Informações a mais das adicionais', '1'),
	   ('Nubank', '13/09/2017', '21/03/2019', 'Emprego bom e bem legal', 'USP', '02/11/2013', '29/01/2017','Phyton, JAVA, Git, HTML', 'www.linkedin.com.br', 'www.github.com.br', 'Informações a mais das adicionais', '1');