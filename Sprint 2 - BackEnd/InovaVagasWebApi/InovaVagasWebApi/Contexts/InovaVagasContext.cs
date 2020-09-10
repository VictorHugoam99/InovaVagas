using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InovaVagasWebApi.Domains;

namespace InovaVagasWebApi.Contexts
{
    public partial class InovaVagasContext : DbContext
    {
        public InovaVagasContext()
        {
        }

        public InovaVagasContext(DbContextOptions<InovaVagasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<AreaVaga> AreaVaga { get; set; }
        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<Candidatura> Candidatura { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Curriculo> Curriculo { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<FormaContratacao> FormaContratacao { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Pergunta> Pergunta { get; set; }
        public virtual DbSet<Resposta> Resposta { get; set; }
        public virtual DbSet<StatusCandidatura> StatusCandidatura { get; set; }
        public virtual DbSet<StatusContrato> StatusContrato { get; set; }
        public virtual DbSet<Termo> Termo { get; set; }
        public virtual DbSet<TipoCurso> TipoCurso { get; set; }
        public virtual DbSet<TipoPergunta> TipoPergunta { get; set; }
        public virtual DbSet<TipoResposta> TipoResposta { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vaga> Vaga { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= DESKTOP-A4H5R1B; Initial Catalog= InovaVagas; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__Administ__2B3E34A8A4B52601");

                entity.Property(e => e.NomeAdministrador)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Administr__IdUsu__267ABA7A");
            });

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__Aluno__8092FCB35B8E1554");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DataNasc).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroMatricula)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TituloPerfil)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Aluno)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Aluno__IdCurso__36B12243");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Aluno)
                    .HasForeignKey(d => d.IdGenero)
                    .HasConstraintName("FK__Aluno__IdGenero__37A5467C");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Aluno)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Aluno__IdUsuario__35BCFE0A");
            });

