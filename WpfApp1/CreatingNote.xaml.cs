using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CreatingNote.xaml
    /// </summary>
    public partial class CreatingNote : Window
    {
        public CreatingNote()
        {
            InitializeComponent();
        }

        // сохранение заметки
        private void SaveNote_Click(object sender, RoutedEventArgs e)
        {
            string NameOfNote = nameofnote.Text;
            TextRange range;
            FileStream fStream;
            range = new TextRange(mainRTB.Document.ContentStart, mainRTB.Document.ContentEnd);
            fStream = new FileStream($"Notes/{NameOfNote}.rtf", FileMode.Create);
            range.Save(fStream, System.Windows.Forms.DataFormats.Rtf);
            fStream.Close();
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
                //use either one of the below
                pd.PrintVisual(mainRTB as Visual, "printing as visual");
                pd.PrintDocument((((IDocumentPaginatorSource)mainRTB.Document).DocumentPaginator), "printing as paginator");
            }
        }
    }
}
