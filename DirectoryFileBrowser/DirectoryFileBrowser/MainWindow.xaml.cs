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
                if (textBoxLogin.Text.Length == 0)
                {
                    MessageBox.Show("Enter an email.");
                    textBoxLogin.Focus();
                }
                else
                {
                    string login = textBoxLogin.Text;
                    string password = textBoxPassword.Text;
                    MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=hw01;User ID=root;Password=;SslMode=none");
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("Select * from User where login='" + login + "'  and password='" + password + "'", con);
                    cmd.CommandType = CommandType.Text;
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        string username = dataSet.Tables[0].Rows[0]["name"].ToString() + " " + dataSet.Tables[0].Rows[0]["surname"].ToString();
                        MessageBox.Show(username);
                       // welcome.TextBlockName.Text = username;//Sending value from one form to another form.  
                       // welcome.Show();
                       //Close();
                    }
                    else
                    {
                        MessageBox.Show("Sorry! Please enter existing emailid/password.");
                    }
                    con.Close();
                }
            }
            catch (MySqlException) {
                MessageBox.Show("Failed to set up connection with database");
            }
        }
    }
}