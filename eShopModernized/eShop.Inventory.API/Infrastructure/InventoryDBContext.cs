using eShop.Inventory.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace eShop.Inventory.API.Infrastructure
{
    public partial class InventoryDBContext : DbContext
    {
        public InventoryDBContext(DbContextOptions<InventoryDBContext> options) : base(options)
        {            
        }

        public virtual DbSet<CatalogItemStock> CatalogItemsStocks { get; set; }            

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogItemStock>();   
        }
    }
}
