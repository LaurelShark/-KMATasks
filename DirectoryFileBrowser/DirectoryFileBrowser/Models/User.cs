using DirectoryFileBrowser.Tools;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DirectoryFileBrowser.Models
{
    [Serializable]
    class User
    {

        #region Fields
        private int id;
        private string name;
        private string surname;
        private string login;
        private string email;
        private string password;
        private DateTime lastLoginDate;
        private List<Query> queries;
        #endregion


        #region Properties
        public int Id
        {
            get
            {
                return id;
            }
            internal set
            {
                id = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            internal set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            internal set
            {
                surname = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            private set
            {
                email = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }
            private set
            {
                login = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            internal set
            {
                password = value;
            }
        }
        public DateTime LastLoginDate
        {
            get
            {
                return lastLoginDate;
            }
            private set
            {
                lastLoginDate = value;
            }
        }

        public List<Query> Queries
        {
            get
            {
                return queries;
            }
            private set
            {
                queries = value;
            }
        }
        #endregion

        public bool PasswordMatch(string inputPwd)
        {
            try
            {
                string hashedinputPwd = Encrypting.ConvertToMd5(inputPwd);
                return hashedinputPwd.Equals(Password);
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool CheckPassword(User userCandidate)
        {
            try
            {
                //string res = Encrypting.DecryptString(_password, PrivateKey);
                //string res2 = Encrypting.DecryptString(userCandidate._password, PrivateKey);
                return password == userCandidate.password;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
