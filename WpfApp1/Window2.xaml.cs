using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //возвращение на Window1
        }

        private void ForDay_Click(object sender, RoutedEventArgs e)
        {
            ForDay PlanerForDay = new ForDay();
            PlanerForDay.Show();
        }

        private void ForYear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ForWeek_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ForMonth_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
