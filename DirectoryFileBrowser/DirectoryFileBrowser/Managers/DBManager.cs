using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DirectoryFileBrowser.Managers
{
    class DBManager
    {
        private static List<User> Users = new List<User>();

        static DBManager()
        {
            Users = SerializationManager.Deserialize<List<User>>(FileFolderHelper.StorageFilePath) ?? new List<User>();
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = Users.FirstOrDefault(u => u.Id == userCandidate.Id);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static bool userExists(string login)
        {
            return Users.Any(u => u.Login == login);
        }

        private static readonly string defaultConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dfb.mdf;Integrated Security=True";

        internal static string DefaultConnectionString { get { return defaultConnectionString; } }

        internal static void AddUser(User user)
        {
            Users.Add(user);
            SaveChanges();
        }

        private static void SaveChanges()
        {
            SerializationManager.Serialize(Users, FileFolderHelper.StorageFilePath);
        }

        public static User GetUserByLogin(string login)
        {
            SqlConnection con = new SqlConnection(DBManager.DefaultConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("Select * from Users where login='{0}'", login), con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            con.Close();
            User resultUser = null;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                string userName = dataSet.Tables[0].Rows[0]["name"].ToString();
                string userSurname = dataSet.Tables[0].Rows[0]["surname"].ToString();
                string password = dataSet.Tables[0].Rows[0]["password"].ToString();
                int id = (int)dataSet.Tables[0].Rows[0]["id"];
                User user = new User();
                user.Id = id;
                user.Name = userName;
                user.Surname = userSurname;
                user.Password = password;
                resultUser = user;
            }
            return resultUser;
        }

        public static void UpdateLoggedInDateToCurrent(User user) {
            SqlConnection con = new SqlConnection(DBManager.DefaultConnectionString);
            con.Open();
            DateTime dateTime = DateTime.Now;
            string date = dateTime.ToString("yyyy-MM-dd H:mm:ss");
            SqlCommand ins = new SqlCommand(
                String.Format("UPDATE Users SET lastLoginDate = '{0}' WHERE id = '{1}'", date, user.Id), con);
            ins.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = ins;
            ins.ExecuteNonQuery();
            con.Close();
        }

        public static void WriteQueryForUser(User user, string dirPath) {
            SqlConnection con = new SqlConnection(DBManager.DefaultConnectionString);
            con.Open();
            DateTime dateTime = DateTime.Now;
            string date = dateTime.ToString("yyyy-MM-dd H:mm:ss");
            SqlCommand ins = new SqlCommand("INSERT INTO queries(userId, path, date) VALUES (" + user.Id + ",'" + dirPath + "', '" + date + "')", con);
            ins.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = ins;
            ins.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable GetQueriesForUser(User user) {
            SqlConnection con = new SqlConnection(DBManager.DefaultConnectionString);
            con.Open();
            SqlCommand userQueries = new SqlCommand("SELECT id, path, date FROM queries WHERE userId = " + user.Id, con);
            userQueries.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = userQueries;
            userQueries.ExecuteNonQuery();
            DataTable dt = new DataTable("Queries");
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
