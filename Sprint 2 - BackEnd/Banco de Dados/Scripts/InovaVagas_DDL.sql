CREATE DATABASE InovaVagas;
GO
USE InovaVagas;
GO

CREATE TABLE Usuario
(
	IdUsuario				INT PRIMARY KEY IDENTITY,
	Email					VARCHAR(100) NOT NULL UNIQUE,
	Senha					VARCHAR(20) NOT NULL,
	ImagemPerfil			IMAGE,
	Endereco				VARCHAR(200),
	Telefone				CHAR(10),
	Celular					CHAR(11),
	EmailContato			VARCHAR(100) NOT NULL UNIQUE,
	DataCadastro			DATE
)
GO

CREATE TABLE Administrador
(
	IdAdministrador			INT PRIMARY KEY IDENTITY,
	NomeAdministrador		VARCHAR(100) NOT NULL,
	IdUsuario				INT FOREIGN KEY REFERENCES Usuario (IdUsuario) 
)
GO

CREATE TABLE Genero
(
	IdGenero				INT PRIMARY KEY IDENTITY,
	NomeGenero				VARCHAR(20) UNIQUE
)
GO

CREATE TABLE Termo
(
	IdTermo					INT PRIMARY KEY IDENTITY,
	NumeroTermo				TINYINT UNIQUE
)
GO

CREATE TABLE Turno
(
	IdTurno					INT PRIMARY KEY IDENTITY,
	NomeTurno				VARCHAR(30) UNIQUE
)
GO

CREATE TABLE TipoCurso
(
	IdTipoCurso				INT PRIMARY KEY IDENTITY,
	NomeTipoCurso			VARCHAR(30) UNIQUE
)
GO

CREATE TABLE Curso
(
	IdCurso					INT PRIMARY KEY IDENTITY,
	NomeCurso				VARCHAR(30),
	IdTurno					INT FOREIGN KEY REFERENCES Turno (IdTurno),
	IdTermo					INT FOREIGN KEY REFERENCES Termo (IdTermo),
	IdTipoCurso				INT FOREIGN KEY REFERENCES TipoCurso (IdTipoCurso)
)
GO

CREATE TABLE Aluno
(
	IdAluno					INT PRIMARY KEY IDENTITY,
	Nome					VARCHAR(100) NOT NULL,
	CPF						CHAR(11) NOT NULL UNIQUE,
	RG						CHAR(9) NOT NULL UNIQUE,
	NumeroMatricula			CHAR(8) NOT NULL UNIQUE,
	DataNasc				DATE NOT NULL,
	TituloPerfil			VARCHAR(60) NOT NULL,
	Empregado				BIT NOT NULL,
	NumeroVagasInscritas	INT,
	IdUsuario				INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
	IdCurso					INT FOREIGN KEY REFERENCES Curso (IdCurso),
	IdGenero				INT FOREIGN KEY REFERENCES Genero (IdGenero)
)
GO
 
CREATE TABLE Empresa
(
	IdEmpresa				INT PRIMARY KEY IDENTITY,
	RazaoSocial				VARCHAR(100) NOT NULL UNIQUE,
	NomeFantasia			VARCHAR(100) NOT NULL UNIQUE,
	RamoAtuacao				VARCHAR(100) NOT NULL,
	TamanhoEmpresa			VARCHAR(100) NOT NULL,
	CNPJ					CHAR(11) NOT NULL UNIQUE,
	CNAE					CHAR(7) NOT NULL UNIQUE,
	CadastroAprovado		BIT NOT NULL,
	PessoaResponsavel		VARCHAR(100) NOT NULL,
	VagasTotais				INT,
	VagasDisponiveis		INT,
	VagasEncerradas			INT,
	NumeroContratacoes		INT,
	IdUsuario				INT FOREIGN KEY REFERENCES Usuario (IdUsuario) 
)
GO

CREATE TABLE FormaContratacao
(
	IdFormaContratacao		INT PRIMARY KEY IDENTITY,
	NomeFormaContratacao	VARCHAR(50) UNIQUE
)
GO

CREATE TABLE AreaVaga
(
	IdAreaVaga				INT PRIMARY KEY IDENTITY,
	NomeAreaVaga			VARCHAR(50) UNIQUE
)
GO

