using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.AutoPecas.WebApi.Domains
{
    public partial class AutoPecasContext : DbContext
    {
        public AutoPecasContext()
        {
        }

        public AutoPecasContext(DbContextOptions<AutoPecasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fornecedores> Fornecedores { get; set; }
        public virtual DbSet<Pecas> Pecas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=T_AutoPecas;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedores>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor);

                entity.HasIndex(e => e.NomeFantasia)
                    .HasName("UQ__Forneced__E7ADFC705841D323")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial)
                    .HasName("UQ__Forneced__9BF93A30EBC1C7DB")
                    .IsUnique();

                entity.Property(e => e.Cnpj).HasColumnName("cnpj");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("endereco")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasColumnName("nomeFantasia")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasColumnName("razaoSocial")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Fornecedores)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Fornecedo__IdUsu__4F7CD00D");
            });

            modelBuilder.Entity<Pecas>(entity =>
            {
                entity.HasKey(e => e.IdPecas);

                entity.HasIndex(e => e.Codigo)
                    .HasName("UQ__Pecas__40F9A20674B1537E")
                    .IsUnique();

                entity.HasIndex(e => e.Descricao)
                    .HasName("UQ__Pecas__91D38C28FBB84A41")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.PrecoCusto)
                    .HasColumnName("precoCusto")
                    .HasColumnType("money");

                entity.Property(e => e.PrecoVenda)
                    .HasColumnName("precoVenda")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Pecas)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK__Pecas__IdFornece__5441852A");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D10534DFA1E615")
                    .IsUnique();

                entity.HasIndex(e => e.Senha)
                    .HasName("UQ__Usuarios__7ABB9731815F719D")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
