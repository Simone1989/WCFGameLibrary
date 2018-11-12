using System.Collections.Generic;
using System.ServiceModel;
using WCFGameLibrary.Model;

namespace WCFGameLibrary.Services
{
    [ServiceContract]
    public interface IWCFGameLibraryService
    {
        [OperationContract]
        List<Game> GetAllGames();

        [OperationContract]
        void Add(Game game);

        [OperationContract]
        void Delete(Game game);

        [OperationContract]
        void Save(Game game);
    }
}
