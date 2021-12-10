using DemoCorsoBlazor.Library.Models;

namespace DemoCorsoBlazor.Library.Interfaces
{
    public  interface IOrderData
    {
        List<Order> GetCurrentOrders();
        List<Order> GetPastOrders();
    }
}
