using eShop.Inventory.API.Entity;
using eShop.Inventory.API.Exception;
using eShop.Inventory.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eShop.Inventory.API.Service
{
    public class InventoryService : IInventoryService
    {
        private InventoryDBContext _dbContext;

        public InventoryService(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SetReorderPoint(int catalogItemId, int reorderPoint)
        {
            CatalogItemStock entity = await _dbContext.CatalogItemsStocks.FirstOrDefaultAsync(s => s.CatalogItemId == catalogItemId);
            if (entity == null)
            {
                throw new CatalogItemStockNotFoundException();
            }

            entity.ReorderPoint = reorderPoint;
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
