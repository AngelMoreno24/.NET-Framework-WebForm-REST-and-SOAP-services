using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ElectiveServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //service for login
        [OperationContract]
        [WebGet(UriTemplate = "AccountLogin?username={username}&password={password}")]
        string AccountLogin(string username, string password);

        //service to create account
        [OperationContract]
        [WebGet(UriTemplate = "CreateAccount?username={username}&password={password}")]
        string CreateAccount(string username, string password);
    }



}
