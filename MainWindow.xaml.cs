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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2020JedlikMintaErettsegiGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string kivalasztottElem;
        public MainWindow()
        {
            InitializeComponent();

            using (StreamReader olvas = new StreamReader(@"nevekGUI.txt"))
            {
                while (!olvas.EndOfStream)
                {
                    Lista.Items.Add(olvas.ReadLine());
                }
            }
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (Lista.SelectedIndex <= 0)
                MessageBox.Show("Nem jelölt ki tanulót!");
            else
                Lista.Items.Remove(Lista.SelectedItem);
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter ki = new StreamWriter(@"nevekNEW.txt"))
                {
                    for (int i = 0; i < Lista.Items.Count; i++)
                    {
                        ki.WriteLine(Lista.Items[i]);
                        ki.Flush();
                    }

                    MessageBox.Show("Sikeres mentés!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sikertelen mentés!");
            }
        }
    }
}
