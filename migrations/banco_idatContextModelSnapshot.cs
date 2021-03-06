// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using banco_api.Models;

namespace banco_api.migrations
{
    [DbContext(typeof(banco_idatContext))]
    partial class banco_idatContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("banco_api.Models.Cliente", b =>
                {
                    b.Property<int>("NCuenta")
                        .HasColumnType("int(11)")
                        .HasColumnName("n_cuenta");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("apellido");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("dni");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("nombre");

                    b.HasKey("NCuenta")
                        .HasName("PRIMARY");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("banco_api.Models.Deposito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("Cliente")
                        .HasColumnType("int(11)")
                        .HasColumnName("cliente");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.Property<int>("Monto")
                        .HasColumnType("int(11)")
                        .HasColumnName("monto");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Cliente" }, "cliente");

                    b.ToTable("depositos");
                });

            modelBuilder.Entity("banco_api.Models.Retiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("Cliente")
                        .HasColumnType("int(11)")
                        .HasColumnName("cliente");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.Property<int>("Monto")
                        .HasColumnType("int(11)")
                        .HasColumnName("monto");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Cliente" }, "cliente")
                        .HasDatabaseName("cliente1");

                    b.ToTable("retiros");
                });

            modelBuilder.Entity("banco_api.Models.Deposito", b =>
                {
                    b.HasOne("banco_api.Models.Cliente", "ClienteNavigation")
                        .WithMany("Depositos")
                        .HasForeignKey("Cliente")
                        .HasConstraintName("depositos_ibfk_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClienteNavigation");
                });

            modelBuilder.Entity("banco_api.Models.Retiro", b =>
                {
                    b.HasOne("banco_api.Models.Cliente", "ClienteNavigation")
                        .WithMany("Retiros")
                        .HasForeignKey("Cliente")
                        .HasConstraintName("retiros_ibfk_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClienteNavigation");
                });

            modelBuilder.Entity("banco_api.Models.Cliente", b =>
                {
                    b.Navigation("Depositos");

                    b.Navigation("Retiros");
                });
#pragma warning restore 612, 618
        }
    }
}
