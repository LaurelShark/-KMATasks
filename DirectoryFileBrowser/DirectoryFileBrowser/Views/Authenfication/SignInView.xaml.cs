using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Tools;
using DirectoryFileBrowser.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

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
            var signInViewModel = new SignInViewModel();
            DataContext = signInViewModel;
        }
        #endregion

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
                ((SignInViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("w");
            /*  try
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
                      string passwordHashedWithMd5 = Encrypting.ConvertToMd5(textBoxPassword.Password);
                      MySqlConnection con = new MySqlConnection(DBManager.DefaultConnectionString);
                      con.Open();
                      MySqlCommand cmd = new MySqlCommand("Select * from User where login='" + login + "'  and password='" + passwordHashedWithMd5 + "'", con);
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

                          DateTime dateTime = DateTime.Now;
                          string date = dateTime.ToString("yyyy-MM-dd H:mm:ss");
                          MySqlCommand ins = new MySqlCommand(
                              String.Format("UPDATE user SET lastLoginDate = '{0}' WHERE id = '{1}'", date, id), con);
                          ins.CommandType = CommandType.Text;
                          MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                          adapter2.InsertCommand = ins;
                          ins.ExecuteNonQuery();

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
                  MessageBox.Show("Error. Db interaction failed. Probably, failed to set up connection");
              }
          }
          
            private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Shutting down the application");
            Environment.Exit(1);
        }
        */
        }
    }
    }
