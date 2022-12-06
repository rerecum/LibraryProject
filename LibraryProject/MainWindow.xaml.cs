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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnfind_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            znajdz f2 = new znajdz();
            f2.ShowDialog();
            this.Close();
        }

        private void btninfo_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();
            info f2 = new info();
            f2.ShowDialog();
            this.Close();
        }

        private void btncontact_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            kontakt f2 = new kontakt();
            f2.ShowDialog();
            this.Close();
        }

        private void btn_klienteria_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            uczen f2 = new uczen();
            f2.ShowDialog();
            this.Close();
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            delete f2 = new delete();
            f2.ShowDialog();
            this.Close();
        }

        private void btndeletest_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            delete f2 = new delete();
            f2.ShowDialog();
            this.Close();
        }
    }
}
