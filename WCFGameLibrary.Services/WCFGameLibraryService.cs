using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using WCFGameLibrary.Data;
using WCFGameLibrary.Model;

namespace WCFGameLibrary.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WCFGameLibraryService : IWCFGameLibraryService
    {
        private readonly WCFGameLibraryDbContext _context = new WCFGameLibraryDbContext();

        public void Add(Game game)
        {
            using (var context = _context)
            {
                context.Games.Attach(game);
                context.Entry(game).State = EntityState.Added;
                context.Games.Add(game);
                context.SaveChanges();
            }
        }

        public void Delete(Game game)
        {
            using (var context = _context)
            {
                context.Games.Attach(game);
                context.Entry(game).State = EntityState.Deleted;
                context.Games.Remove(game);
                context.SaveChanges();
            }
        }

        public List<Game> GetAllGames()
        {
            using (var context = _context)
            {
                return context.Games.ToList();
            }
        }

        public async void Save(Game game)
        {
            using (var context = _context)
            {
                context.Games.Attach(game);
                context.Entry(game).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
