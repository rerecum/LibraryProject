using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy znajdz.xaml
    /// </summary>
    public partial class znajdz : Window
    {
        public znajdz()
        {
            InitializeComponent();
        }

        private void wyszukane_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>Void dla przycisku laczacy z baza danych i wysylajacy dane ktore zostana wyswietlone w textbox
        ///    (<paramref name="myConn"/>,<paramref name="cmd.Connection"/>).</summary>
        /// <param name="reader">Odczytuje i wypisuje dane z bazy.</param>
        /// <param name="line">.</param>
       
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            string myConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\student\\source\\repos\\LibraryProject\\LibraryProject\\Biblioteka.mdf;Integrated Security=True";
            SqlConnection myConn = new SqlConnection(myConnection);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder(myDataAdapter);
            myConn.Open();
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [books]", myConn);
            cmd.Connection = myConn;

            var reader = cmd.ExecuteReader();

             wyszukane.Text = "";

            /// <summary>Odczyt i wypis danych z tabeli.</summary>
            /// <returns>Oddaje wartosci zgodne z danymi w tabeli.</returns>

            while (reader.Read())
             {
                 string line = $"{reader["Tytul"]} {reader["Autor"]} {reader["Gatunek"]} {reader["Id"]}";
                if (
                    reader["Tytul"].ToString().Contains(tytul_box.Text)&&
                    reader["Autor"].ToString().Contains(autor_box.Text)&&
                    reader["Gatunek"].ToString().Contains(gatunek_box.Text))
                    wyszukane.AppendText(line + "\r\n");
             }
            

        myConn.Close();

        }

        private void tytul_box_TextChanged(object sender, TextChangedEventArgs e)
        {

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
    }
}
