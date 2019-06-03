using System;
using System.Threading.Tasks;

namespace eShop.Inventory.API.Service
{
    public interface IInventoryService : IDisposable
    {
        Task SetReorderPoint(int catalogItemStockId, int reorderPoint);
    }
}
