using DemoCorsoBlazor.Library.Models;

namespace DemoCorsoBlazor.Library.Interfaces
{
    public interface IReqResData
    {
        Task<ReqResData?> GetData();
        void Cancel();
        Task<string> PostData(ReqResRequest newUser);
    }
}
