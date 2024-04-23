using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для HardTest.xaml
    /// </summary>
    public partial class HardTest : Page
    {
        private List<Test> _tests;
        private Lections _lection;
        private int _currentTest = 0;
        private string _currentSentense;
        private int _oneProcentValue;

        public HardTest(Lections lecture)
        {
            _lection = lecture;
            InitializeComponent();
            var context = helper.GetContext();
            _tests = context.Test.Where(p => p.Id_lections == _lection.Id_lections).ToList();
            _oneProcentValue = 100 / _tests.Count;
            CreateListWord();
        }

        private void UpdateText()
        {
            Answer.Text = _currentSentense;
        }

        private void CreateListWord()
        {
            RussianText.Text = _tests[_currentTest].Questions.ToString();
            var words = _tests[_currentTest].Answer.Split(' ').ToList();
            words = ListRandom<string>(words);
            LabelStackPanel.Children.Clear();
            foreach (var word in words)
            {
                Label label = new Label();
                label.Content = word;
                label.Foreground = Brushes.White;
                label.MouseDown += ClickToLabel;
                LabelStackPanel.Children.Add(label);
            }
        }

        private List<T> ListRandom<T>(List<T> list)
        {
            Random random = new Random();
            var timeList = list.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                int randomValue = random.Next(0, timeList.Count);
                list[i] = timeList[randomValue];
                timeList.Remove(timeList[randomValue]);
            }

            return list;
        }

        private void ClickToLabel(object sender, RoutedEventArgs e)
        {
            var text = sender as Label;
            _currentSentense += text.Content+" ";
            LabelStackPanel.Children.Remove(text);
            UpdateText();
        }

        private void CheckAnswer_Click(object sender, RoutedEventArgs e)
        {
            var text = _currentSentense.Trim();
            if (_tests[_currentTest].Answer == text)
            {
                ProgressBar.Value += _oneProcentValue;                           
            }
            else
            {
                MessageBox.Show("Неправильный ответ");
            }
            if (_currentTest == _tests.Count -1)
            {
                FinishTest();
            }
            _currentTest++;           
            _currentTest = Clamp(_currentTest, _tests.Count-1);
            Reset();
        }

        private void FinishTest()
        {
            if (ProgressBar.Value == 100)
            {
                MessageBox.Show("Поздравляем! Вы прошли тест!");
                AddProgressInData();
            }
            else 
                MessageBox.Show($"Правильных {ProgressBar.Value / _oneProcentValue} из {_tests.Count}");
            LectureListPage lessonPage = new LectureListPage((int)_lection.Id_language, (int)_lection.Id_levels);
             NavigationService.Navigate(lessonPage);
        }

        public void AddProgressInData()
        {
            Progress newProgress = new Progress();
            newProgress.Id_lecture = _lection.Id_lections;
            newProgress.Id_user = Instance.CurrentUser.Id_Users;
            var context = helper.GetContext();
            if (context.Progress.Where(p => p.Id_lecture == newProgress.Id_lecture && p.Id_user == newProgress.Id_user).FirstOrDefault() == null)
            {
                context.Progress.Add(newProgress);
                context.SaveChanges();
            }
        }

        private int Clamp(int value, int max)
        {
            if(value > max)
                value = max;
            else if(value < 0)
                value = 0;
            return value;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            _currentSentense = "";
            CreateListWord();
            UpdateText();
        }
    }
}
