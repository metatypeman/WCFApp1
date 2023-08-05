using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Xsl;
using WCFContract;

namespace WCFServer
{
    internal class Program
    {
        private static readonly NLog.ILogger _globalLogger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            _globalLogger.Info("Hello, World!");

            var address = "net.pipe://localhost/MyService.svc";

            try
            {
                var host = WebHost.CreateDefaultBuilder()
                .UseNetNamedPipe(options =>
                {
                    options.Listen(address);
                })
                .ConfigureServices(services =>
                {
                    // Enable CoreWCF Services, enable metadata 
                    services.AddServiceModelServices()
                    .AddServiceModelMetadata();

                    var contextInstance = new TstContext("Hi! M-777");

                    SimpleWCFServer ImplementationFactory(IServiceProvider _) => new SimpleWCFServer(contextInstance);

                    services.AddTransient(ImplementationFactory);
                })
                .Configure(app =>
                {
                    app.UseServiceModel(builder =>
                    {
                        builder.AddService<SimpleWCFServer>();
                        builder.AddServiceEndpoint<SimpleWCFServer, ISimpleWCFContract>(new NetNamedPipeBinding(), address);
                    });
                })
                .Build();

                host.Run();
            }
            catch (Exception ex)
            {
                _globalLogger.Error(ex);
            }
        }
    }
}