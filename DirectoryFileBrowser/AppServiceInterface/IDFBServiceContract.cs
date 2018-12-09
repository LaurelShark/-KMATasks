using DirectoryFileBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryFileBrowser.AppServiceInterface
{
    [ServiceContract]
    public interface IDFBServiceContract
    {
        [OperationContract]
        bool UserExists(string login);
        [OperationContract]
        User GetUserByLogin(string login);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddQuery(Query query);
        [OperationContract]
        void SaveQuery(Query query);
    }
}
