using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IO;

namespace Labb_3_bygga_ett_API_SUT25_avancerad_dotnet
{
    public class InterestDBContext : DbContext
    {
        public InterestDBContext(DbContextOptions<InterestDBContext> options) : base(options)
        {

        }
        public DbSet<Interest> interests { get; set; }

        public DbSet<Person> persons { get; set; }
        public DbSet<Website> websites { get; set; }

        public DbSet<PersonInterest> personInterests { get; set; }

        

        //seed data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonInterest>()
        .HasKey(pi => new { pi.PersonId, pi.InterestId });


            modelBuilder.Entity<Person>().HasData(
        new Person { Id = 1, FirstName = "Anna", LastName = "Svensson", Phone = 111111 },
        new Person { Id = 2, FirstName = "Björn", LastName = "Karlsson", Phone = 222222 },
        new Person { Id = 3, FirstName = "Cecilia", LastName = "Lind", Phone = 333333 },
        new Person { Id = 4, FirstName = "David", LastName = "Persson", Phone = 444444 },
        new Person { Id = 5, FirstName = "Elin", LastName = "Johansson", Phone = 555555 },
        new Person { Id = 6, FirstName = "Filip", LastName = "Berg", Phone = 666666 },
        new Person { Id = 7, FirstName = "Greta", LastName = "Holm", Phone = 777777 },
        new Person { Id = 8, FirstName = "Hugo", LastName = "Sand", Phone = 888888 },
        new Person { Id = 9, FirstName = "Ida", LastName = "Ek", Phone = 999999 },
        new Person { Id = 10, FirstName = "Johan", LastName = "Ström", Phone = 101010 }
    );

            modelBuilder.Entity<Interest>().HasData(
    new Interest { Id = 1, Title = "Fotboll", Description = "Sport med lag och boll" },
    new Interest { Id = 2, Title = "Programmering", Description = "Skapa program och system" },
    new Interest { Id = 3, Title = "Matlagning", Description = "Laga mat och testa recept" },
    new Interest { Id = 4, Title = "Gaming", Description = "Spela datorspel" },
    new Interest { Id = 5, Title = "Resor", Description = "Upptäcka nya platser" },
    new Interest { Id = 6, Title = "Musik", Description = "Lyssna och skapa musik" });

            modelBuilder.Entity<PersonInterest>().HasData(


        // Anna
        new { PersonId = 1, InterestId = 1 },
        new { PersonId = 1, InterestId = 3 },
        new { PersonId = 1, InterestId = 5 },

        // Björn
        new { PersonId = 2, InterestId = 2 },
        new { PersonId = 2, InterestId = 4 },

        // Cecilia
        new { PersonId = 3, InterestId = 1 },
        new { PersonId = 3, InterestId = 2 },
        new { PersonId = 3, InterestId = 6 },

        // David
        new { PersonId = 4, InterestId = 4 },

        // Elin
        new { PersonId = 5, InterestId = 3 },
        new { PersonId = 5, InterestId = 5 },
        new { PersonId = 5, InterestId = 6 },

        // Filip
        new { PersonId = 6, InterestId = 2 },
        new { PersonId = 6, InterestId = 4 },
        new { PersonId = 6, InterestId = 5 },

        // Greta
        new { PersonId = 7, InterestId = 1 },
        new { PersonId = 7, InterestId = 6 },

        // Hugo
        new { PersonId = 8, InterestId = 2 },

        // Ida
        new { PersonId = 9, InterestId = 3 },
        new { PersonId = 9, InterestId = 5 },

        // Johan
        new { PersonId = 10, InterestId = 1 },
        new { PersonId = 10, InterestId = 2 },
        new { PersonId = 10, InterestId = 3 },
        new { PersonId = 10, InterestId = 4 }
                                );

            modelBuilder.Entity<Website>().HasData(
            new Website { Id = 1, WebSiteURL = "https://fotboll.se", PersonId = 1, InterestId = 1 },
            new Website { Id = 2, WebSiteURL = "https://recept.nu", PersonId = 1, InterestId = 3 },

            new Website { Id = 3, WebSiteURL = "https://stackoverflow.com", PersonId = 2, InterestId = 2 },
            new Website { Id = 4, WebSiteURL = "https://steamcommunity.com", PersonId = 2, InterestId = 4 },

            new Website { Id = 5, WebSiteURL = "https://uefa.com", PersonId = 3, InterestId = 1 },
            new Website { Id = 6, WebSiteURL = "https://github.com", PersonId = 3, InterestId = 2 },

            new Website { Id = 7, WebSiteURL = "https://ign.com", PersonId = 4, InterestId = 4 },

            new Website { Id = 8, WebSiteURL = "https://tasteline.se", PersonId = 5, InterestId = 3 },
            new Website { Id = 9, WebSiteURL = "https://lonelyplanet.com", PersonId = 5, InterestId = 5 },

            new Website { Id = 10, WebSiteURL = "https://unity.com", PersonId = 6, InterestId = 2 },
            new Website { Id = 11, WebSiteURL = "https://travelguide.com", PersonId = 6, InterestId = 5 },

            new Website { Id = 12, WebSiteURL = "https://svenskfotboll.se", PersonId = 7, InterestId = 1 },

            new Website { Id = 13, WebSiteURL = "https://w3schools.com", PersonId = 8, InterestId = 2 },

            new Website { Id = 14, WebSiteURL = "https://koket.se", PersonId = 9, InterestId = 3 },

            new Website { Id = 15, WebSiteURL = "https://fifa.com", PersonId = 10, InterestId = 1 },
            new Website { Id = 16, WebSiteURL = "https://dotnet.microsoft.com", PersonId = 10, InterestId = 2 }
            );






        }
    }
}
