using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    [ServiceContract(Name = "WebService", Namespace = "http://yourdomain.com")]
    public interface IWebService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", ResponseFormat = WebMessageFormat.Json)]
        Message POST(Stream stream);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "", ResponseFormat = WebMessageFormat.Json)]
        Message GET();

    }
}
