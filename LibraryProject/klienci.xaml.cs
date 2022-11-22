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
    /// Logika interakcji dla klasy info.xaml
    /// </summary>
        
    public struct klienteria { public string Imie; public string Nazwisko; public string Klasa; public string PESEL; public int? Id_ksiazki; } 
    public partial class info : Window
    {
        public info()
        {
            InitializeComponent();

            string myConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\student\\source\\repos\\LibraryProject\\LibraryProject\\Biblioteka.mdf;Integrated Security=True";
            SqlConnection myConn = new SqlConnection(myConnection);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder(myDataAdapter);
            myConn.Open();
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [klienci]", myConn);
            cmd.Connection = myConn;

            var reader = cmd.ExecuteReader();

            var klientos = new List<klienteria>();

            Grid.Columns.Add(new DataGridTextColumn
            {
                Header = "Imie",
                Binding = new Binding("Imie")
            });

            Grid.Columns.Add(new DataGridTextColumn
            {
                Header = "Nazwisko",
                Binding = new Binding("Nazwisko")
            });

            Grid.Columns.Add(new DataGridTextColumn
            {
                Header = "Klasa",
                Binding = new Binding("Klasa")
            });

            Grid.Columns.Add(new DataGridTextColumn
            {
                Header = "PESEL",
                Binding = new Binding("PESEL")
            });

            Grid.Columns.Add(new DataGridTextColumn
            {
                Header = "Id_ksiazki",
                Binding = new Binding("Id_ksiazki")
            });

            while (reader.Read())
            {
                var klientor = new klienteria
                {
                    Imie = reader.GetString(1), 
                    Nazwisko = reader.GetString(2),
                    Klasa = reader.GetString(3),
                    PESEL = reader.GetString(4),
                    Id_ksiazki = (int?)reader.GetValue(5)
                };

                Grid.Items.Add(klientor);
            }
            myConn.Close();
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow f2 = new MainWindow();
            f2.ShowDialog();
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
