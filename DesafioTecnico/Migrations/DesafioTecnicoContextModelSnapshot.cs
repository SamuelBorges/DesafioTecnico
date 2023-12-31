﻿// <auto-generated />
using System;
using DesafioTecnico.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioTecnico.Migrations
{
    [DbContext(typeof(DesafioTecnicoContext))]
    partial class DesafioTecnicoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DesafioTecnico.Models.RegistroMovimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataSaida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecoTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("RegistroMovimento");
                });

            modelBuilder.Entity("DesafioTecnico.Models.TabelaPreco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataVigenciaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVigenciaInicial")
                        .HasColumnType("datetime2");

                    b.Property<double>("ValorAdicional")
                        .HasColumnType("float");

                    b.Property<double>("ValorInicial")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("TabelaPreco");
                });
#pragma warning restore 612, 618
        }
    }
}
