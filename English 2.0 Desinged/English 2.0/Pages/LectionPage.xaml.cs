using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для LectionPage.xaml
    /// </summary>
    public partial class LectionPage : Page
    {
        private Lections _currentLection;
        private int _lectureId;
        private List<Dictonary> _wordsList;
        private int _currentWordIndex = 0;



        public LectionPage(Lections lections)
        {
            InitializeComponent();
            _currentLection = lections;
            _lectureId = lections.Id_lections; // Установка идентификатора лекции
            LoadWordData(); // Загрузка данных слов из словаря
            UpdateData();
        }

        private void LoadWordData()
        {
            EnglishEntities context = helper.GetContext();
            _wordsList = context.Dictonary.Where(p => p.Id_lections == _lectureId).ToList();
        }

        public void UpdateData()
        {
            var currentWord = _wordsList[_currentWordIndex];
            Languge.Text = currentWord.Text;
            Translation.Text = currentWord.Translate;

            if(currentWord.Image != null)
            {
                string imagePath = AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.Length - 10) + $"\\Image\\{currentWord.Image}";
                ImageWord.Visibility = Visibility.Visible;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath);
                bitmap.EndInit();

                ImageWord.Source = bitmap;
            }
            else
            {
                ImageWord.Visibility = Visibility.Hidden;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход на страницу со списком лекций
            NavigationService.Navigate(new LectureListPage((int)_currentLection.Id_language, (int)_currentLection.Id_levels));
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            _currentWordIndex--;
            ClampIndexWord();
            UpdateData();
        }

        private void button_next_Click(object sender, RoutedEventArgs e)
        {
            _currentWordIndex++;
            ClampIndexWord();
            UpdateData();
        }

        private void ClampIndexWord()
        {
            if (_currentWordIndex < 0)
                _currentWordIndex = 0;
            else if(_currentWordIndex > _wordsList.Count-1)
                _currentWordIndex = _wordsList.Count - 1;

        }

        private void GoToTestButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentLection.Id_levels != 3)
            {
                TestPage testPage = new TestPage(_currentLection);
                NavigationService.Navigate(testPage);
            }
            else
            {
                HardTest hardTest = new HardTest(_currentLection);
                NavigationService.Navigate(hardTest);
            }
                
        }
    }
}
