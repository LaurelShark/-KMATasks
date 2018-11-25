using DirectoryFileBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryFileBrowser.AppServiceInterface
{
    public class DFBServiceWrapper
    {
        public static bool UserExists(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IDFBServiceContract>("Server"))
            {
                IDFBServiceContract client = myChannelFactory.CreateChannel();
                return client.UserExists(login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IDFBServiceContract>("Server"))
            {
                IDFBServiceContract client = myChannelFactory.CreateChannel();
                return client.GetUserByLogin(login);
            }
        }

        public static void AddUser(User user)
        {
            using (var myChannelFactory = new ChannelFactory<IDFBServiceContract>("Server"))
            {
                IDFBServiceContract client = myChannelFactory.CreateChannel();
                client.AddUser(user);
            }
        }

        public static void AddQuery(Query query)
        {
            using (var myChannelFactory = new ChannelFactory<IDFBServiceContract>("Server"))
            {
                IDFBServiceContract client = myChannelFactory.CreateChannel();
                client.AddWallet(query);
            }
        }

        public static void SaveQuery(Query query)
        {
            using (var myChannelFactory = new ChannelFactory<IDFBServiceContract>("Server"))
            {
                IDFBServiceContract client = myChannelFactory.CreateChannel();
                client.SaveWallet(query);
            }
        }
    }
}
