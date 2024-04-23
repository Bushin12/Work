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
    /// Логика взаимодействия для Registrasion.xaml
    /// </summary>
    public partial class Registrasion : Page
    {
        List<Users> _userlIst;
        public Registrasion()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            EnglishEntities context = helper.GetContext();
            _userlIst = context.Users.ToList();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.Login = UsernameTextBox.Text;
            users.Password= PasswordBox.Text;
            users.Name = Name.Text;
            users.Surname = Surname.Text;
            var context = helper.GetContext();
            if (users.Login == "" || users.Login == "" || users.Name == "" || users.Surname == "")
            {
                MessageBox.Show("Заполните все поля");
                
            }
            else if (context.Users.Where(p => p.Login == users.Login).FirstOrDefault() == null)
            {
                context.Users.Add(users);
                context.SaveChanges();
                MessageBox.Show("Регистрция прошла успешно!");
            }
            else
            MessageBox.Show("Пользватель с таким логином существует");

        }
    }
}
