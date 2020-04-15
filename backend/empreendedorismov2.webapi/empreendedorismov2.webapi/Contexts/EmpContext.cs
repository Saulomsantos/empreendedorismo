using Microsoft.EntityFrameworkCore;

namespace empreendedorismov2.webapi.Domains
{
    public partial class EmpContext : DbContext
    {
        public EmpContext()
        {
        }

        public EmpContext(DbContextOptions<EmpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CnpjDadosCadastraisPj> CnpjDadosCadastraisPj { get; set; }
        public virtual DbSet<CnpjDadosSociosPj> CnpjDadosSociosPj { get; set; }
        public virtual DbSet<TabCnae> TabCnae { get; set; }
        public virtual DbSet<TabSituacaoCadastral> TabSituacaoCadastral { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GCOFA7F\\SQLEXPRESS; Initial Catalog=bd_empreendedorismo; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CnpjDadosCadastraisPj>(entity =>
            {
                entity.HasKey(e => e.CodEmpresa);

                entity.ToTable("cnpj_dados_cadastrais_pj");

                entity.Property(e => e.CodEmpresa).HasColumnName("cod_empresa");

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CnaeFiscal).HasColumnName("cnae_fiscal");

                entity.Property(e => e.Cnpj).HasColumnName("cnpj");

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasColumnType("text");

                entity.Property(e => e.CorreioEletronico)
                    .HasColumnName("correio_eletronico")
                    .HasColumnType("text");

                entity.Property(e => e.DddFax)
                    .HasColumnName("ddd_fax")
                    .HasColumnType("text");

                entity.Property(e => e.DddTelefone1)
                    .HasColumnName("ddd_telefone_1")
                    .HasColumnType("text");

                entity.Property(e => e.DddTelefone2)
                    .HasColumnName("ddd_telefone_2")
                    .HasColumnType("text");

                entity.Property(e => e.DescricaoTipoLogradouro)
                    .HasColumnName("descricao_tipo_logradouro")
                    .HasColumnType("text");

                entity.Property(e => e.Logradouro)
                    .HasColumnName("logradouro")
                    .HasColumnType("text");

                entity.Property(e => e.Municipio)
                    .HasColumnName("municipio")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("text");

                entity.Property(e => e.PorteEmpresa)
                    .HasColumnName("porte_empresa")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .HasColumnName("razao_social")
                    .HasColumnType("text");

                entity.Property(e => e.SituacaoCadastral).HasColumnName("situacao_cadastral");

                entity.Property(e => e.Uf)
                    .HasColumnName("uf")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CnaeFiscalNavigation)
                    .WithMany(p => p.CnpjDadosCadastraisPj)
                    .HasForeignKey(d => d.CnaeFiscal)
                    .HasConstraintName("FK__cnpj_dado__cnae___4E88ABD4");

                entity.HasOne(d => d.SituacaoCadastralNavigation)
                    .WithMany(p => p.CnpjDadosCadastraisPj)
                    .HasForeignKey(d => d.SituacaoCadastral)
                    .HasConstraintName("FK__cnpj_dado__situa__4D94879B");
            });

            modelBuilder.Entity<CnpjDadosSociosPj>(entity =>
            {
                entity.HasKey(e => e.CodSocio);

                entity.ToTable("cnpj_dados_socios_pj");

                entity.Property(e => e.CodSocio)
                    .HasColumnName("cod_socio")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cnpj).HasColumnName("cnpj");

                entity.Property(e => e.CnpjCpfSocio)
                    .HasColumnName("CNPJ_CPF_SOCIO")
                    .HasColumnType("text");

                entity.Property(e => e.IdentificadorSocio)
                    .HasColumnName("identificador_socio")
                    .HasColumnType("text");

                entity.Property(e => e.NomeSocio)
                    .HasColumnName("nome_socio")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TabCnae>(entity =>
            {
                entity.HasKey(e => e.CodCnae);

                entity.ToTable("tab_cnae");

                entity.Property(e => e.CodCnae)
                    .HasColumnName("cod_cnae")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodClasse)
                    .HasColumnName("cod_classe")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CodDivisao)
                    .HasColumnName("cod_divisao")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CodGrupo)
                    .HasColumnName("cod_grupo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CodSecao)
                    .HasColumnName("cod_secao")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NmClasse)
                    .HasColumnName("nm_classe")
                    .HasColumnType("text");

                entity.Property(e => e.NmCnae)
                    .HasColumnName("nm_cnae")
                    .HasColumnType("text");

                entity.Property(e => e.NmDivisao)
                    .HasColumnName("nm_divisao")
                    .HasColumnType("text");

                entity.Property(e => e.NmGrupo)
                    .HasColumnName("nm_grupo")
                    .HasColumnType("text");

                entity.Property(e => e.NmSecao)
                    .HasColumnName("nm_secao")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TabSituacaoCadastral>(entity =>
            {
                entity.HasKey(e => e.CodSituacaoCadastral);

                entity.ToTable("tab_situacao_cadastral");

                entity.Property(e => e.CodSituacaoCadastral)
                    .HasColumnName("cod_situacao_cadastral")
                    .ValueGeneratedNever();

                entity.Property(e => e.NmSituacaoCadastral)
                    .HasColumnName("nm_situacao_cadastral")
                    .HasColumnType("text");
            });
        }
    }
}
