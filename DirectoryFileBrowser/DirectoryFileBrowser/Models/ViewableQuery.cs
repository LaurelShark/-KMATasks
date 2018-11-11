using System;

namespace DirectoryFileBrowser.Models
{
    public class ViewableQuery
    {
        #region Fields
        private string path;
        private DateTime date;
        #endregion

        #region Properties
        public string Path
        {
            get { return path; }
            private set { path = value; }
        }
        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }
        #endregion

        internal ViewableQuery(string path, DateTime date)
        {
            Path = path;
            Date = date;
        }
    }
}
