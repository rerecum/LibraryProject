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
            /*this.Hide();
             f2 = new znajdz();
            f2.ShowDialog();
            this.Close();*/
        }
    }
}
