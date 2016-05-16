using System.Collections.Specialized;
using System.IO;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace Launcher
{
    public class DefaultProcessingBehavior : WebHttpBehavior
    {
        protected override IDispatchMessageFormatter GetRequestDispatchFormatter(
            OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            return base.GetRequestDispatchFormatter(operationDescription, endpoint);
        }

    }
}
