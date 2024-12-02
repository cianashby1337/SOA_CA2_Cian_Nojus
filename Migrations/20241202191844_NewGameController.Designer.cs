﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SOA_CA2_Cian_Nojus.Data;

#nullable disable

namespace SOA_CA2_Cian_Nojus.Migrations
{
    [DbContext(typeof(SOA_CA2_Cian_NojusContext))]
    [Migration("20241202191844_NewGameController")]
    partial class NewGameController
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("SOA_CA2_Cian_Nojus.Models.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Developer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            country = "USA",
                            name = "Microsoft"
                        },
                        new
                        {
                            Id = 2,
                            country = "Japan",
                            name = "Nintendo"
                        });
                });

            modelBuilder.Entity("SOA_CA2_Cian_Nojus.Models.GamePlatform", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlatformId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameId", "PlatformId");

                    b.HasIndex("PlatformId");

                    b.ToTable("GamePlatform");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            PlatformId = 1
                        },
                        new
                        {
                            GameId = 2,
                            PlatformId = 1
                        },
                        new
                        {
                            GameId = 3,
                            PlatformId = 1
                        },
                        new
                        {
                            GameId = 3,
                            PlatformId = 2
                        },
                        new
                        {
                            GameId = 4,
                            PlatformId = 2
                        },
                        new
                        {
                            GameId = 5,
                            PlatformId = 2
                        },
                        new
                        {
                            GameId = 6,
                            PlatformId = 2
                        });
                });

            modelBuilder.Entity("SOA_CA2_Cian_Nojus.Models.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("developer_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("release_year")
                        .HasColumnType("INTEGER");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("developer_id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            developer_id = 1,
                            genre = "Shooter",
                            release_year = 2001,
                            title = "Halo"
                        },
                        new
                        {
                            Id = 2,
                            developer_id = 1,
                            genre = "Shooter",
                            release_year = 2006,
                            title = "Gears of War"
                        },
                        new
                        {
                            Id = 3,
                            developer_id = 1,
                            genre = "Racing",
                            release_year = 2023,
                            title = "Forza Horizon"
                        },
                        new
                        {
                            Id = 4,
                            developer_id = 2,
                            genre = "Action-Adventure",
                            release_year = 2024,
                            title = "The Legend of Zelda: Breath of the Wild"
                        },
                        new
                        {
                            Id = 5,
                            developer_id = 2,
                            genre = "Platformer",
                            release_year = 2008,
                            title = "Super Mario Odyssey"
                        },
                        new
                        {
                            Id = 6,
                            developer_id = 2,
                            genre = "Racing",
                            release_year = 2020,
                            title = "Mario Kart 8 Deluxe"
                        });
                });

            modelBuilder.Entity("SOA_CA2_Cian_Nojus.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("manufacturer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Platform");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            manufacturer = "Microsoft",
                            name = "Xbox"
                        },
                        new
                        {
                            Id = 2,
                            manufacturer = "Nintendo",
                            name = "Nintendo Switch"
                        });
                });

            modelBuilder.Entity("SOA_CA2_Cian_Nojus.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isAdministrator")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            email = "admin@gmail.com",
                            isAdministrator = true
                        },
                        new
                        {
                            Id = 2,
                            email = "admin2@gmail.com",
                            isAdministrator = false
                        });
                });

            modelBuilder.Entity("SOA_CA2_Cian_Nojus.Models.GamePlatform", b =>
                {
                    b.HasOne("SOA_CA2_Cian_Nojus.Models.Games", "Game")
                        .WithMany("GamePlatforms")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SOA_CA2_Cian_Nojus.Models.Platform", "Platform")
                        .WithMany("GamePlatforms")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("SOA_CA2_Cian_Nojus.Models.Games", b =>
                {
                    b.HasOne("SOA_CA2_Cian_Nojus.Models.Developer", "Developer")
                        .WithMany("Games")
                        .HasForeignKey("developer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("SOA_CA2_Cian_Nojus.Models.Developer", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("SOA_CA2_Cian_Nojus.Models.Games", b =>
                {
                    b.Navigation("GamePlatforms");
                });

            modelBuilder.Entity("SOA_CA2_Cian_Nojus.Models.Platform", b =>
                {
                    b.Navigation("GamePlatforms");
                });
#pragma warning restore 612, 618
        }
    }
}