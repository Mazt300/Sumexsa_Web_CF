﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modelo.Modelo;

#nullable disable

namespace Modelo.Migrations
{
    [DbContext(typeof(DbContexto))]
    [Migration("20220307182527_proveedorbanco")]
    partial class proveedorbanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Modelo.Modelo.TablasCatalogo.ClienteImportador", b =>
                {
                    b.Property<int>("Idclienteimportador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idclienteimportador"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PersonaContactoIdPersonaContacto")
                        .HasColumnType("int");

                    b.Property<string>("Ruc_Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idclienteimportador");

                    b.HasIndex("PersonaContactoIdPersonaContacto");

                    b.ToTable("ClienteImportador", "PV");
                });

            modelBuilder.Entity("Modelo.Modelo.TablasCatalogo.PersonaContacto", b =>
                {
                    b.Property<int>("IdPersonaContacto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersonaContacto"), 1L, 1);

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersonaContacto");

                    b.ToTable("PersonaContacto", "PV");
                });

            modelBuilder.Entity("Modelo.Modelo.TablasCatalogo.ClienteImportador", b =>
                {
                    b.HasOne("Modelo.Modelo.TablasCatalogo.PersonaContacto", "PersonaContacto")
                        .WithMany()
                        .HasForeignKey("PersonaContactoIdPersonaContacto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonaContacto");
                });
#pragma warning restore 612, 618
        }
    }
}
