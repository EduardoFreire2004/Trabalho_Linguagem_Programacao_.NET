﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trabalho_Linguagem_Programacao_.NET.Models;

#nullable disable

namespace Trabalho_Linguagem_Programacao_.NET.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240923190455_Pedidos")]
    partial class Pedidos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trabalho_Linguagem_Programacao_.NET.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("celular")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("email")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("endereco")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Trabalho_Linguagem_Programacao_.NET.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("celular")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("email")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("produtoID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("produtoID");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Trabalho_Linguagem_Programacao_.NET.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("clienteID")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<int>("produtoID")
                        .HasColumnType("int");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("clienteID");

                    b.HasIndex("produtoID");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Trabalho_Linguagem_Programacao_.NET.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("categoria")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<float>("preco")
                        .HasColumnType("real");

                    b.Property<int>("qtde_estoque")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Trabalho_Linguagem_Programacao_.NET.Models.Fornecedor", b =>
                {
                    b.HasOne("Trabalho_Linguagem_Programacao_.NET.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("produtoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("produto");
                });

            modelBuilder.Entity("Trabalho_Linguagem_Programacao_.NET.Models.Pedido", b =>
                {
                    b.HasOne("Trabalho_Linguagem_Programacao_.NET.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trabalho_Linguagem_Programacao_.NET.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("produtoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("produto");
                });
#pragma warning restore 612, 618
        }
    }
}
