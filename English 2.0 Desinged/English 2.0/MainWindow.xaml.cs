using English_2._0.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace English_2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static MainWindow Instance { get; private set; }
        public Users CurrentUser { private set; get; }
        public class helper
        {
            public static EnglishEntities entity;
            public static EnglishEntities GetContext()
            {
                if (entity == null)
                {
                    entity = new EnglishEntities();
                }
                return entity;
            }
        }

        public void Autorization(Users user)
        {
            CurrentUser = user;    
            Home.Visibility = Visibility.Visible;
        }

        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
            MainFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            MainFrame.Navigate(new ProfilePage());
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProfilePage());
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SettingPage());
        }
    }

    
}

