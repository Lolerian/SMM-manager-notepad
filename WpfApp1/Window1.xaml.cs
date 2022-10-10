using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            MenuItemss root = new MenuItemss() { Name = "Menu" };
            MenuItemss childItem1 = new MenuItemss() { Name = "1" };
            childItem1.Items.Add(new MenuItemss() { Name = "1.1" });
            childItem1.Items.Add(new MenuItemss() { Name = "1.2" });
            root.Items.Add(childItem1);
            root.Items.Add(new MenuItemss() { Name = "2" });
            //TreeViewss.Items.Add(root);

        }

        // создание раздела
        private void CreateChapter_Click(object sender, RoutedEventArgs e)
        {
            CreateCharapter createCharapter = new CreateCharapter();
            createCharapter.Show();
        }

        // создание заметки
        private void CreateNote_Click(object sender, RoutedEventArgs e)
        {
            CreatingNote creatingNote = new CreatingNote();
            creatingNote.Show();
        }

        private void EditNote_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TemplatesForPlans_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }

        public class MenuItemss
        {
            public MenuItemss()
            {
                this.Items = new ObservableCollection<MenuItemss>();
            }

            public string Name { get; set; }
            public ObservableCollection<MenuItemss> Items { get; set; }
        }
    }
}

