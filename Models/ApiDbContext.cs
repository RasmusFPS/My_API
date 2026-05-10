using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MYAPI.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Interest> Interest { get; set; }
        public DbSet<PersonInterests> PersonInterests { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _SeedData(modelBuilder);
        }

        private void _SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Malte Andersson", Phone_Number = "070-000-0000" },
                new Person { Id = 2, Name = "Max Granqvist", Phone_Number = "070-000-0000" },
                new Person { Id = 3, Name = "Ben Thomasson", Phone_Number = "070-000-0000" },
                new Person { Id = 4, Name = "Rasmus Andersen", Phone_Number = "070-000-0000" }
                );

            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Programing", Description = "The act of writing code and developing a product/application"},
                new Interest { Id = 2, Title = "Music", Description = "Listening or creating music" },
                new Interest { Id = 3, Title = "Gaming", Description = "Playing or Creating Games" },
                new Interest { Id = 4, Title = "Speedrunning", Description = "Completing a task/game as fast as you can" },
                new Interest { Id = 5, Title = "Cooking", Description = "Creating delicious food" }
                );

            modelBuilder.Entity<PersonInterests>().HasData(
                new PersonInterests {Id= 1, PersonId = 1, InterestId = 1},
                new PersonInterests {Id = 2, PersonId = 1, InterestId = 2 },

                new PersonInterests {Id = 3, PersonId = 2, InterestId = 2 },
                new PersonInterests {Id = 4, PersonId = 2, InterestId = 3 },

                new PersonInterests {Id = 5, PersonId = 3, InterestId = 3 },

                new PersonInterests {Id = 6, PersonId = 4, InterestId = 4 },
                new PersonInterests {Id = 7, PersonId = 4, InterestId = 5 }
                );

            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, URL = "https://Github.com", PersonId = 1, InterestId = 1},
                new Link { Id = 2, URL = "https://Spotify.com", PersonId = 1, InterestId = 2 },

                new Link { Id = 3, URL = "https://Spotify.com", PersonId = 2, InterestId = 2 },
                new Link { Id = 4, URL = "https://Steam.com", PersonId = 2, InterestId = 3 },

                new Link { Id = 5, URL = "https://Steam.com", PersonId = 3, InterestId = 3 },

                new Link { Id = 6, URL = "https://www.speedrun.com/users/RasmusFPS", PersonId = 4, InterestId = 4 },
                new Link { Id = 7, URL = "https://Arla.se/Recept", PersonId = 4, InterestId = 5 }
                );


        }



    }
}
