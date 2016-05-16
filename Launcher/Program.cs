using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Launcher
{
    class Program
    {

        private static readonly string config = ConfigurationManager.AppSettings["Configuration"];
        private static readonly string address = ConfigurationManager.AppSettings["Host"];

        static Program()
        {
#if DEBUG
            Console.Write("Debug mode, Press enter to continue.");
            Console.ReadLine();
#endif
        }

        static void Main(string[] args)
        {
            Console.WriteLine("...");
            if (!string.IsNullOrEmpty(address))
            {
                using (System.ServiceModel.ServiceHost host =
                    new System.ServiceModel.ServiceHost(typeof(WebService)))
                {
                    ServiceEndpoint endpoint =
                        host.AddServiceEndpoint(typeof(IWebService), new WebHttpBinding()
                        {
                            MaxReceivedMessageSize = 65536000,
                            MaxBufferPoolSize = 65536000,
                            MaxBufferSize = 65536000,
                            WriteEncoding = Encoding.UTF8
                        },
                        new Uri(address));
                    endpoint.Behaviors.Add(new DefaultProcessingBehavior());
                    ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                    if (smb != null)
                    {
                        smb.HttpGetEnabled = false;
                        smb.HttpsGetEnabled = false;
                    }
                    ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
                    if (sdb != null)
                    {
                        sdb.HttpHelpPageEnabled = false;
                    }
                    host.Open();
                    Initialize();
                    Console.WriteLine("Service Initiated (Input 'exit' to exit)");
                    Console.WriteLine("Address (URI) : {0}", address);
                    string input = string.Empty;
                    while (true)
                    {
                        input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input) && input.ToUpper().Equals("EXIT"))
                        {
                            break;
                        }
                    }
                    host.Close();
                }
            }
            else
            {
                Initialize();
                Console.WriteLine("Service Initiated (Input 'exit' to exit)");
                string input = string.Empty;
                while (true)
                {
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input) && input.ToUpper().Equals("EXIT"))
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("Service Terminating ...");
            Shutdown();
            Console.WriteLine("Service Terminated");
            Console.ReadLine();
        }

        private static void Initialize()
        {
            // Todo
        }

        private static void Shutdown()
        {
            // Todo
        }

    }
}
