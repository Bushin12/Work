using System;
using System.Collections.Generic;
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
using static English_2._0.MainWindow;

namespace English_2._0.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        List<Users> _userlIst;
        public ProfilePage()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            EnglishEntities context = helper.GetContext();
            _userlIst = context.Users.ToList();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var login = UsernameTextBox.Text;
            var password = PasswordBox.Password;
            var user = _userlIst.Where(p => p.Login == login && p.Password == password).FirstOrDefault();
            if (user != null)
            {
                MessageBox.Show("Авторизация прошла успешно");
                Instance.Autorization(user);
                HomePage homePage = new HomePage();
                NavigationService.Navigate(homePage);
            }
            else
            {
                MessageBox.Show("данные не корректны");
            }

        }

        private void GusestButton_Click(object sender, RoutedEventArgs e)
        {
            var user = _userlIst.Where(p => p.Id_Users == 2).FirstOrDefault();
            Instance.Autorization(user);
            HomePage homePage = new HomePage();
            NavigationService.Navigate(homePage);
        }

        private void Registraion_Click(object sender, RoutedEventArgs e)
        {
            Registrasion reg = new Registrasion();
            NavigationService.Navigate(reg);
        }
    }
}
