USE InovaVagas
GO

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

INSERT INTO Aluno (Nome, CPF, RG, NumeroMatricula, DataNasc, TituloPerfil, Empregado, IdUsuario, IdCurso, IdGenero)
VALUES ('Lorraine De Jesus', '15176534786', '755498345', '65754063', '1984/08/12', 'Desenvolvedora Java', 1, 1, 1, 1), 
	   ('Jefferson Amadeus Justos', '56745896431', '084547345', '65759563','1984/08/12', 'Desenvolvedor FullStack', 0, 2, 2, 2),
	   ('Thadeu dos Santos', '86267829734', '267287658', '63589563', '1984/08/12', 'Desenvolvedor C+', 0, 3, 2, 2),
	   ('Lidiane de Carvalho', '13476534786', '763798345', '43789563', '1984/08/12', 'Desenvolvedor Phyton', 1, 5, 1, 1),
	   ('Carla Carvalho', '17676534786', '865498345', '05789563', '1984/08/12', 'Analista de Redes', 0, 6, 3, 1);

INSERT INTO Empresa (RazaoSocial, NomeFantasia, RamoAtuacao, TamanhoEmpresa, CNPJ, CNAE, PessoaResponsavel, CadastroAprovado, IdUsuario)
VALUES ('Facebook Enterprices', 'Facebook', 'Internet', '100238000','12894567290', '6736895', 'Josefa Amaral', 0, 7),
	   ('BRQ Digital Solutions LTDA.', 'BRQ Digital Solutions', 'Desenvolvimento de soluções tecnológicas', '100235','42894567290', '6436895', 'Thabata Gomez', 0, 8);

/*Ver se essas são mesmo as áreas das vagas*/
INSERT INTO AreaVaga (NomeAreaVaga)
VALUES ('Desenvolvimento'), ('Redes'), ('Multimídia');

/*Ver se essas são mesmo as formas de contratação*/
INSERT INTO FormaContratacao (NomeFormaContratacao)
VALUES ('CLT'), ('Estágio'), ('Jovem Aprendiz'), ('PJ'), ('Autônomo');

INSERT INTO Vaga (NomeVaga, Descricao, Requisitos, Endereco, VagaAtiva, DataEncerramento, DataCadastro, Salario, IdEmpresa, IdFormaContratacao, IdAreaVaga)
VALUES ('Analista de desenvolvimento de sistemas', 'O funcionario escolhido irá desenvolver sistemas para a empresa de maneira benéfica','Conhecimento na área', 'Rua Carlota Joaquina, 1876', 0, '2020/10/05', '2021/05/05', 'R$2500,00', 1, 1, 1),
	   ('Estágio em redes', 'O funcionario escolhido irá desenvolver redes de computadores para a empresa de maneira benéfica', 'Conhecimento na área', 'Rua Ipiranga, 956', 1, '2020/10/05', '2021/05/05', 'R$1200,00', 2, 2, 2);

INSERT INTO StatusCandidatura (NomeStatusCandidatura, Descricao)
VALUES ('Agendamento de entrevista', '2020/08/09'), ('Entrevista', 'Data, local e qualquer coisa'), ('Retorno', 'Rolou ou não');

INSERT INTO Candidatura (DataCandidatura, Contratado, IdStatusCandidatura, IdAluno, IdVaga)
VALUES ('2020/03/10', 1, 2, 5, 1), 
	   ('2020/03/10', 0, 1, 2, 1),
	   ('2020/03/10', 0, 3, 4, 2),
	   ('2020/03/10', 0, 1, 3, 2);

INSERT INTO StatusContrato (NomeStatusContrato)
VALUES ('Concluído'), ('Evadido'), ('Em Andamento');

INSERT INTO Contrato (DataInicio, DataTermino, DiasContrato, RequerimentoAssinatura, CopiaContrato, PlanoEstagio, MotivoEvasao, IdCandidatura, IdStatusContrato)
VALUES	('2021/08/02', '2022/08/04', '365', 0, 0, 0, 'Contratado CLT', 4, 2),
		('2021/08/02', '2022/08/04', '365', 1, 1, 1, 'Aluno desistiu', 2, 3);

INSERT INTO TipoResposta (NomeTipoResposta)
VALUES ('Ótimo'), ('Bom'), ('Regular'), ('Péssimo');

INSERT INTO TipoPergunta (NomeTipoPergunta)
VALUES ('Empresa'), ('Aluno');

INSERT INTO Pergunta (NomePergunta, IdTipoPergunta)
VALUES ('Considere a disposição para procurar a solução de problemas e a prposição de idéias espontaneamente', 1),
	   ('Ambiente técnico proporcionado pera o seu desenvolvimento profissional', 2);

INSERT INTO Avaliacao (Avaliacao1Data, Avaliacao1Realizada, Avaliacao2Data, Avaliacao2Realizada, VisitaTecnicaData, VisitaTecnicaRealizada, IdContrato)
VALUES ('2021/09/10', 0, '2022/09/04', 0, '2021/04/12', 0, 1),
	   ('2021/09/10', 0, '2021/01/05', 0, '2021/04/07', 0, 2);

INSERT INTO Resposta (IdPergunta, IdTipoResposta, IdAvaliacao)
VALUES (1, 2, 1),
	   (2, 3, 1);

INSERT INTO Curriculo (NomeEmpresa, DataInicioEmprego, DataTerminoEmprego, DescricaoEmprego, NomeEscola, DataInicioEscola, DataTerminoEscola, Competencia, LinkLinkedIn, LinkGitHub, InformacoesAdicionais, IdAluno)
VALUES ('Digio', '2019/08/12', '2020/07/02', 'Emprego bom e bem legal', 'FATEC São Paulo', '2015/08/11', '05/12/2019','Phyton, JAVA, Git, HTML', 'www.linkedin.com.br', 'www.github.com.br', 'Informações a mais das adicionais', 2),
	   ('Nubank', '2019/08/12', '2020/07/02', 'Emprego bom e bem legal', 'USP', '02/11/2013', '2017/09/12','Phyton, JAVA, Git, HTML', 'www.linkedin.com.br', 'www.github.com.br', 'Informações a mais das adicionais', 3);                  