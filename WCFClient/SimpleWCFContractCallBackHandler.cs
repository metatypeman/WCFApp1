using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace WCFClient
{
    public class SimpleWCFContractCallBackHandler : ISimpleWCFContractCallBack
    {
#if DEBUG
        private static readonly NLog.ILogger _globalLogger = NLog.LogManager.GetCurrentClassLogger();
#endif

        public void SomeResponce(string text)
        {
#if DEBUG
            _globalLogger.Info($"text = {text}");
#endif
        }

        public void ReceiveSomeData(BaseDataClass data)
        {
#if DEBUG
            _globalLogger.Info($"data = {JsonConvert.SerializeObject(data, Formatting.Indented)}");
#endif
        }
    }
}
