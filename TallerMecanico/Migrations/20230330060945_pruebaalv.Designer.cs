﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TallerMecanico.Models.Domain;

namespace TallerMecanico.Migrations
{
    [DbContext(typeof(TallerMecanicoDBContext))]
    [Migration("20230330060945_pruebaalv")]
    partial class pruebaalv
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.AgrupadoModulos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Descripcion");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AgrupadoModulos");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Color", b =>
                {
                    b.Property<Guid>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Nombre");

                    b.HasKey("ColorId");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Estado", b =>
                {
                    b.Property<Guid>("idEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Nombre");

                    b.HasKey("idEstado");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Marca", b =>
                {
                    b.Property<Guid>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Nombre");

                    b.HasKey("MarcaId");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Modelo", b =>
                {
                    b.Property<Guid>("ModeloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<Guid>("MarcaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Nombre");

                    b.HasKey("ModeloId");

                    b.HasIndex("MarcaId");

                    b.ToTable("Modelo");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Modulo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgrupadoModulosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Controller")
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Controller");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Metodo")
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Metodo");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("AgrupadoModulosId");

                    b.ToTable("Modulo");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.ModulosRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<Guid>("ModuloId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.HasIndex("RolId");

                    b.ToTable("ModulosRoles");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Descripcion");

                    b.Property<string>("Descripcion2")
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Descripcion2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Apellido");

                    b.Property<string>("Correo")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Correo");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Password");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("recovery")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Recovery_token");

                    b.HasKey("UsuarioId");

                    b.HasIndex("RolId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Vehiculo", b =>
                {
                    b.Property<Guid>("VehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<Guid>("ModeloId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VehiculoId");

                    b.HasIndex("ColorId");

                    b.HasIndex("ModeloId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.VehiculoMecanico", b =>
                {
                    b.Property<Guid>("VehiculoMecanicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<Guid>("EstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VehiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VehiculoMecanicoId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("VehiculoMecanico");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Modelo", b =>
                {
                    b.HasOne("TallerMecanico.Models.Domain.Entities.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Modulo", b =>
                {
                    b.HasOne("TallerMecanico.Models.Domain.Entities.AgrupadoModulos", "AgrupadoModulos")
                        .WithMany("Modulos")
                        .HasForeignKey("AgrupadoModulosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgrupadoModulos");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.ModulosRoles", b =>
                {
                    b.HasOne("TallerMecanico.Models.Domain.Entities.Modulo", "Modulo")
                        .WithMany("ModulosRoles")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TallerMecanico.Models.Domain.Entities.Rol", "Rol")
                        .WithMany("ModulosRoles")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modulo");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("TallerMecanico.Models.Domain.Entities.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Vehiculo", b =>
                {
                    b.HasOne("TallerMecanico.Models.Domain.Entities.Color", "Color")
                        .WithMany("Vehiculos")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TallerMecanico.Models.Domain.Entities.Modelo", "Modelo")
                        .WithMany("Vehiculos")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TallerMecanico.Models.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Vehiculos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Modelo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.VehiculoMecanico", b =>
                {
                    b.HasOne("TallerMecanico.Models.Domain.Entities.Estado", "Estado")
                        .WithMany("VehiculoMecanicos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TallerMecanico.Models.Domain.Entities.Usuario", "Usuario")
                        .WithMany("VehiculoMecanicos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TallerMecanico.Models.Domain.Entities.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Usuario");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.AgrupadoModulos", b =>
                {
                    b.Navigation("Modulos");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Color", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Estado", b =>
                {
                    b.Navigation("VehiculoMecanicos");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Marca", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Modelo", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Modulo", b =>
                {
                    b.Navigation("ModulosRoles");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Rol", b =>
                {
                    b.Navigation("ModulosRoles");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("TallerMecanico.Models.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("VehiculoMecanicos");

                    b.Navigation("Vehiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
