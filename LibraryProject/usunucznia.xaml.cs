using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace LibraryProject
{
    /// <summary>
    /// Logika interakcji dla klasy usunucznia.xaml
    /// </summary>
    public partial class usunucznia : Window
    {
        public usunucznia()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow f2 = new MainWindow();
            f2.ShowDialog();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string myConnection = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\student\Source\Repos\LibraryProject\LibraryProject\Biblioteka.mdf; Integrated Security = True";
            SqlConnection myConn = new SqlConnection(myConnection);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder(myDataAdapter);
            myConn.Open();
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand(myConnection);
            cmd.Connection = myConn;
            try
            {
                cmd.CommandText = "DELETE FROM [klienci] WHERE Imie = '" + imie.Text + "' AND Nazwisko = '" + nazwisko.Text + "' AND Klasa = '" + klasa.Text + "' AND PESEL = '" + PESEL.Text + "' AND Id_ksiazki = '" + id_ksiazki.Text + "'";
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                MessageBox.Show("Nie mozna usunac ucznia");
            }
            myConn.Close();
        }
    }
}
