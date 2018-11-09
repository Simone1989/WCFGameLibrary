using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using WCFGameLibrary.Data;
using WCFGameLibrary.Model;

namespace WCFGameLibrary.Services
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerCall)]
    public class WCFGameLibraryService : IWCFGameLibraryService, IDisposable
    {
        private readonly WCFGameLibraryDbContext _context = new WCFGameLibraryDbContext();

        public void Add(Game game)
        {
            throw new NotImplementedException();
        }

        public void Delete(Game game)
        {
            throw new NotImplementedException();
        }
        
        public List<Game> GetAllGames()
        {
            return _context.Games.ToList();
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
