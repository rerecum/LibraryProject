﻿using System;
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
    /// Logika interakcji dla klasy delete.xaml
    /// </summary>
    public partial class delete : Window
    {
        public delete()
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

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            string myConnection = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\student\Source\Repos\LibraryProject\LibraryProject\Biblioteka.mdf; Integrated Security = True";
            SqlConnection myConn = new SqlConnection(myConnection);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder(myDataAdapter);
            myConn.Open();
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand(myConnection);
            cmd.Connection = myConn;
            cmd.CommandText = "DELETE FROM [books] WHERE Tytul = '" + tytul.Text + "' AND AUTOR = '" + autor.Text + "' AND GATUNEK = '" + gatunek.Text + "'";
            cmd.ExecuteNonQuery();

            myConn.Close();
        }
    }
}