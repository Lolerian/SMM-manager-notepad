using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //Добавление документа XML
        private XDocument _theXML;
        public XDocument TheXML
        {
            get => _theXML;
            set => _theXML = value;
        }

        public Window1()
        {
            InitializeComponent();

            //Загрузка документа XML
            DataContext = this;
            TheXML = XDocument.Load("D:/уроки/WpfApp1/WpfApp1/Ps/XMLTree.xml");
            TreeView.DataContext = TheXML;
            TreeView.UpdateLayout();
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

        }

        private void CreateNote_Click(object sender, RoutedEventArgs e)
        {
            CreatingNote creatingNote = new CreatingNote();
            creatingNote.Show();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }

}


