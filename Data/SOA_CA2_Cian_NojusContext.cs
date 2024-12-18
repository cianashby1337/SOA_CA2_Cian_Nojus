﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SOA_CA2_Cian_Nojus.Models;

// Secure .env file was implemented with help from this reference: https://dev.to/sudha533/how-to-create-a-env-file-in-an-aspnet-core-web-api-project-and-use-its-values-in-the-application-configuration-fam



namespace SOA_CA2_Cian_Nojus.Data
{
    public class SOA_CA2_Cian_NojusContext : DbContext
    {
        public SOA_CA2_Cian_NojusContext (DbContextOptions<SOA_CA2_Cian_NojusContext> options)
            : base(options)
        {
        }
        // Add the DbSet for the models
        public DbSet<SOA_CA2_Cian_Nojus.Models.Games> Games { get; set; } = default!;
        public DbSet<SOA_CA2_Cian_Nojus.Models.Developer> Developer { get; set; } = default!;
        public DbSet<SOA_CA2_Cian_Nojus.Models.Platform> Platform { get; set; } = default!;
		public DbSet<SOA_CA2_Cian_Nojus.Models.User> User { get; set; } = default!;
        public DbSet<GamePlatform> GamePlatform { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Set up the many-to-one relationship between games and developers
            modelBuilder.Entity<Games>().HasOne(g => g.Developer)
                .WithMany(d => d.Games)
                .HasForeignKey(g => g.developer_id)
                .IsRequired();

            // Set up the many-to-many relationship between games and platforms
            modelBuilder.Entity<GamePlatform>().
                HasKey(gp => new { gp.GameId, gp.PlatformId });


            // Set up the many-to-many relationship between games and platforms
            modelBuilder.Entity<GamePlatform>().
                HasOne(gp => gp.Game).
                WithMany(g => g.GamePlatforms).
                HasForeignKey(gp => gp.GameId);

            // Set up the many-to-many relationship between platforms and games
            modelBuilder.Entity<GamePlatform>().
                HasOne(gp => gp.Platform).
                WithMany(p => p.GamePlatforms).
                HasForeignKey(gp => gp.PlatformId);

            // Seed the database with games
            modelBuilder.Entity<Games>().HasData(
                new Games
                {
                    Id = 1,
                    title = "Halo",
                    genre = "Shooter",
                    release_year = 2001,
                    developer_id = 1,
                },
                new Games
                {
                    Id = 2,
                    title = "Gears of War",
                    genre = "Shooter",
                    release_year = 2006,
                    developer_id = 1,
                },
                new Games
                {
                    Id = 3,
                    title = "Forza Horizon",
                    genre = "Racing",
                    release_year = 2023,
                    developer_id = 1,
                },
                new Games
                {
                    Id = 4,
                    title = "The Legend of Zelda: Breath of the Wild",
                    genre = "Action-Adventure",
                    release_year = 2024,
                    developer_id = 2,
                },
                new Games
                {
                    Id = 5,
                    title = "Super Mario Odyssey",
                    genre = "Platformer",
                    release_year = 2008,
                    developer_id = 2,
                },
                new Games
                {
                    Id = 6,
                    title = "Mario Kart 8 Deluxe",
                    genre = "Racing",
                    release_year = 2020,
                    developer_id = 2,

                }
            );

            // Seed the database with developers and platforms
            modelBuilder.Entity<Developer>().HasData(
                new Developer
                {
                    Id = 1,
                    name = "Microsoft",
                    country = "USA"
                },
                new Developer
                {
                    Id = 2,
                    name = "Nintendo",
                    country = "Japan"
                }
            );

            modelBuilder.Entity<Platform>().HasData(
                new Platform
                {
                    Id = 1,
                    name = "Xbox",
                    manufacturer = "Microsoft"
                },
                new Platform
                {
                    Id = 2,
                    name = "Nintendo Switch",
                    manufacturer = "Nintendo"
                }
                );

            // Seed the database with the many-to-many relationship between games and platforms
            modelBuilder.Entity<GamePlatform>().HasData(
             new GamePlatform { GameId = 1, PlatformId = 1 },
             new GamePlatform { GameId = 2, PlatformId = 1 },
               new GamePlatform { GameId = 3, PlatformId = 1 },
                new GamePlatform { GameId = 3, PlatformId = 2 },
             new GamePlatform { GameId = 4, PlatformId = 2 }, 
             new GamePlatform { GameId = 5, PlatformId = 2 },
               new GamePlatform { GameId = 6, PlatformId = 2 }
            );

            // Seed the database with an admin user and a regular user
            modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
					email = "cianashby1337@gmail.com",
                    isAdministrator = true
				},
				new User
				{
					Id = 2,
					email = "nojusmat1@gmail.com",
					isAdministrator = false
				}
			);

			base.OnModelCreating(modelBuilder);
        }
    }
}
