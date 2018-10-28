using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Tools;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace DirectoryFileBrowser.Views
{
    /// <summary>
    /// Логика взаимодействия для SignInFormView.xaml
    /// </summary>
    public partial class SignInView 
    {
        #region Construcutor
        public SignInView()
        {
            InitializeComponent();
        }
        #endregion


        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("w");
            try
            {
                //WindowTree windowTree = new WindowTree();
                if (textBoxLogin.Text.Length == 0)
                {
                    MessageBox.Show("Enter an email.");
                    textBoxLogin.Focus();
                }
                else
                {
                    string login = textBoxLogin.Text;
                    string password = textBoxPassword.Password;
                    MySqlConnection con = new MySqlConnection(DBManager.DefaultConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("Select * from User where login='" + login + "'  and password='" + password + "'", con);
                    cmd.CommandType = CommandType.Text;
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        string userName = dataSet.Tables[0].Rows[0]["name"].ToString(); 
                        string userSurname = dataSet.Tables[0].Rows[0]["surname"].ToString();
                        // MessageBox.Show(username);
                        int id = (int)dataSet.Tables[0].Rows[0]["id"];
                        User currUser = new User();
                        currUser.Id = id;
                        currUser.Name = userName;
                        currUser.Surname = userSurname;
                        SessionManager.user = currUser;
                       
                        NavigationManager.Instance.Navigate(ModesEnum.Tree);
                    }
                    else
                    {
                        MessageBox.Show("Sorry! Please enter existing email/password.");
                    }
                    con.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Failed to set up connection with database");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Shutting down the application");
            Environment.Exit(1);
        }
    }
}
