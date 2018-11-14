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

            SaveCommand = new DelegateCommand(OnSaveExecute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute);
        }

        private void OnDeleteExecute()
        {
            WCFGameLibraryServiceClient proxy = new WCFGameLibraryServiceClient();
            proxy.Delete(_selectedGame);
            MessageBox.Show("Game deleted.", "Delete");
            LoadAsync();
        }

        private void OnSaveExecute()
        {
            SaveGameAsync();
            MessageBox.Show("Data is saved.", "Saved");
            LoadAsync();
        }

        public ObservableCollection<Game> Games { get; set; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public async void SaveGameAsync()
        {
            WCFGameLibraryServiceClient proxy = new WCFGameLibraryServiceClient();
            await proxy.SaveAsync(_selectedGame);
        }

        public async void LoadAsync()
        {
            WCFGameLibraryServiceClient proxy = new WCFGameLibraryServiceClient();
            try
            {
                var allGames = await proxy.GetAllGamesAsync();
                Games.Clear();
                foreach (var game in allGames)
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
    }
}
