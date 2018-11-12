using System;
using System.Windows;

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
            if(list_Games.SelectedIndex != -1)
            {
                save_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;
            }
        }

        private void title_textbox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(title_textbox.Text == "")
            {
                title_textbox.ToolTip = "Must enter a title.";
                save_btn.IsEnabled = false;
            }
            else if(title_textbox.Text != "")
            {
                save_btn.IsEnabled = true;
            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            save_btn.IsEnabled = false;
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
