using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static English_2._0.MainWindow;

namespace English_2._0.Pages
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        private int _currentIdTest;
        private double _oneProcentValue;
        private bool _isClick = true;
        private Lections _lection;
        private Test _currentAnswer;
        Random random = new Random();
        List<Test> _testList;

        public TestPage(Lections lecture)
        {
            InitializeComponent();
            EnglishEntities context = helper.GetContext();
            _lection = lecture;
            _testList = context.Test.Where(p => p.Id_lections == _lection.Id_lections).ToList();
            _oneProcentValue = 100/_testList.Count;
            CreateTest();

        }

        private void CreateTest()
        {
            var test = _testList[_currentIdTest];
            _currentAnswer = test;
            Question.Text = test.Questions;
            var quastions = _testList.Where(p => p != test).ToList();


            List<Test> ListForButtons = new List<Test>();
            ListForButtons.Add(test);

            int randomValue = random.Next(quastions.Count);
            ListForButtons.Add(quastions[randomValue]);
            quastions.Remove(quastions[randomValue]);
            randomValue = random.Next(quastions.Count);
            ListForButtons.Add(quastions[randomValue]);

            ListForButtons = FillButton(Answer1, ListForButtons);
            ListForButtons = FillButton(Answer2, ListForButtons);
            ListForButtons = FillButton(Answer3, ListForButtons);
        }

        private List<Test> FillButton(Button button, List<Test> tests)
        {
            var quastion = tests[random.Next(tests.Count)];
            button.Content = quastion.Answer;
            tests.Remove(quastion);
            button.Background = new SolidColorBrush(Color.FromArgb(60, 45, 140, 255));
            return tests;
        }

        private void AcceptAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            Answer.Visibility = Visibility.Hidden;
            _isClick = true;
            _currentIdTest++;
            if(_currentIdTest == _testList.Count)
            { 
                if (ProgressBar.Value == 100)
                {
                    MessageBox.Show("Поздравляем! Вы прошли тест!");
                    AddProgressInData();
                }      
                else
                    MessageBox.Show($"Правильных {ProgressBar.Value/ _oneProcentValue} из {_testList.Count}");
                LectureListPage lessonPage = new LectureListPage((int)_lection.Id_language,(int)_lection.Id_levels);
                NavigationService.Navigate(lessonPage);
                return;
            }
            CreateTest();
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

        private void Answer1_Click(object sender, RoutedEventArgs e)
        {
            ParseTagButton((Button)sender);
        }

        private void Answer2_Click(object sender, RoutedEventArgs e)
        {
            ParseTagButton((Button)sender);
        }

        private void Answer3_Click(object sender, RoutedEventArgs e)
        {
            ParseTagButton((Button)sender);
        }

        private void ParseTagButton(Button button)
        {
            if (!_isClick)
                return;
            _isClick = false;
            Answer.Visibility = Visibility.Visible;
            if (button.Content.ToString() == _currentAnswer.Answer)
            {
                ProgressBar.Value += _oneProcentValue;
                button.Background = Brushes.Green;
            }
            else
            {
                button.Background = Brushes.Red;
            }
        }
    }
}