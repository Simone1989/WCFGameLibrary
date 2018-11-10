using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WCFGameLibrary.Client.WCFGameLibraryServices;
using WCFGameLibrary.Model;

namespace WCFGameLibrary.Client
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Game _selectedGame;

        public MainWindowViewModel()
        {
            Games = new ObservableCollection<Game>();

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            throw new NotImplementedException();
        }

        private void OnSaveExecute()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Game> Games { get; set; }

        public async void LoadAsync()
        {
            WCFGameLibraryServiceClient proxy = new WCFGameLibraryServiceClient();
            try
            {
                var getGames = await proxy.GetAllGamesAsync();
                Games.Clear();
                foreach (var game in getGames)
                {
                    Games.Add(game);
                }
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

        public Game SelectedGame
        {
            get { return _selectedGame; }
            set
            {
                _selectedGame = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
    }
}
