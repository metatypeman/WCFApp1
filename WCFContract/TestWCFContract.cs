using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFContract
{
    [DataContract]
    public class TargetDataClass : BaseDataClass //Inheritance does not work in WFC DataContracts
    {
        [DataMember]
        public string SomeProp { get; set; }
    }
}
