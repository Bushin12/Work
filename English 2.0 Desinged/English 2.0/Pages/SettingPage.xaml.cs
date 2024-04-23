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

namespace English_2._0.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingPage.xaml
    /// </summary>
    public partial class SettingPage : Page
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            // Применить выбранные настройки
            ApplySettings();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Просто закрыть страницу настроек без применения изменений
            NavigationService?.GoBack();
        }

        private void ApplySettings()
        {
            // Ваш код для применения выбранных настроек
            string selectedLanguage = ((ComboBoxItem)LanguageComboBox.SelectedItem)?.Content?.ToString();
            MessageBox.Show($"Выбран язык: {selectedLanguage}");

            // Закрыть страницу настроек
            NavigationService?.GoBack();
        }
    }
}
 
