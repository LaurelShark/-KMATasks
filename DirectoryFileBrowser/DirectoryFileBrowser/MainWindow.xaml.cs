using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DirectoryFileBrowser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void connectToDB()
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connetionString = "Server=127.0.0.1;Database=hw01;User ID=root;Password=;SslMode=none";
                MySqlConnection cnn = new MySqlConnection(connetionString);

                cnn.Open();
                MySqlCommand isUser = cnn.CreateCommand();
                isUser.CommandText = "SELECT * from user";
                MessageBox.Show("Connection Open  !");
                MySqlDataReader reader = isUser.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        string login = (string)reader["login"];
                        string password = (string)reader["password"];
                        MessageBox.Show(login, password);
                    }
                }
                finally
                {
                    reader.Close();
                }
                cnn.Close();
            }
            catch (MySqlException ex) {
                MessageBox.Show("Failed to set up connection with database");
            }
        }
    }
}