            modelBuilder.Entity<AreaVaga>(entity =>
            {
                entity.HasKey(e => e.IdAreaVaga)
                    .HasName("PK__AreaVaga__8C9111EF84F590BB");

                entity.Property(e => e.NomeAreaVaga)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacao)
                    .HasName("PK__Avaliaca__78C432D8D5395118");

                entity.Property(e => e.Avaliacao1Data).HasColumnType("date");

                entity.Property(e => e.Avaliacao2Data).HasColumnType("date");

                entity.Property(e => e.VisitaTecnicaData).HasColumnType("date");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => d.IdContrato)
                    .HasConstraintName("FK__Avaliacao__IdCon__5629CD9C");
            });

            modelBuilder.Entity<Candidatura>(entity =>
            {
                entity.HasKey(e => e.IdCandidatura)
                    .HasName("PK__Candidat__7B9E9EACA55A9CD7");

                entity.Property(e => e.DataCandidatura).HasColumnType("date");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Candidatura)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__Candidatu__IdAlu__49C3F6B7");

                entity.HasOne(d => d.IdStatusCandidaturaNavigation)
                    .WithMany(p => p.Candidatura)
                    .HasForeignKey(d => d.IdStatusCandidatura)
                    .HasConstraintName("FK__Candidatu__IdSta__47DBAE45");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.Candidatura)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Candidatu__IdVag__48CFD27E");
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato)
                    .HasName("PK__Contrato__8569F05A896904B8");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.DataTermino).HasColumnType("date");

                entity.Property(e => e.DiasContrato)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCandidaturaNavigation)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.IdCandidatura)
                    .HasConstraintName("FK__Contrato__IdCand__4E88ABD4");

                entity.HasOne(d => d.IdStatusContratoNavigation)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.IdStatusContrato)
                    .HasConstraintName("FK__Contrato__IdStat__4F7CD00D");
            });

            modelBuilder.Entity<Curriculo>(entity =>
            {
                entity.HasKey(e => e.IdCurriculo)
                    .HasName("PK__Curricul__A6515A339741754F");

                entity.Property(e => e.Competencia)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DataInicioEmprego).HasColumnType("date");

                entity.Property(e => e.DataInicioEscola).HasColumnType("date");

                entity.Property(e => e.DataTerminoEmprego).HasColumnType("date");

                entity.Property(e => e.DataTerminoEscola).HasColumnType("date");

                entity.Property(e => e.DescricaoEmprego)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.InformacoesAdicionais)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LinkGitHub)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LinkLinkedIn)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEmpresa)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEscola)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Curriculo)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__Curriculo__IdAlu__60A75C0F");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__085F27D6986D8269");

                entity.Property(e => e.NomeCurso)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTermoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdTermo)
                    .HasConstraintName("FK__Curso__IdTermo__31EC6D26");

                entity.HasOne(d => d.IdTipoCursoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdTipoCurso)
                    .HasConstraintName("FK__Curso__IdTipoCur__32E0915F");

                entity.HasOne(d => d.IdTurnoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdTurno)
                    .HasConstraintName("FK__Curso__IdTurno__30F848ED");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__5EF4033EA6A4D4EE");

                entity.Property(e => e.Cnae)
                    .IsRequired()
                    .HasColumnName("CNAE")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PessoaResponsavel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RamoAtuacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TamanhoEmpresa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Empresa__IdUsuar__3A81B327");
            });

            modelBuilder.Entity<FormaContratacao>(entity =>
            {
                entity.HasKey(e => e.IdFormaContratacao)
                    .HasName("PK__FormaCon__1C9FE6D04A01BBC4");

                entity.Property(e => e.NomeFormaContratacao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__0F8349882404B8E0");

                entity.Property(e => e.NomeGenero)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pergunta>(entity =>
            {
                entity.HasKey(e => e.IdPergunta)
                    .HasName("PK__Pergunta__6DC6D9A739CD5AA1");

                entity.Property(e => e.NomePergunta)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoPerguntaNavigation)
                    .WithMany(p => p.Pergunta)
                    .HasForeignKey(d => d.IdTipoPergunta)
                    .HasConstraintName("FK__Pergunta__IdTipo__59063A47");
            });

            modelBuilder.Entity<Resposta>(entity =>
            {
                entity.HasKey(e => e.IdResposta)
                    .HasName("PK__Resposta__D1283E98739C9C10");

                entity.HasOne(d => d.IdAvaliacaoNavigation)
                    .WithMany(p => p.Resposta)
                    .HasForeignKey(d => d.IdAvaliacao)
                    .HasConstraintName("FK__Resposta__IdAval__5DCAEF64");

                entity.HasOne(d => d.IdPerguntaNavigation)
                    .WithMany(p => p.Resposta)
                    .HasForeignKey(d => d.IdPergunta)
                    .HasConstraintName("FK__Resposta__IdPerg__5BE2A6F2");

                entity.HasOne(d => d.IdTipoRespostaNavigation)
                    .WithMany(p => p.Resposta)
                    .HasForeignKey(d => d.IdTipoResposta)
                    .HasConstraintName("FK__Resposta__IdTipo__5CD6CB2B");
            });

            modelBuilder.Entity<StatusCandidatura>(entity =>
            {
                entity.HasKey(e => e.IdStatusCandidatura)
                    .HasName("PK__StatusCa__60FF3E6F117AA27D");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NomeStatusCandidatura)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusContrato>(entity =>
            {
                entity.HasKey(e => e.IdStatusContrato)
                    .HasName("PK__StatusCo__60463F1FBF46828C");

                entity.Property(e => e.NomeStatusContrato)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Termo>(entity =>
            {
                entity.HasKey(e => e.IdTermo)
                    .HasName("PK__Termo__40EEF383AA02BB87");
            });

            modelBuilder.Entity<TipoCurso>(entity =>
            {
                entity.HasKey(e => e.IdTipoCurso)
                    .HasName("PK__TipoCurs__FA83FBBE8C9CEBD2");

                entity.Property(e => e.NomeTipoCurso)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPergunta>(entity =>
            {
                entity.HasKey(e => e.IdTipoPergunta)
                    .HasName("PK__TipoPerg__94655DF392F16031");

                entity.Property(e => e.NomeTipoPergunta)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoResposta>(entity =>
            {
                entity.HasKey(e => e.IdTipoResposta)
                    .HasName("PK__TipoResp__AC70444A6ED89EC1");

                entity.Property(e => e.NomeTipoResposta)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.IdTurno)
                    .HasName("PK__Turno__C1ECF79A382FBF6D");

                entity.Property(e => e.NomeTurno)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97ECECAB9E");

                entity.Property(e => e.Celular)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DataCadastro).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailContato)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImagemPerfil).HasColumnType("image");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasKey(e => e.IdVaga)
                    .HasName("PK__Vaga__A848DC3EA244DA0A");

                entity.Property(e => e.DataCadastro).HasColumnType("date");

                entity.Property(e => e.DataEncerramento).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeVaga)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Requisitos)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Salario)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaVagaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdAreaVaga)
                    .HasConstraintName("FK__Vaga__IdAreaVaga__4316F928");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Vaga__IdEmpresa__412EB0B6");

                entity.HasOne(d => d.IdFormaContratacaoNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdFormaContratacao)
                    .HasConstraintName("FK__Vaga__IdFormaCon__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
