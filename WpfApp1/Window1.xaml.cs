using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Documents;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Media;
using System.Windows.Documents.Serialization;
using System;
using System.Collections.Generic;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ObservableCollection<string> chapters;
        public string chaptertext;

        public Window1()
        {
            InitializeComponent();

            //Путь к файлу (переделать)
            string path = "D:/уроки/WpfApp1/WpfApp1/NameChapter/NameChapter.txt";

            //Создание привязывающей коллекции и добавление в лист
            chapters = new ObservableCollection<string>();

            ListBox.ItemsSource = chapters;


            //Вывод разделов из файла
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    chapters.Add(line);
                }
            }

            //Открытие всех файлов в указанной папке
            string pathExample = "D:/уроки/WpfApp1/WpfApp1/Notes";
            DirectoryInfo dir = new DirectoryInfo(pathExample);

            FileInfo[] files = dir.GetFiles("*.rtf");
            foreach (FileInfo file in files)
            {
                ListBoxNote.Items.Add(file.ToString());
            }
        }

        private void TemplatesForPlans_Click(object sender, RoutedEventArgs e)
        {
            //Создание окна
            Window2 window2 = new Window2();
            window2.Show();
        }

        private void EditNote_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void CreateChapter_Click(object sender, RoutedEventArgs e) 
        { 
        
            // Добавление раздела в лист 
            chaptertext = TextBoxChapter.Text;
            chapters.Add(chaptertext);

            // Добавление разделов в файл
            string path = "D:/уроки/WpfApp1/WpfApp1/NameChapter/NameChapter.txt";
            using (StreamWriter stream = new StreamWriter(path, true))
            {
                await stream.WriteLineAsync(chaptertext);
            }
        }

        private void CreateNote_Click(object sender, RoutedEventArgs e)
        {
            // Создание формы для заметки
            CreatingNote creatingNote = new CreatingNote();
            creatingNote.Show();
        }

        private void ListBoxNote_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Получение текста выбранного элемента
            string SelectedNameOfNote = ((string)ListBoxNote.SelectedItem);

            // Удаление последних 4-х символов из стоки ".rtf"
            int x1 = SelectedNameOfNote.Length - 4;
            SelectedNameOfNote = SelectedNameOfNote.Remove(x1);

            LoadXamlPackage($"D:/уроки/WpfApp1/WpfApp1/Notes/{SelectedNameOfNote}.rtf");
        }

        void LoadXamlPackage(string _fileName)
        {
            TextRange range;
            FileStream fStream;
            if (File.Exists(_fileName))
            {
                range = new TextRange(RTB_ForShowNotes.Document.ContentStart, RTB_ForShowNotes.Document.ContentEnd);
                fStream = new FileStream(_fileName, FileMode.OpenOrCreate);
                range.Load(fStream, System.Windows.DataFormats.Rtf);
                fStream.Close();
            }
        }

        /*private void trw_Products_Expanded(object sender, RoutedEventArgs e)
        {
             TreeViewItem item = (TreeViewItem)e.OriginalSource;
            item.Items.Clear();
            DirectoryInfo dir;
            if (item.Tag is DriveInfo)
            {
                DriveInfo drive = (DriveInfo)item.Tag;
                dir = drive.RootDirectory;
            }
            else dir = (DirectoryInfo)item.Tag;
            try
            {
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Tag = subDir;
                    newItem.Header = subDir.ToString();
                    newItem.Items.Add("*");
                    item.Items.Add(newItem);
                }
            }
            catch
            { }
        }
        */
    }

}


