using DirectoryFileBrowser.AppServiceInterface;
using DirectoryFileBrowser.DBAdapter;
using DirectoryFileBrowser.Models;


namespace DirectoryFileBrowser.AppService
{
    class DFBService : IDFBServiceContract
    {
        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public void AddWallet(Query query)
        {
            EntityWrapper.AddQuery(query);
        }

        public void SaveWallet(Query query)
        {
            EntityWrapper.SaveQuery(query);
        }
    }
}
