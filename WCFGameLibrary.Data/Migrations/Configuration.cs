namespace WCFGameLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WCFGameLibrary.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<WCFGameLibrary.Data.WCFGameLibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WCFGameLibrary.Data.WCFGameLibraryDbContext context)
        {
            context.Games.AddOrUpdate(
                g => g.Title,
                new Game { Title = "Mass Effect", Description = "A game about saving the galaxy" },
                new Game { Title = "Dreamfall Chapters", Description = "A game about magic and science and travel" },
                new Game { Title = "World of Warcraft", Description = "A game about humans and orcs" },
                new Game { Title = "Final Fatansy IX", Description = "A game about getting the girl" },
                new Game { Title = "Last of Us", Description = "A game about fungi" },
                new Game { Title = "Borderlands", Description = "A game about guns and guns and guns" }
                );
        }
    }
}
