using System;
using System.Windows;
using WCFGameLibrary.Client.WCFGameLibraryServices;
using WCFGameLibrary.Model;

namespace WCFGameLibrary.Client
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadAsync();
        }

        private void list_Games_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (list_Games.SelectedIndex != -1)
            {
                save_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;
            }
        }

        private void title_textbox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (title_textbox.Text == "")
            {
                title_textbox.ToolTip = "Must enter a title.";
                save_btn.IsEnabled = false;
                addNew_btn.IsEnabled = false;
            }
            else if (title_textbox.Text != "")
            {
                save_btn.IsEnabled = true;
                addNew_btn.IsEnabled = true;
            }
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            save_btn.IsEnabled = false;
        }

        private void new_btn_Click(object sender, RoutedEventArgs e)
        {
            delete_btn.IsEnabled = false;
            save_btn.Visibility = Visibility.Hidden;
            addNew_btn.Visibility = Visibility.Visible;
            new_btn.IsEnabled = false;
            list_Games.SelectedIndex = -1;
            title_textbox.Text = "";
            description_textbox.Text = "";
        }

        private void addNew_btn_Click(object sender, RoutedEventArgs e)
        {

            Game game = new Game
            {
                Title = title_textbox.Text,
                Description = description_textbox.Text
            };

            WCFGameLibraryServiceClient proxy = new WCFGameLibraryServiceClient();
            proxy.Add(game);
            _viewModel.LoadAsync();

            addNew_btn.Visibility = Visibility.Hidden;
            save_btn.Visibility = Visibility.Visible;
            new_btn.IsEnabled = true;

            title_textbox.Text = "";
            description_textbox.Text = "";

            MessageBox.Show("Game added.", "New game");
        }
    }
}
