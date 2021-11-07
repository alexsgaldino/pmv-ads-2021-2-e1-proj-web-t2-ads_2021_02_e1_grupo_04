﻿// <auto-generated />
using System;
using JitResidencial.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JitResidencial.Persistence.Migrations
{
    [DbContext(typeof(JitResidencialContext))]
    [Migration("20211104154144_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("JitResidencial.Domain.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("JitResidencial.Domain.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .HasColumnType("TEXT");

                    b.Property<string>("CEP")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rua")
                        .HasColumnType("TEXT");

                    b.Property<string>("UF")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("JitResidencial.Domain.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataMovimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("EstoqueDisponivel")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("JitResidencial.Domain.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CNPJ")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ListaPrecoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ListaPrecoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("JitResidencial.Domain.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeGrupo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("JitResidencial.Domain.ListaPreco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrecoUnitario")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ListasPrecos");
                });

            modelBuilder.Entity("JitResidencial.Domain.Movimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataMovimento")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantidadeEntrada")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantidadeSaida")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Movimentos");
                });

            modelBuilder.Entity("JitResidencial.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodigoBarras")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataValidade")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstoqueId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ListaPrecoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovimentoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeProduto")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnidadeMedidaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Volume")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("JitResidencial.Domain.UnidadeMedida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Unidade")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("UnidadesMedidas");
                });

            modelBuilder.Entity("JitResidencial.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GrupoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrimeiroNome")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UltimaAtualizacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioLogin")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("JitResidencial.Domain.Categoria", b =>
                {
                    b.HasOne("JitResidencial.Domain.Produto", null)
                        .WithMany("Categorias")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JitResidencial.Domain.Estoque", b =>
                {
                    b.HasOne("JitResidencial.Domain.Produto", null)
                        .WithMany("Estoques")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JitResidencial.Domain.Fornecedor", b =>
                {
                    b.HasOne("JitResidencial.Domain.ListaPreco", null)
                        .WithMany("Fornecedores")
                        .HasForeignKey("ListaPrecoId");

                    b.HasOne("JitResidencial.Domain.Produto", null)
                        .WithMany("Fornecedores")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JitResidencial.Domain.ListaPreco", b =>
                {
                    b.HasOne("JitResidencial.Domain.Produto", null)
                        .WithMany("ListasPrecos")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JitResidencial.Domain.Movimento", b =>
                {
                    b.HasOne("JitResidencial.Domain.Produto", null)
                        .WithMany("Movimentos")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JitResidencial.Domain.Produto", b =>
                {
                    b.HasOne("JitResidencial.Domain.Endereco", null)
                        .WithMany("Produtos")
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("JitResidencial.Domain.UnidadeMedida", b =>
                {
                    b.HasOne("JitResidencial.Domain.Produto", null)
                        .WithMany("UnidadesMedidas")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JitResidencial.Domain.Endereco", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("JitResidencial.Domain.ListaPreco", b =>
                {
                    b.Navigation("Fornecedores");
                });

            modelBuilder.Entity("JitResidencial.Domain.Produto", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Estoques");

                    b.Navigation("Fornecedores");

                    b.Navigation("ListasPrecos");

                    b.Navigation("Movimentos");

                    b.Navigation("UnidadesMedidas");
                });
#pragma warning restore 612, 618
        }
    }
}
