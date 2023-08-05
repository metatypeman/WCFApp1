using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class TstContext : ITstContext
    {
        private readonly string _someParam;

        public TstContext(string someParam)
        {
            _someParam = someParam;
        }

        public string GetSomeValue()
        {
            return _someParam;
        }
    }
}
