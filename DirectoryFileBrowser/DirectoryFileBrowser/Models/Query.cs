using System;

namespace DirectoryFileBrowser.Models
{
    public class Query
    {
        #region Fields
        private int userId;
        private int queryId;
        private string path;
        private string date;
        #endregion

        #region Properties
        public int UserId {
            get { return userId; }
            private set { userId = value; }
        }
        public int QueryId
        {
            get { return queryId; }
            private set { queryId = value; }
        }
        public string Path
        {
            get { return path; }
            private set { path = value; }
        }
        public string Date
        {
            get { return date; }
            private set { date = value; }
        }
        #endregion

        internal Query(String path, DateTime date) {
            Path = path;
            Date = date.ToString();
        }
    }
}
