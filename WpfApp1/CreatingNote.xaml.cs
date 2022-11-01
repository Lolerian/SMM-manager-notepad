using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using Newtonsoft.Json;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CreatingNote.xaml
    /// </summary>
    public partial class CreatingNote : Window

    {
        Dictionary<string, List<String>> dict = new Dictionary<string, List<String>>();
        public string a;

        public CreatingNote()
        {
            InitializeComponent();

            ComboBoxForChapter.ItemsSource = 
                File.ReadAllLines("D:/уроки/WpfApp1/WpfApp1/NameChapter/NameChapter.txt");
        }

        // сохранение заметки
        private void SaveNote_Click(object sender, RoutedEventArgs e)
        {
            string NameOfNote = nameofnote.Text;
            TextRange range;
            FileStream fStream;
            range = new TextRange(mainRTB.Document.ContentStart, mainRTB.Document.ContentEnd);
            fStream = new FileStream($"D:/уроки/WpfApp1/WpfApp1/Notes/{NameOfNote}.rtf", FileMode.Create);
            range.Save(fStream, System.Windows.Forms.DataFormats.Rtf);
            fStream.Close(); 

            // Data.NameOfNoteForListBox = nameofnote.Text;

        }

        // печать заметки
        private void PtintNote_Click(object sender, RoutedEventArgs e)
        {
            PrintCommand();
        }


        // создание метода для вывода печати
        private void PrintCommand()
        {
            System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
            if ((pd.ShowDialog() == true))
            {
                pd.PrintVisual(mainRTB as Visual, "printing as visual");
                pd.PrintDocument((((IDocumentPaginatorSource)mainRTB.Document).DocumentPaginator), "printing as paginator");
            }
        }

        // медод обрабатывающий выбор раздела для сохранения заметки
        private void ComboBoxForChapter_Selected(object sender, SelectionChangedEventArgs e)
        {
            a = ComboBoxForChapter.SelectedItem.ToString();
        }
    }
}
