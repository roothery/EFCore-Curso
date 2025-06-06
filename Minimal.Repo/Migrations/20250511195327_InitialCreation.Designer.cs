﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Minimal.API.DbContexts;

#nullable disable

namespace Minimal.Repo.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250511195327_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Minimal.Domain.Entities.Diretor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Diretores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Christopher Nolan"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Steven Spielberg"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Quentin Tarantino"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Martin Scorsese"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "James Cameron"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Greta Gerwig"
                        });
                });

            modelBuilder.Entity("Minimal.Domain.Entities.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiretorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DiretorId");

                    b.ToTable("Filmes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = 2010,
                            DiretorId = 1,
                            Titulo = "Inception"
                        },
                        new
                        {
                            Id = 2,
                            Ano = 2014,
                            DiretorId = 1,
                            Titulo = "Interstellar"
                        },
                        new
                        {
                            Id = 3,
                            Ano = 2008,
                            DiretorId = 1,
                            Titulo = "The Dark Knight"
                        },
                        new
                        {
                            Id = 4,
                            Ano = 1993,
                            DiretorId = 2,
                            Titulo = "Jurassic Park"
                        },
                        new
                        {
                            Id = 5,
                            Ano = 1982,
                            DiretorId = 2,
                            Titulo = "E.T. the Extra-Terrestrial"
                        },
                        new
                        {
                            Id = 6,
                            Ano = 1993,
                            DiretorId = 2,
                            Titulo = "Schindler's List"
                        },
                        new
                        {
                            Id = 7,
                            Ano = 1994,
                            DiretorId = 3,
                            Titulo = "Pulp Fiction"
                        },
                        new
                        {
                            Id = 8,
                            Ano = 2003,
                            DiretorId = 3,
                            Titulo = "Kill Bill: Vol. 1"
                        },
                        new
                        {
                            Id = 9,
                            Ano = 2012,
                            DiretorId = 3,
                            Titulo = "Django Unchained"
                        },
                        new
                        {
                            Id = 10,
                            Ano = 1990,
                            DiretorId = 4,
                            Titulo = "Goodfellas"
                        },
                        new
                        {
                            Id = 11,
                            Ano = 2019,
                            DiretorId = 4,
                            Titulo = "The Irishman"
                        },
                        new
                        {
                            Id = 12,
                            Ano = 1976,
                            DiretorId = 4,
                            Titulo = "Taxi Driver"
                        },
                        new
                        {
                            Id = 13,
                            Ano = 2009,
                            DiretorId = 5,
                            Titulo = "Avatar"
                        },
                        new
                        {
                            Id = 14,
                            Ano = 1997,
                            DiretorId = 5,
                            Titulo = "Titanic"
                        },
                        new
                        {
                            Id = 15,
                            Ano = 1984,
                            DiretorId = 5,
                            Titulo = "The Terminator"
                        },
                        new
                        {
                            Id = 16,
                            Ano = 2017,
                            DiretorId = 6,
                            Titulo = "Lady Bird"
                        },
                        new
                        {
                            Id = 17,
                            Ano = 2019,
                            DiretorId = 6,
                            Titulo = "Little Women"
                        },
                        new
                        {
                            Id = 18,
                            Ano = 2023,
                            DiretorId = 6,
                            Titulo = "Barbie"
                        });
                });

            modelBuilder.Entity("Minimal.Domain.Entities.Filme", b =>
                {
                    b.HasOne("Minimal.Domain.Entities.Diretor", "Diretor")
                        .WithMany("Filmes")
                        .HasForeignKey("DiretorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");
                });

            modelBuilder.Entity("Minimal.Domain.Entities.Diretor", b =>
                {
                    b.Navigation("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}
