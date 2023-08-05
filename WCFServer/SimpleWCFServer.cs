using CoreWCF;
using Newtonsoft.Json;
using System.Xml.Xsl;
using WCFContract;

namespace WCFServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class SimpleWCFServer : ISimpleWCFContract
    {
#if DEBUG
        private static readonly NLog.ILogger _globalLogger = NLog.LogManager.GetCurrentClassLogger();
#endif

        ISimpleWCFContractCallBack? _callback = null;

        public SimpleWCFServer(TstContext tstContext)
        {
#if DEBUG
            _globalLogger.Info($"Begin");
            _globalLogger.Info($"tstContext.GetSomeValue() = {tstContext.GetSomeValue()}");
#endif

            _callback = CoreWCF.OperationContext.Current.GetCallbackChannel<ISimpleWCFContractCallBack>();

#if DEBUG
            _globalLogger.Info($"End");
#endif
        }

        public void Hi()
        {
#if DEBUG
            _globalLogger.Info($"Begin");
#endif

            _callback.SomeResponce("Hello World!");

            var targetData = new BaseDataClass()
            {
                SomeBaseProp = "The Beatles!"
            };

#if DEBUG
            _globalLogger.Info($"targetData = {JsonConvert.SerializeObject(targetData, Formatting.Indented)}");
#endif

            _callback.ReceiveSomeData(targetData);

#if DEBUG
            _globalLogger.Info($"End");
#endif
        }

        public BaseDataClass GetSomeData()
        {
            //var targetData = new TargetDataClass()
            //{
            //    SomeBaseProp = "Hi from SomeBaseProp",
            //    SomeProp = "Hi from SomeProp"
            //};

            //Inheritance does not work in WFC DataContracts
            var targetData = new BaseDataClass()
            {
                SomeBaseProp = "Hi from SomeBaseProp"
            };

#if DEBUG
            _globalLogger.Info($"targetData = {JsonConvert.SerializeObject(targetData, Formatting.Indented)}");
#endif

            return targetData;
        }
    }
}
