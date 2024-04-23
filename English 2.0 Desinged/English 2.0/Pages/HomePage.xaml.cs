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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private List<Language> languages;
        private List<Levels> levels;
        public HomePage()
        {
            InitializeComponent();
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            EnglishEntities context = helper.GetContext();
            languages = context.Language.ToList();
            levels = context.Levels.ToList();
            LanguageComboBox.ItemsSource = languages;
            DifficultyComboBox.ItemsSource = levels;
        }

        private void StartLessonButton_Click(object sender, RoutedEventArgs e)
        {
            if (LanguageComboBox.SelectedItem != null && DifficultyComboBox.SelectedItem != null)
            {
                var selectedLanguage = (Language)(LanguageComboBox.SelectedItem);
                var selectedDifficulty = (Levels)(DifficultyComboBox.SelectedItem);

                LectureListPage lessonPage = new LectureListPage(selectedLanguage.Id_language, selectedDifficulty.Id_level);
                NavigationService.Navigate(lessonPage);
            }
            else
            {
                MessageBox.Show("Please select both language and difficulty before starting the lesson.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
