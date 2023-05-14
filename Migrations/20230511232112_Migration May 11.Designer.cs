﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using siscm_data_management.Database;

#nullable disable

namespace siscm_data_management.Migrations
{
    [DbContext(typeof(DatabaseSettings))]
    [Migration("20230511232112_Migration May 11")]
    partial class MigrationMay11
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("siscm_data_management.Models.Especificacoes.Veiculos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Capacidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Garantia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PneusRodas")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Potencia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Preco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tempo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Torque")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VelocidadeMaxima")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VolumePortaMalas")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}