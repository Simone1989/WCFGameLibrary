using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WCFGameLibrary.Client.WCFGameLibraryServices;
using WCFGameLibrary.Model;

namespace WCFGameLibrary.Client
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            LoadGames();
        }

        public ObservableCollection<Game> Games { get; set; }

        private async void LoadGames()
        {
            WCFGameLibraryServiceClient proxy = new WCFGameLibraryServiceClient();
            try
            {
                Games = await proxy.GetAllGamesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }
    }
}
