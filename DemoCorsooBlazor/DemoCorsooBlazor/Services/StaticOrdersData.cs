
using DemoCorsoBlazor.Library.Interfaces;
using DemoCorsoBlazor.Library.Models;

namespace DemoCorsooBlazor.Services
{
    public class StaticOrdersData : IOrderData
    {
        public List<Order> GetCurrentOrders()
        {
            return new List<Order>
            {
            new Order { Id = 1, Date = DateTime.Today, Description = "ordine 1", Price = 100.0M },
            new Order { Id = 2, Date = DateTime.Today.AddDays(3), Description = "ordine 2", Price = 200.0M },
            };
        }

        public List<Order> GetPastOrders()
        {
            return new List<Order>
            {
            new Order { Id = 10, Date = DateTime.Today, Description = "ordine 1", Price = 100.0M },
            new Order { Id = 20, Date = DateTime.Today.AddDays(3), Description = "ordine 2", Price = 200.0M },
            };

        }
    }
}
