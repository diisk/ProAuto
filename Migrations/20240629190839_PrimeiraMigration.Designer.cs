﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProAuto.Data;

#nullable disable

namespace ProAuto.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240629190839_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ProAuto.Models.Associado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Associados");
                });

            modelBuilder.Entity("ProAuto.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssociadoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssociadoId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ProAuto.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssociadoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssociadoId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("ProAuto.Models.Endereco", b =>
                {
                    b.HasOne("ProAuto.Models.Associado", "Associado")
                        .WithOne("Endereco")
                        .HasForeignKey("ProAuto.Models.Endereco", "AssociadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Associado");
                });

            modelBuilder.Entity("ProAuto.Models.Veiculo", b =>
                {
                    b.HasOne("ProAuto.Models.Associado", "Associado")
                        .WithMany("Veiculos")
                        .HasForeignKey("AssociadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Associado");
                });

            modelBuilder.Entity("ProAuto.Models.Associado", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
