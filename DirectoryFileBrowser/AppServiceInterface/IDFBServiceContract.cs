using DirectoryFileBrowser.Models;
using System.ServiceModel;

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
