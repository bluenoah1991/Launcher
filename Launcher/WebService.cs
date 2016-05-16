using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WebService : IWebService
    {
        public const int TIMEOUT = 60000;

        public Message POST(Stream stream)
        {
            string contentType = WebOperationContext.Current.IncomingRequest.Headers["Content-Type"];
            NameValueCollection queryParameters = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;

            StreamReader reader = new StreamReader(stream);
            string body = reader.ReadToEnd();

            WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Type", "text/plain");

            return StreamMessageHelper.CreateMessage(MessageVersion.None, string.Empty, "text/plain", delegate (Stream output)
            {
                TextWriter writer = new StreamWriter(output);
                writer.Write("Hello World!");
                writer.Flush();
                writer.Close();
            });
        }

        public Message GET()
        {
            string contentType = WebOperationContext.Current.IncomingRequest.Headers["User-Agent"];
            NameValueCollection queryParameters = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;

            WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Type", "text/plain");

            return StreamMessageHelper.CreateMessage(MessageVersion.None, string.Empty, "text/plain", delegate (Stream output)
            {
                TextWriter writer = new StreamWriter(output);
                writer.Write("Hello World!");
                writer.Flush();
                writer.Close();
            });
        }
    }
}
