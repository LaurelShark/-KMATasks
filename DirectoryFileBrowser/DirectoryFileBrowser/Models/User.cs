using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryFileBrowser.Models
{
    class User
    {
        #region Fields
        private string name;
        private string surname;
        private string login;
        private string email;
        private string password;
        private DateTime lastLoginDate;
        private List<Query> queries;
        #endregion


        #region Properties
        public string Name
        {
            get
            {
                return name;
            }
            private set
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
            private set
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
            private set
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
    }
}
