using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Documents.Serialization;

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

           // ListBoxNote.ItemsSource = Data.NameOfNoteForListBox;

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
    }

  /*  static class Data
    {
        public static string NameOfNoteForListBox { get; set; }
    }
  */

}


