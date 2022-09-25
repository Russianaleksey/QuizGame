﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizGame.Data;

#nullable disable

namespace QuizGame.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220925030950_AddQuestions")]
    partial class AddQuestions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.7.22376.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuizGame.Models.Board", b =>
                {
                    b.Property<int>("BoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BoardId"));

                    b.Property<int>("BoardSize")
                        .HasColumnType("int");

                    b.Property<string>("FriendlyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Spaces")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BoardId");

                    b.HasIndex("GameId")
                        .IsUnique()
                        .HasFilter("[GameId] IS NOT NULL");

                    b.ToTable("Boards");

                    b.HasData(
                        new
                        {
                            BoardId = 1,
                            BoardSize = 18,
                            FriendlyName = "GiraffeBoard",
                            GameId = 1,
                            Spaces = "0200400001000300"
                        },
                        new
                        {
                            BoardId = 2,
                            BoardSize = 18,
                            FriendlyName = "CheetahBoard",
                            GameId = 2,
                            Spaces = "0200400001000300"
                        });
                });

            modelBuilder.Entity("QuizGame.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            Name = "AlexGame",
                            State = 0
                        },
                        new
                        {
                            GameId = 2,
                            Name = "BigGamersOnly",
                            State = 0
                        },
                        new
                        {
                            GameId = 3,
                            Name = "SmallGamersOnly",
                            State = 0
                        });
                });

            modelBuilder.Entity("QuizGame.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Space")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("GameId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            GameId = 1,
                            Name = "Alex",
                            Space = 0
                        },
                        new
                        {
                            PlayerId = 2,
                            GameId = 1,
                            Name = "Brian",
                            Space = 0
                        },
                        new
                        {
                            PlayerId = 3,
                            GameId = 1,
                            Name = "Jahlaud",
                            Space = 0
                        },
                        new
                        {
                            PlayerId = 4,
                            GameId = 1,
                            Name = "Adrian",
                            Space = 0
                        },
                        new
                        {
                            PlayerId = 5,
                            GameId = 1,
                            Name = "Felix",
                            Space = 0
                        });
                });

            modelBuilder.Entity("QuizGame.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProblemStatement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            Answer = "Enigma",
                            ProblemStatement = "What's the name of the machine used by the allies in WW2 to crack Germany's codes?",
                            Type = 2
                        },
                        new
                        {
                            QuestionId = 2,
                            Answer = "Alan Turing",
                            ProblemStatement = "Who is the father of computer science?",
                            Type = 2
                        },
                        new
                        {
                            QuestionId = 3,
                            Answer = "Apple 1",
                            ProblemStatement = "What was the first computer system that used color display?",
                            Type = 2
                        },
                        new
                        {
                            QuestionId = 4,
                            Answer = "Ada Lovelace",
                            ProblemStatement = "What was the name of the first computer programmer?",
                            Type = 2
                        },
                        new
                        {
                            QuestionId = 5,
                            Answer = "Intel",
                            ProblemStatement = "Which popular company designed the first CPU?",
                            Type = 2
                        },
                        new
                        {
                            QuestionId = 6,
                            Answer = "Commodore 64",
                            ProblemStatement = "Which is the single most popular computer system ever sold?",
                            Type = 2
                        });
                });

            modelBuilder.Entity("QuizGame.Models.Board", b =>
                {
                    b.HasOne("QuizGame.Models.Game", "Game")
                        .WithOne("Board")
                        .HasForeignKey("QuizGame.Models.Board", "GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("QuizGame.Models.Player", b =>
                {
                    b.HasOne("QuizGame.Models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("QuizGame.Models.Game", b =>
                {
                    b.Navigation("Board");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
