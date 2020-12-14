using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HelloWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract] 
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SayHello/")] 
        string SayHello();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetData/{value}")] 
        string GetData(string value);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetModelObject/{id}/")]
        HelloObject GetModelObj(string id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetAllUsers/")]
        UserDTO GetAllUsers();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUsersByName/{name}")]
        UserDTO GetUsersByName(string name);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUser/{ID}")]
        UserDTO GetUsersByID(string ID);
    }
}
