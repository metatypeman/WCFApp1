using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFContract
{
    [DataContract]
    public class BaseDataClass
    {
        [DataMember]
        public string SomeBaseProp { get; set; }
    }
}
