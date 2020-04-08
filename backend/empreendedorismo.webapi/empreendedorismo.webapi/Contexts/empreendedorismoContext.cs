using Microsoft.EntityFrameworkCore;
using empreendedorismo.webapi.Domains;

namespace empreendedorismo.webapi.Contexts
{
    /// <summary>
    /// Classe responsável pelo contexto que faz a comunicação entre API e Banco de dados
    /// </summary>
    public partial class EmpreendedorismoContext : DbContext
    {
        public EmpreendedorismoContext()
        {
        }

        public EmpreendedorismoContext(DbContextOptions<EmpreendedorismoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CnpjDadosCadastraisPj> CnpjDadosCadastraisPj { get; set; }
        public virtual DbSet<TabCnae> TabCnae { get; set; }
        public virtual DbSet<TabSituacaoCadastral> TabSituacaoCadastral { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GCOFA7F\\SQLEXPRESS; Initial Catalog=bd_dados_qsa_cnpj; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CnpjDadosCadastraisPj>(entity =>
            {
                entity.HasKey(e => e.Cnpj);

                entity.ToTable("cnpj_dados_cadastrais_pj");

                entity.Property(e => e.Cnpj)
                    .HasColumnName("cnpj")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CnaeFiscal).HasColumnName("cnae_fiscal");

                entity.Property(e => e.Municipio)
                    .HasColumnName("municipio")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .HasColumnName("nome_fantasia")
                    .HasColumnType("text");

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
                    .HasConstraintName("FK__cnpj_dado__cnae___6EF57B66");

                entity.HasOne(d => d.SituacaoCadastralNavigation)
                    .WithMany(p => p.CnpjDadosCadastraisPj)
                    .HasForeignKey(d => d.SituacaoCadastral)
                    .HasConstraintName("FK__cnpj_dado__situa__6FE99F9F");
            });

            modelBuilder.Entity<TabCnae>(entity =>
            {
                entity.HasKey(e => e.CodCnae);

                entity.ToTable("tab_cnae");

                entity.Property(e => e.CodCnae)
                    .HasColumnName("cod_cnae")
                    .ValueGeneratedNever();

                entity.Property(e => e.NmCnae)
                    .HasColumnName("nm_cnae")
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
