﻿// <auto-generated />
using System;
using JitResidencial.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JitResidencial.Persistence.Migrations
{
    [DbContext(typeof(JitResidencialContext))]
    [Migration("20211102021936_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("JIT_Residencial.Domain.Categoria", b =>
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

            modelBuilder.Entity("JIT_Residencial.Domain.Endereco", b =>
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

            modelBuilder.Entity("JIT_Residencial.Domain.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataMovimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("EstoqueDisponivel")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.Fornecedor", b =>
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

            modelBuilder.Entity("JIT_Residencial.Domain.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeGrupo")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.ListaPreco", b =>
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

            modelBuilder.Entity("JIT_Residencial.Domain.Movimento", b =>
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

            modelBuilder.Entity("JIT_Residencial.Domain.Produto", b =>
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

            modelBuilder.Entity("JIT_Residencial.Domain.UnidadeMedida", b =>
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

            modelBuilder.Entity("JIT_Residencial.Domain.Usuario", b =>
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

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.Categoria", b =>
                {
                    b.HasOne("JIT_Residencial.Domain.Produto", null)
                        .WithMany("Categorias")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.Estoque", b =>
                {
                    b.HasOne("JIT_Residencial.Domain.Produto", null)
                        .WithMany("Estoques")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.Fornecedor", b =>
                {
                    b.HasOne("JIT_Residencial.Domain.ListaPreco", null)
                        .WithMany("Fornecedores")
                        .HasForeignKey("ListaPrecoId");

                    b.HasOne("JIT_Residencial.Domain.Produto", null)
                        .WithMany("Fornecedores")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.Grupo", b =>
                {
                    b.HasOne("JIT_Residencial.Domain.Usuario", null)
                        .WithMany("Grupos")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.ListaPreco", b =>
                {
                    b.HasOne("JIT_Residencial.Domain.Produto", null)
                        .WithMany("ListasPrecos")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.Movimento", b =>
                {
                    b.HasOne("JIT_Residencial.Domain.Produto", null)
                        .WithMany("Movimentos")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.Produto", b =>
                {
                    b.HasOne("JIT_Residencial.Domain.Endereco", null)
                        .WithMany("Produtos")
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.UnidadeMedida", b =>
                {
                    b.HasOne("JIT_Residencial.Domain.Produto", null)
                        .WithMany("UnidadesMedidas")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.Usuario", b =>
                {
                    b.HasOne("JIT_Residencial.Domain.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JIT_Residencial.Domain.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.Endereco", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.ListaPreco", b =>
                {
                    b.Navigation("Fornecedores");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.Produto", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Estoques");

                    b.Navigation("Fornecedores");

                    b.Navigation("ListasPrecos");

                    b.Navigation("Movimentos");

                    b.Navigation("UnidadesMedidas");
                });

            modelBuilder.Entity("JIT_Residencial.Domain.Usuario", b =>
                {
                    b.Navigation("Grupos");
                });
#pragma warning restore 612, 618
        }
    }
}
