using System;

namespace DirectoryFileBrowser.Models
{
    public class Query
    {
        #region Fields
        private User userAuthor;
        private int queryId;
        private string path;
        private DateTime date;
        #endregion

        #region Properties
        public User UserAuthor
        {
            get { return userAuthor; }
            internal set { userAuthor = value; }
        }
        public int QueryId
        {
            get { return queryId; }
            internal set { queryId = value; }
        }
        public string Path
        {
            get { return path; }
            internal set { path = value; }
        }
        public DateTime Date
        {
            get { return date; }
            internal set { date = value; }
        }
        #endregion

        internal Query() {
            Date = DateTime.Now;
        }

        internal Query(string path, DateTime date) {
            Path = path;
            Date = date;
        }
    }
}
