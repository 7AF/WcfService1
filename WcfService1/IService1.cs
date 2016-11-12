using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "Login/{username}/{password}", ResponseFormat = WebMessageFormat.Json)]
        bool Login(string username, string password);

        [OperationContract]
        [WebGet(UriTemplate = "Messages", ResponseFormat = WebMessageFormat.Json)]
        List<MessageEntity> GetMessages();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddMessage/{username}/{text}", ResponseFormat = WebMessageFormat.Json)]
        void AddMessage(string username, string text);

        [OperationContract]
        [WebGet(UriTemplate = "Register/{username}/{name}/{surname}/{password}", ResponseFormat = WebMessageFormat.Json)]
        bool Register(string username, string name, string surname, string password);

    }

    [DataContract]
    public class MessageEntity
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string Time { get; set; }
    }
}