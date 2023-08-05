using Newtonsoft.Json;
using System.ServiceModel;
using WCFContract;

namespace WCFClient
{
    internal class Program
    {
        private static readonly NLog.ILogger _globalLogger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            _globalLogger.Info("Hello, World!");

            try
            {
                var callbackInstance = new InstanceContext(new SimpleWCFContractCallBackHandler());

                var binding = new NetNamedPipeBinding();

                using var factory = new DuplexChannelFactory<ISimpleWCFContract>(callbackInstance, binding, new EndpointAddress("net.pipe://localhost/MyService.svc"));
                factory.Open();

                ISimpleWCFContract client = factory.CreateChannel();
                using var channel = client as IClientChannel;
                channel.Open();
                client.Hi();

                var data = client.GetSomeData();

#if DEBUG
                _globalLogger.Info($"data = {JsonConvert.SerializeObject(data, Formatting.Indented)}");
#endif
            }
            catch (Exception ex)
            {
                _globalLogger.Error(ex);
            }

            _globalLogger.Info("End");

            Console.ReadKey();
        }
    }
}