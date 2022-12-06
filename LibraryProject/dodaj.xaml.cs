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
using System.Windows.Markup;

namespace LibraryProject
{
    /// <summary>
    /// Logika interakcji dla klasy kontakt.xaml
    /// </summary>
    public partial class kontakt : Window
    {
        public kontakt()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obsluga przyciskow do przechodzenia na inne zakladki w MainWindow.xaml
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow f2 = new MainWindow();
            f2.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Laczenie z baza danych. Przycisk powoduje dodanie do tabeli w bazie danych, danych wpisanych przez uzytkownika do textbox.
        /// <paramref name="dodaj_Click"/> <paramref name="INSERT INTO"/>
        /// Dane te naleza do cech podmiotow w tabeli "books". Przypisywane są one do swoich kolumn a nastepnie zapisywane.
        /// </summary>
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
            cmd.CommandText = "INSERT INTO [books](Tytul, Autor, Gatunek) values ('" + tytul.Text + "','" + autor.Text + "','" + gatunek.Text + "')";
            cmd.ExecuteNonQuery();

            myConn.Close();
        }
    }
}
