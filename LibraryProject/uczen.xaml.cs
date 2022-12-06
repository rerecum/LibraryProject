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
    /// Logika interakcji dla klasy uczen.xaml
    /// </summary>
    public partial class uczen : Window
    {
        public uczen()
        {
            InitializeComponent();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            string myConnection = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\student\Source\Repos\LibraryProject\LibraryProject\Biblioteka.mdf; Integrated Security = True";
            SqlConnection myConn = new SqlConnection(myConnection);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder(myDataAdapter);
            myConn.Open();
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand(myConnection);
            cmd.Connection = myConn;
            cmd.CommandText = "INSERT INTO [klienci](Imie, Nazwisko, Klasa, PESEL, Id_ksiazki) values ('" + imie.Text + "','" + nazwisko.Text + "','" + klasa.Text + "','" + PESEL.Text + "', '" + id_ksiazki.Text + "')";
            cmd.ExecuteNonQuery();

            myConn.Close();
        }
    }
}
