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

using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ForDay.xaml
    /// </summary>
    public partial class ForDay : Window
    {
        public ForDay()
        {
            InitializeComponent();
        }

        private void Monday_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //очистка RichTextBox
        private void ClearRichTextBox_Click(object sender, RoutedEventArgs e)
        {
            RichTextBoxNote.Document.Blocks.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as System.Drawing.Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save(@"D:\уроки\printscreen.jpg", ImageFormat.Jpeg);
        }
    }
}
