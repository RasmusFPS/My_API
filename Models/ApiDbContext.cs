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
            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, URL = "https://www.w3schools.com/", InterestId = 1, PersonId = 1},
                new Link { Id = 2, URL = "https://open.spotify.com/", InterestId = 2, PersonId = 1 },

                new Link { Id = 3, URL = "https://steamcommunity.com/id/RasmusFPS/", InterestId = 3, PersonId = 2 },

                new Link { Id = 4, URL = "https://www.speedrun.com/users/RasmusFPS/", InterestId = 4, PersonId = 3 },

                new Link { Id = 5, URL = "https://www.arla.se/recept/", InterestId = 5, PersonId = 4 }
                );


        }



    }
}
