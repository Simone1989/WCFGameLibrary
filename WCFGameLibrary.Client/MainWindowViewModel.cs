﻿using System;
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
            Games = new ObservableCollection<Game>();
            LoadGames();
        }

        public ObservableCollection<Game> Games { get; set; }

        private async void LoadGames()
        {
            WCFGameLibraryServiceClient proxy = new WCFGameLibraryServiceClient();
            try
            {
                var newGames = await proxy.GetAllGamesAsync();
                foreach (var game in newGames)
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
    }
}
