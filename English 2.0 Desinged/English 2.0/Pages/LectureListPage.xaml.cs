
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using static English_2._0.MainWindow;
using System.Text;
using System;
using Newtonsoft.Json;


namespace English_2._0.Pages
{
    /// <summary>
    /// Логика взаимодействия для LecturePage.xaml
    /// </summary>
    public partial class LectureListPage : Page
    {
        private int _language, _levels;
        private List<Progress> status;
        private EnglishEntities context;
        private static string fileName = "1.pdf";


        public LectureListPage(int language, int levels)
        {
            InitializeComponent();
            context = helper.GetContext();
            int idUser = Instance.CurrentUser.Id_Users;
            _language = language;
            _levels = levels;
            status = context.Progress.Where(p => p.Id_user == idUser).ToList();
            GetLecture();
            
        }

        // Метод для получения списка лекций
        private void GetLecture()
        {
            var lections = context.Lections.Where(p => p.Id_language == _language && p.Id_levels == _levels).ToArray();
            for (int i = 0; i < lections.Length; i++)
            {
                var ProgressLecture = status.Where(p => p.Id_lecture == lections[i].Id_lections).FirstOrDefault();
                if (ProgressLecture != null)
                {
                    lections[i].Status = true;
                }
            }
            lectureDataGrid.ItemsSource = lections;
            if (lections.Where(p => p.Status == false).Count() == 0)
            {
                Certificate.Visibility = Visibility.Visible;
            }
        }

        private void lectureDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Certificate_Click(object sender, RoutedEventArgs e)
        {
            Сertificate();
        }

        private void lectureDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Lections selectedLecture = (Lections)lectureDataGrid.SelectedItem;
            if (selectedLecture != null)
            {
                LectionPage newPage = new LectionPage(selectedLecture);
                newPage.DataContext = selectedLecture;
                NavigationService.Navigate(newPage);
            }
        }

        private void Сertificate()
        {
            string relativePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            // Путь к исходному файлу PDF и новому файлу PDF
            string levels = context.Levels.Where(p => p.Id_level == _levels).FirstOrDefault().Title;
            string language  = context.Language.Where(p => p.Id_language == _language).FirstOrDefault().TitleEnglish;
            string replaceText =  $"Congratulations, {Instance.CurrentUser.Name} {Instance.CurrentUser.Surname} You passing all lectures {language} language on {levels} levels";

            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Append));
            doc.Open();
            Paragraph par = new Paragraph(replaceText);
            doc.Add(par);
            doc.Close();
            writer.Close();
         
        }
    }
}


