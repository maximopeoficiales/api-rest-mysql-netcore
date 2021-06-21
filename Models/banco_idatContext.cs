using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace banco_api.Models
{
    public partial class banco_idatContext : DbContext
    {
        public banco_idatContext()
        {
        }

        public banco_idatContext(DbContextOptions<banco_idatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Deposito> Depositos { get; set; }
        public virtual DbSet<Retiro> Retiros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=banco_idat;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.34-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.NCuenta)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.Property(e => e.NCuenta)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("n_cuenta");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("apellido");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("dni");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.ToTable("depositos");

                entity.HasIndex(e => e.Cliente, "cliente");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("cliente");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Monto)
                    .HasColumnType("int(11)")
                    .HasColumnName("monto");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Depositos)
                    .HasForeignKey(d => d.Cliente)
                    .HasConstraintName("depositos_ibfk_1");
            });

            modelBuilder.Entity<Retiro>(entity =>
            {
                entity.ToTable("retiros");

                entity.HasIndex(e => e.Cliente, "cliente");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("cliente");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Monto)
                    .HasColumnType("int(11)")
                    .HasColumnName("monto");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Retiros)
                    .HasForeignKey(d => d.Cliente)
                    .HasConstraintName("retiros_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
