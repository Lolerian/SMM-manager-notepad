using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Text;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ObservableCollection<string> chapters;
        public string chaptertext = TextBoxChapter.Text;

        public Window1()
        {
            InitializeComponent();
            chapters = new ObservableCollection<string>();
            ListBox.ItemsSource = chapters;

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

        private void CreateChapter_Click(object sender, RoutedEventArgs e)
        {
            chapters.Add(chaptertext);
        }



        private void CreateNote_Click(object sender, RoutedEventArgs e)
        {
            CreatingNote creatingNote = new CreatingNote();
            creatingNote.Show();
        }

        private void SaveChapter_Click(object sender, RoutedEventArgs e)
        {
            string path = "D:/уроки/WpfApp1/WpfApp1/NameChapter/NameChapter.txt";
            File.WriteAllText(path, chaptertext);
        }
    }

}


