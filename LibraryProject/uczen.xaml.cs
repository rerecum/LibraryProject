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
        /// Laczenie z baza danych. Przycisk pozwalajacy dodawac dane do tabeli klienci, w ktorej znajduja sie takie parametry jak:
        /// <paramref name="Imie"/><paramref name="Nazwisko"/><paramref name="Klasa"/><paramref name="PESEL"/><paramref name="Id_ksiazki"/>
        /// Uzytkownik musi wpisac kazde z tych danych do textbox'ow a nastepnie kliknac przycisk aby wywolac dzialnie kodu.
        /// Wszystkie dane zostaja zapisane wowczas do tabeli "klienci".
        /// </summary>
        
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
            cmd.CommandText = "INSERT INTO [klienci](Imie, Nazwisko, Klasa, PESEL, Id_ksiazki) values ('" + imie.Text + "','" + nazwisko.Text + "','" + klasa.Text + "','" + PESEL.Text + "', '" + id_ksiazki.Text + "')";
            cmd.ExecuteNonQuery();

            myConn.Close();
        }
    }
}
