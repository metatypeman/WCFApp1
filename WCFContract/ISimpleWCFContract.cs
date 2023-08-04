using System.ServiceModel;

namespace WCFContract
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ISimpleWCFContractCallBack))]
    public interface ISimpleWCFContract
    {
        [OperationContract(IsOneWay = true)]
        void Hi();
        [OperationContract]
        BaseDataClass GetSomeData();
    }

    public interface ISimpleWCFContractCallBack
    {
        [OperationContract(IsOneWay = true)]
        void SomeResponce(string text);

        [OperationContract(IsOneWay = true)]
        void ReceiveSomeData(BaseDataClass data);
    }
}
