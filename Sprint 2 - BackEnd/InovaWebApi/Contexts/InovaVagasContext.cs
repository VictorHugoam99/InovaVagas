using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InovaWebApi.Domains;
using System.Linq;

namespace InovaWebApi.Contexts
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
                optionsBuilder.UseSqlServer("Data Source=MAYARA\\MSSQLSERVER01; Initial Catalog=InovaVagas; Integrated Security=true;");
            }
        }

        /// <summary>
        /// Método SaveChanges() que foi sobrescrito para adicionar a funcionalidade de quando as entidades Usuario, Vaga e Candidatura
        /// forem cadastradas, seus campos de DataCadastro seram preenchidos com a data atual.
        /// </summary>
        /// <returns> Retorna o SaveChanges() padrão com a alteração feita abaixo </returns>
       
       //public override int SaveChanges()
       // {
       //     var entries = ChangeTracker
       //         .Entries()
       //         .Where(e => e.Entity is Administrador || e.Entity is Aluno || e.Entity is Empresa || e.Entity is Vaga || e.Entity is Candidatura && (
       //         e.State == EntityState.Added));

       //     foreach (var entityEntry in entries)
       //     {
       //         if (entityEntry.State == EntityState.Added)
       //         {
       //             if (entityEntry.Entity is Administrador)
       //             {
       //                 ((Administrador)entityEntry.Entity).IdUsuarioNavigation.DataCadastro = DateTime.Now;
       //             }

       //             if (entityEntry.Entity is Aluno)
       //             {
       //                 ((Aluno)entityEntry.Entity).IdUsuarioNavigation.DataCadastro = DateTime.Now;
       //             }

       //             if (entityEntry.Entity is Empresa)
       //             {
       //                 ((Empresa)entityEntry.Entity).IdUsuarioNavigation.DataCadastro = DateTime.Now;
       //             }

       //             if (entityEntry.Entity is Vaga)
       //             {
       //                 ((Vaga)entityEntry.Entity).DataCadastro = DateTime.Now;
       //             }

       //             if (entityEntry.Entity is Candidatura)
       //             {
       //                 ((Candidatura)entityEntry.Entity).DataCandidatura = DateTime.Now;
       //             }

       //             /*if (entityEntry.Entity == Empresa)
       //             {
       //                 ((Empresa)entityEntry.Entity).CadastroAprovado = false;
       //             }*/
       //         }
       //     }

       //     return base.SaveChanges();
       // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__Administ__2B3E34A87C595F9A");

                entity.Property(e => e.NomeAdministrador)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Administr__IdUsu__286302EC");
            });

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__Aluno__8092FCB3CDA85B69");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Aluno__C1F897313561AD87")
                    .IsUnique();

                entity.HasIndex(e => e.NumeroMatricula)
                    .HasName("UQ__Aluno__8B9D7E45088FD85F")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__Aluno__321537C81F08E3CB")
                    .IsUnique();

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
                    .HasConstraintName("FK__Aluno__IdCurso__3F466844");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Aluno)
                    .HasForeignKey(d => d.IdGenero)
                    .HasConstraintName("FK__Aluno__IdGenero__403A8C7D");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Aluno)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Aluno__IdUsuario__3E52440B");
            });

            modelBuilder.Entity<AreaVaga>(entity =>
            {
                entity.HasKey(e => e.IdAreaVaga)
                    .HasName("PK__AreaVaga__8C9111EF5EFD008F");

                entity.HasIndex(e => e.NomeAreaVaga)
                    .HasName("UQ__AreaVaga__50452C8B9B7D172D")
                    .IsUnique();

                entity.Property(e => e.NomeAreaVaga)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacao)
                    .HasName("PK__Avaliaca__78C432D868A4F32D");

                entity.Property(e => e.Avaliacao1Data).HasColumnType("date");

                entity.Property(e => e.Avaliacao2Data).HasColumnType("date");

                entity.Property(e => e.VisitaTecnicaData).HasColumnType("date");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => d.IdContrato)
                    .HasConstraintName("FK__Avaliacao__IdCon__6754599E");
            });

            modelBuilder.Entity<Candidatura>(entity =>
            {
                entity.HasKey(e => e.IdCandidatura)
                    .HasName("PK__Candidat__7B9E9EAC1C330680");

                entity.Property(e => e.DataCandidatura).HasColumnType("date");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Candidatura)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__Candidatu__IdAlu__59063A47");

                entity.HasOne(d => d.IdStatusCandidaturaNavigation)
                    .WithMany(p => p.Candidatura)
                    .HasForeignKey(d => d.IdStatusCandidatura)
                    .HasConstraintName("FK__Candidatu__IdSta__571DF1D5");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.Candidatura)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Candidatu__IdVag__5812160E");
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato)
                    .HasName("PK__Contrato__8569F05AA117C076");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.DataTermino).HasColumnType("date");

                entity.Property(e => e.DiasContrato)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MotivoEvasao)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCandidaturaNavigation)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.IdCandidatura)
                    .HasConstraintName("FK__Contrato__IdCand__5DCAEF64");

                entity.HasOne(d => d.IdStatusContratoNavigation)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.IdStatusContrato)
                    .HasConstraintName("FK__Contrato__IdStat__5EBF139D");
            });

            modelBuilder.Entity<Curriculo>(entity =>
            {
                entity.HasKey(e => e.IdCurriculo)
                    .HasName("PK__Curricul__A6515A336114CC80");

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
                    .HasConstraintName("FK__Curriculo__IdAlu__71D1E811");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__085F27D6B28E6A05");

                entity.Property(e => e.NomeCurso)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTermoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdTermo)
                    .HasConstraintName("FK__Curso__IdTermo__37A5467C");

                entity.HasOne(d => d.IdTipoCursoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdTipoCurso)
                    .HasConstraintName("FK__Curso__IdTipoCur__38996AB5");

                entity.HasOne(d => d.IdTurnoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdTurno)
                    .HasConstraintName("FK__Curso__IdTurno__36B12243");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__5EF4033E3B4D0874");

                entity.HasIndex(e => e.Cnae)
                    .HasName("UQ__Empresa__AA5E6DE4B2C73491")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Empresa__AA57D6B47738C88B")
                    .IsUnique();

                entity.HasIndex(e => e.NomeFantasia)
                    .HasName("UQ__Empresa__F5389F31A2CD3EFD")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial)
                    .HasName("UQ__Empresa__448779F092A1BF3C")
                    .IsUnique();

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
                    .HasConstraintName("FK__Empresa__IdUsuar__46E78A0C");
            });

            modelBuilder.Entity<FormaContratacao>(entity =>
            {
                entity.HasKey(e => e.IdFormaContratacao)
                    .HasName("PK__FormaCon__1C9FE6D0BE4C8FD6");

                entity.HasIndex(e => e.NomeFormaContratacao)
                    .HasName("UQ__FormaCon__88C6441A982C2FF7")
                    .IsUnique();

                entity.Property(e => e.NomeFormaContratacao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__0F83498895AAE4A9");

                entity.HasIndex(e => e.NomeGenero)
                    .HasName("UQ__Genero__081698E5BFCD86BE")
                    .IsUnique();

                entity.Property(e => e.NomeGenero)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pergunta>(entity =>
            {
                entity.HasKey(e => e.IdPergunta)
                    .HasName("PK__Pergunta__6DC6D9A7A9E2A747");

                entity.Property(e => e.NomePergunta)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoPerguntaNavigation)
                    .WithMany(p => p.Pergunta)
                    .HasForeignKey(d => d.IdTipoPergunta)
                    .HasConstraintName("FK__Pergunta__IdTipo__6A30C649");
            });

            modelBuilder.Entity<Resposta>(entity =>
            {
                entity.HasKey(e => e.IdResposta)
                    .HasName("PK__Resposta__D1283E9816E381BB");

                entity.HasOne(d => d.IdAvaliacaoNavigation)
                    .WithMany(p => p.Resposta)
                    .HasForeignKey(d => d.IdAvaliacao)
                    .HasConstraintName("FK__Resposta__IdAval__6EF57B66");

                entity.HasOne(d => d.IdPerguntaNavigation)
                    .WithMany(p => p.Resposta)
                    .HasForeignKey(d => d.IdPergunta)
                    .HasConstraintName("FK__Resposta__IdPerg__6D0D32F4");

                entity.HasOne(d => d.IdTipoRespostaNavigation)
                    .WithMany(p => p.Resposta)
                    .HasForeignKey(d => d.IdTipoResposta)
                    .HasConstraintName("FK__Resposta__IdTipo__6E01572D");
            });

            modelBuilder.Entity<StatusCandidatura>(entity =>
            {
                entity.HasKey(e => e.IdStatusCandidatura)
                    .HasName("PK__StatusCa__60FF3E6F0B20130A");

                entity.HasIndex(e => e.NomeStatusCandidatura)
                    .HasName("UQ__StatusCa__B7B96DF3E9F5F9F3")
                    .IsUnique();

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
                    .HasName("PK__StatusCo__60463F1FC04EB88F");

                entity.Property(e => e.NomeStatusContrato)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Termo>(entity =>
            {
                entity.HasKey(e => e.IdTermo)
                    .HasName("PK__Termo__40EEF383A42778A8");

                entity.HasIndex(e => e.NumeroTermo)
                    .HasName("UQ__Termo__76FC0D91FFB4709C")
                    .IsUnique();
            });

            modelBuilder.Entity<TipoCurso>(entity =>
            {
                entity.HasKey(e => e.IdTipoCurso)
                    .HasName("PK__TipoCurs__FA83FBBEC8D1EFE6");

                entity.HasIndex(e => e.NomeTipoCurso)
                    .HasName("UQ__TipoCurs__AE222A0DAFFD0625")
                    .IsUnique();

                entity.Property(e => e.NomeTipoCurso)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPergunta>(entity =>
            {
                entity.HasKey(e => e.IdTipoPergunta)
                    .HasName("PK__TipoPerg__94655DF332A4E8B8");

                entity.HasIndex(e => e.NomeTipoPergunta)
                    .HasName("UQ__TipoPerg__017D214580FA116C")
                    .IsUnique();

                entity.Property(e => e.NomeTipoPergunta)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoResposta>(entity =>
            {
                entity.HasKey(e => e.IdTipoResposta)
                    .HasName("PK__TipoResp__AC70444A9734712B");

                entity.HasIndex(e => e.NomeTipoResposta)
                    .HasName("UQ__TipoResp__FEEF6D9AB7AB2534")
                    .IsUnique();

                entity.Property(e => e.NomeTipoResposta)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.IdTurno)
                    .HasName("PK__Turno__C1ECF79A5B993266");

                entity.HasIndex(e => e.NomeTurno)
                    .HasName("UQ__Turno__7C7C742F34D9611B")
                    .IsUnique();

                entity.Property(e => e.NomeTurno)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97EEC6C5D5");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D105342E21FD07")
                    .IsUnique();

                entity.HasIndex(e => e.EmailContato)
                    .HasName("UQ__Usuario__D0D34EF4EB12E5B8")
                    .IsUnique();

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
                    .HasName("PK__Vaga__A848DC3E6D5C9543");

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
                    .HasConstraintName("FK__Vaga__IdAreaVaga__5165187F");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Vaga__IdEmpresa__4F7CD00D");

                entity.HasOne(d => d.IdFormaContratacaoNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdFormaContratacao)
                    .HasConstraintName("FK__Vaga__IdFormaCon__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