CREATE TABLE Vaga
(
	IdVaga					INT PRIMARY KEY IDENTITY,
	NomeVaga				VARCHAR(100) NOT NULL,
	Descricao				VARCHAR(300) NOT NULL,
	Requisitos				VARCHAR(300) NOT NULL,
	Endereco				VARCHAR(200),
	NumeroCandidatos		INT,
	VagaAtiva				BIT,
	DataEncerramento		DATE,
	DataCadastro			DATE,
	Salario					VARCHAR(25),
	IdEmpresa				INT FOREIGN KEY REFERENCES Empresa (IdEmpresa),
	IdFormaContratacao		INT FOREIGN KEY REFERENCES FormaContratacao (IdFormaContratacao),
	IdAreaVaga				INT FOREIGN KEY REFERENCES AreaVaga (IdAreaVaga)
)
GO

CREATE TABLE StatusCandidatura 
(
	IdStatusCandidatura		INT PRIMARY KEY IDENTITY,
	NomeStatusCandidatura	VARCHAR(50) UNIQUE,
	Descricao				VARCHAR(250)
)
GO

CREATE TABLE Candidatura
(
	IdCandidatura			INT PRIMARY KEY IDENTITY,
	DataCandidatura			DATE,
	Contratado				BIT,
	IdStatusCandidatura		INT FOREIGN KEY REFERENCES StatusCandidatura (IdStatusCandidatura),
	IdVaga					INT FOREIGN KEY REFERENCES Vaga (IdVaga),
	IdAluno					INT FOREIGN KEY REFERENCES Aluno (IdAluno)
)
GO

CREATE TABLE StatusContrato
(
	IdStatusContrato		INT PRIMARY KEY IDENTITY,
	NomeStatusContrato		VARCHAR(50)
)
GO

CREATE TABLE Contrato
(
	IdContrato				INT PRIMARY KEY IDENTITY,
	DataInicio				DATE NOT NULL,
	DataTermino				DATE NOT NULL,
	DiasContrato			VARCHAR(3) NOT NULL,
	RequerimentoAssinatura	BIT NOT NULL,
	CopiaContrato			BIT NOT NULL,
	PlanoEstagio			BIT,
	MotivoEvasao			VARCHAR(30),
	IdCandidatura			INT FOREIGN KEY REFERENCES Candidatura (IdCandidatura),
	IdStatusContrato		INT FOREIGN KEY REFERENCES StatusContrato (IdStatusContrato)
)
GO

CREATE TABLE TipoResposta 
(
	IdTipoResposta			INT PRIMARY KEY IDENTITY,
	NomeTipoResposta		VARCHAR(50) UNIQUE
)
GO

CREATE TABLE TipoPergunta 
(
	IdTipoPergunta			INT PRIMARY KEY IDENTITY,
	NomeTipoPergunta		VARCHAR(50) UNIQUE
)
GO

CREATE TABLE Avaliacao
(
	IdAvaliacao				INT PRIMARY KEY IDENTITY,
	Avaliacao1Data			DATE,
	Avaliacao1Realizada		BIT,
	Avaliacao2Data			DATE,
	Avaliacao2Realizada		BIT,
	VisitaTecnicaData		DATE,
	VisitaTecnicaRealizada	BIT,
	IdContrato				INT FOREIGN KEY REFERENCES Contrato (IdContrato)	
)
GO

CREATE TABLE Pergunta 
(
	IdPergunta				INT PRIMARY KEY IDENTITY,
	NomePergunta			VARCHAR(200),
	IdTipoPergunta			INT FOREIGN KEY REFERENCES TipoPergunta (IdTipoPergunta)
)
GO

CREATE TABLE Resposta
(
	IdResposta				INT PRIMARY KEY IDENTITY,
	IdPergunta				INT FOREIGN KEY REFERENCES Pergunta (IdPergunta),
	IdTipoResposta			INT FOREIGN KEY REFERENCES TipoResposta (IdTipoResposta),
	IdAvaliacao				INT FOREIGN KEY REFERENCES Avaliacao (IdAvaliacao)
)
GO

CREATE TABLE Curriculo
(
	IdCurriculo				INT PRIMARY KEY IDENTITY,
	NomeEmpresa				VARCHAR(100),
	DataInicioEmprego		DATE,
	DataTerminoEmprego		DATE,
	DescricaoEmprego		VARCHAR(300),
	NomeEscola				VARCHAR(100),
	DataInicioEscola		DATE,
	DataTerminoEscola		DATE,
	Competencia				VARCHAR(300),
	LinkLinkedIn			VARCHAR(300),
	LinkGitHub				VARCHAR(300),
	InformacoesAdicionais	VARCHAR(300),
	IdAluno					INT FOREIGN KEY REFERENCES Aluno (IdAluno)
)
GO