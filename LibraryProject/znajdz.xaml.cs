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

           /* var reader = cmd.ExecuteReader();

            wyszukane.Text = "";

            while (reader.Read())
            {
                string line = $"{reader["Tytul"]} {reader["Autor"]} {reader["Gatunek"]}";
                if (tytul_box.Text == "Adam")
                    {

                    }
                }
            }

            myConn.Close();

        }*/

        private void tytul_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
