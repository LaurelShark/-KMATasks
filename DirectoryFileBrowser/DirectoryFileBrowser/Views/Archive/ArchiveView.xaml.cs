using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

namespace DirectoryFileBrowser.Views.Archive
{
    /// <summary>
    /// Логика взаимодействия для ArchiveView.xaml
    /// </summary>
    public partial class ArchiveView 
    {
        int id = SessionManager.user.Id;
        string fullName = SessionManager.user.Name + " " + SessionManager.user.Surname;
        public ArchiveView()
        {
            InitializeComponent();
            textBlockFullName.Text = fullName;
            try
            {
                MySqlConnection con = new MySqlConnection(DBManager.DefaultConnectionString);
                con.Open();
                MySqlCommand userQueries = new MySqlCommand("SELECT queryId, path, date FROM query WHERE userId = " + id, con);
                userQueries.CommandType = CommandType.Text;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = userQueries;
                userQueries.ExecuteNonQuery();
                DataTable dt = new DataTable("Query");
                adapter.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                adapter.Update(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Tree);
        }
    }
}
