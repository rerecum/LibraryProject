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
using System.ComponentModel;

namespace LibraryProject
{
    /// <summary>
    /// Logika interakcji dla dklasy info.xaml
    /// </summary>
        
    public struct klienteria {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Klasa { get; set; }
        public string PESEL { get; set; }
        public int? Id_ksiazki { get; set; }
    } 
    public partial class info : Window, INotifyPropertyChanged
    {
        public List<klienteria> ViewBind { get; set; } = new List<klienteria>();
        public info()
        {
            

            string myConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\student\\source\\repos\\LibraryProject\\LibraryProject\\Biblioteka.mdf;Integrated Security=True";
            SqlConnection myConn = new SqlConnection(myConnection);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder(myDataAdapter);
            myConn.Open();
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [klienci]", myConn);


            var reader = cmd.ExecuteReader();

            var klientos = new List<klienteria>();
            InitializeComponent();

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

                ViewBind.Add(klientor);
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ViewBind)));

            myConn.Close();
    }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow f2 = new MainWindow();
            f2.ShowDialog();
            this.Close();
        }
    }
}
